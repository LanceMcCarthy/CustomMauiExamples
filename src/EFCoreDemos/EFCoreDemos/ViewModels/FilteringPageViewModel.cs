using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.IdentityModel.Tokens;
using Telerik.Maui;
using Telerik.Maui.Controls.Data;

namespace EFCoreDemos.ViewModels;

public class FilteringPageViewModel : ViewModelBase
{
    private ObservableCollection<FilterDescriptorBase> studentFilterDescriptors = new();
    private readonly StudentDbContext dbContext;
    private readonly int itemsPerPage = 50;
    private int pageToGet = 0;

    public FilteringPageViewModel(StudentDbContext dbService)
    {
        dbContext = dbService;

        DataGridStudents = new LoadOnDemandCollection<StudentEntity>(FetchData);
    }

    public LoadOnDemandCollection<StudentEntity> DataGridStudents { get; set; }

    public ObservableCollection<FilterDescriptorBase> StudentFilterDescriptors
    {
        get => studentFilterDescriptors;
        set
        {
            // ****** NOTICE - THIS IS A PRESET FILTER ****** //
            if (value.Count == 0)
            {
                value.Add(new TextFilterDescriptor { PropertyName = nameof(StudentEntity.FullName), Value = "5", Operator = TextOperator.Contains });

                //value.Add(new NumericalFilterDescriptor { PropertyName = nameof(StudentEntity.Grade), Value = 12, Operator = NumericalOperator.IsGreaterThan });
            }

            studentFilterDescriptors.CollectionChanged -= FilterDescriptors_CollectionChanged;
            studentFilterDescriptors = value;
            studentFilterDescriptors.CollectionChanged += FilterDescriptors_CollectionChanged;

            OnPropertyChanged();
        }
    }

    private void FilterDescriptors_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
    {
        UpdateDataAfterFilterChange();
    }

    private void UpdateDataAfterFilterChange()
    {
        // IMPORTANT: You need to write additional logic to handle when a filter is added or removed
        // You might need to clear the existing collection and maintain the same page
    }

    private IEnumerable<StudentEntity> FetchData(CancellationToken ct)
    {
        try
        {
            IQueryable<StudentEntity> query = dbContext.Students.AsQueryable();

            // **** Phase 1 *** //
            // Check to see if there are any descriptors applied and apply them to the LINQ query
            HandleFilterQueries(ref query);

            // **** Phase 2 *** //
            // Handle Skip and Take

            // Skips the pages you've already fetched
            query = query.Skip(itemsPerPage * pageToGet);

            // Takes the next page of items
            query = query.Take(itemsPerPage);


            // **** Phase 3 *** //
            // Execute the query by invoking ToList()
            var nextPageOfData = query.ToList();

            pageToGet++;

            return nextPageOfData;
        }
        catch
        {
            // Return an empty list to stop loading
            return new List<StudentEntity>();
        }
    }

    public Task OnAppearing()
    {
        // Load first batch to get started.
        DataGridStudents.AddRange(FetchData(default));

        return Task.CompletedTask;
    }

    private void HandleFilterQueries(ref IQueryable<StudentEntity> query)
    {
        foreach (var descriptor in StudentFilterDescriptors)
        {
            if (descriptor is PropertyFilterDescriptor propDescriptor)
            {
                var prop = typeof(StudentEntity).GetProperty(propDescriptor.PropertyName);

                if (prop == null)
                    return;

                switch (descriptor)
                {
                    // Bool filter
                    case BooleanFilterDescriptor boolDescriptor:
                        query = query.Where(s => prop.GetValue(s, null) == boolDescriptor.Value);
                        break;

                    // Text filter
                    case TextFilterDescriptor textDescriptor:
                        {
                            // Using a known property does work!!
                            if (propDescriptor.PropertyName == nameof(StudentEntity.FullName))
                            {
                                query = textDescriptor.Operator switch
                                {
                                    TextOperator.EqualsTo => query.Where(s => s.FullName.Equals(textDescriptor.Value)),
                                    TextOperator.DoesNotEqualTo => query.Where(s => !s.FullName.Equals(textDescriptor.Value)),
                                    TextOperator.StartsWith => query.Where(s => s.FullName.StartsWith((string)textDescriptor.Value)),
                                    TextOperator.EndsWith => query.Where(s => s.FullName.EndsWith((string)textDescriptor.Value)),
                                    TextOperator.Contains => query.Where(s => s.FullName.Contains((string)textDescriptor.Value)),
                                    TextOperator.DoesNotContain => query.Where(s => !s.FullName.Contains((string)textDescriptor.Value)),
                                    TextOperator.IsEmpty => query.Where(s => s.FullName == string.Empty),
                                    TextOperator.IsNotEmpty => query.Where(s => s.FullName != string.Empty),
                                    _ => throw new ArgumentOutOfRangeException()
                                };
                            }

                            // Using reflection to get the property does not work because it's not convertible to SQL
                            //query = textDescriptor.Operator switch
                            //{
                            //    TextOperator.EqualsTo => query.Where(s => ((string)prop.GetValue(s, null)!).Equals(textDescriptor.Value)),
                            //    TextOperator.DoesNotEqualTo => query.Where(s => !((string)prop.GetValue(s, null)!).Equals(textDescriptor.Value)),
                            //    TextOperator.StartsWith => query.Where(s => ((string)prop.GetValue(s, null)!).StartsWith((string)textDescriptor.Value)),
                            //    TextOperator.EndsWith => query.Where(s => ((string)prop.GetValue(s, null)!).EndsWith((string)textDescriptor.Value)),
                            //    TextOperator.Contains => query.Where(s => ((string)prop.GetValue(s, null)!).Contains((string)textDescriptor.Value)),
                            //    TextOperator.DoesNotContain => query.Where(s => !((string)prop.GetValue(s, null)!).Contains((string)textDescriptor.Value)),
                            //    TextOperator.IsEmpty => query.Where(s => ((string)prop.GetValue(s, null)!).IsNullOrEmpty()),
                            //    TextOperator.IsNotEmpty => query.Where(s => !((string)prop.GetValue(s, null)!).IsNullOrEmpty()),
                            //    _ => throw new ArgumentOutOfRangeException()
                            //};

                            break;
                        }

                    // Number filter
                    case NumericalFilterDescriptor numDescriptor:
                        {
                            query = numDescriptor.Operator switch
                            {
                                NumericalOperator.EqualsTo => query.Where(s => s.Grade == Convert.ToInt32(numDescriptor.Value)),
                                NumericalOperator.DoesNotEqualTo => query.Where(s => s.Grade != Convert.ToInt32(numDescriptor.Value)),
                                NumericalOperator.IsGreaterThan => query.Where(s => s.Grade > Convert.ToInt32(numDescriptor.Value)),
                                NumericalOperator.IsGreaterThanOrEqualTo => query.Where(s => s.Grade >= Convert.ToInt32(numDescriptor.Value)),
                                NumericalOperator.IsLessThan => query.Where(s => s.Grade < Convert.ToInt32(numDescriptor.Value)),
                                NumericalOperator.IsLessThanOrEqualTo => query.Where(s => s.Grade <= Convert.ToInt32(numDescriptor.Value)),
                                _ => throw new ArgumentOutOfRangeException()
                            };

                            // Using reflection to get the property does not work because it's not convertible to SQL
                            //query = numDescriptor.Operator switch
                            //{
                            //    NumericalOperator.EqualsTo => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) == Convert.ToInt32(numDescriptor.Value)),
                            //    NumericalOperator.DoesNotEqualTo => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) != Convert.ToInt32(numDescriptor.Value)),
                            //    NumericalOperator.IsGreaterThan => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) > Convert.ToInt32(numDescriptor.Value)),
                            //    NumericalOperator.IsGreaterThanOrEqualTo => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) >= Convert.ToInt32(numDescriptor.Value)),
                            //    NumericalOperator.IsLessThan => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) < Convert.ToInt32(numDescriptor.Value)),
                            //    NumericalOperator.IsLessThanOrEqualTo => query.Where(s => Convert.ToInt32(prop.GetValue(s, null)) <= Convert.ToInt32(numDescriptor.Value)),
                            //    _ => throw new ArgumentOutOfRangeException()
                            //};
                            break;
                        }
                    // IMPLEMENT ANY OTHER DESCRIPTORS YOU NEED
                    default:
                        break;
                }
            }
        }
    }
}