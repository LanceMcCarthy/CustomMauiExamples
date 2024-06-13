using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using Telerik.Maui;
using Telerik.Maui.Controls.Data;
using System.Linq;
using System.Linq.Dynamic.Core;

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
                // Thanks to System.Linq.Dynamic.Core
                switch (descriptor)
                {
                    case BooleanFilterDescriptor boolDescriptor:
                        query = query.Where($"{propDescriptor.PropertyName} == @0", propDescriptor.Value);
                        break;
                    case TextFilterDescriptor textDescriptor:
                        {
                            switch (textDescriptor.Operator)
                            {
                                case TextOperator.EqualsTo:
                                    query = query.Where($"{propDescriptor.PropertyName} == @0", propDescriptor.Value);
                                    break;
                                case TextOperator.DoesNotEqualTo:
                                    query = query.Where($"{propDescriptor.PropertyName} != @0", propDescriptor.Value);
                                    break;
                                case TextOperator.StartsWith:
                                    query = query.Where($"{propDescriptor.PropertyName}.StartsWith(@0)", propDescriptor.Value);
                                    break;
                                case TextOperator.EndsWith:
                                    query = query.Where($"{propDescriptor.PropertyName}.EndsWith(@0)", propDescriptor.Value);
                                    break;
                                case TextOperator.Contains:
                                    query = query.Where($"{propDescriptor.PropertyName}.StartsWith(@0)", propDescriptor.Value);
                                    break;
                                case TextOperator.DoesNotContain:
                                    query = query.Where($"{propDescriptor.PropertyName}.Contains(@0) == false", propDescriptor.Value);
                                    break;
                                case TextOperator.IsEmpty:
                                    query = query.Where($"{propDescriptor.PropertyName}.IsNullOrEmpty(@0)", propDescriptor.Value);
                                    break;
                                case TextOperator.IsNotEmpty:
                                    query = query.Where($"{propDescriptor.PropertyName}.IsNullOrEmpty(@0) == false", (string)propDescriptor.Value);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            //if (propDescriptor.PropertyName == nameof(StudentEntity.FullName))
                            //{
                            //    query = textDescriptor.Operator switch
                            //    {
                            //        TextOperator.EqualsTo => query.Where(s=>s.Equals((string)propDescriptor.Value)),
                            //        TextOperator.DoesNotEqualTo => query.Where(s => !s.Equals((string)propDescriptor.Value)),
                            //        TextOperator.StartsWith => query.Where(s => s.FullName.StartsWith((string)propDescriptor.Value)),
                            //        TextOperator.EndsWith => query.Where(s => s.FullName.EndsWith((string)propDescriptor.Value)),
                            //        TextOperator.Contains => query.Where(s => s.FullName.Contains((string)propDescriptor.Value)),
                            //        TextOperator.DoesNotContain => query.Where(s => !s.FullName.Contains((string)propDescriptor.Value)),
                            //        TextOperator.IsEmpty => query.Where(s => s.FullName == string.Empty),
                            //        TextOperator.IsNotEmpty => query.Where(s => s.FullName != string.Empty),
                            //        _ => throw new ArgumentOutOfRangeException()
                            //    };
                            //}

                            break;
                        }

                    // Number filter
                    case NumericalFilterDescriptor numDescriptor:
                    {
                        switch (numDescriptor.Operator)
                        {
                            case NumericalOperator.EqualsTo:
                                query = query.Where($"{propDescriptor.PropertyName} == @0", propDescriptor.Value);
                                break;
                            case NumericalOperator.DoesNotEqualTo:
                                query = query.Where($"{propDescriptor.PropertyName} != @0", propDescriptor.Value);
                                break;
                            case NumericalOperator.IsGreaterThan:
                                query = query.Where($"{propDescriptor.PropertyName} > @0", propDescriptor.Value);
                                break;
                            case NumericalOperator.IsGreaterThanOrEqualTo:
                                query = query.Where($"{propDescriptor.PropertyName} >= @0", propDescriptor.Value);
                                break;
                            case NumericalOperator.IsLessThan:
                                query = query.Where($"{propDescriptor.PropertyName} < @0", propDescriptor.Value);
                                break;
                            case NumericalOperator.IsLessThanOrEqualTo:
                                query = query.Where($"{propDescriptor.PropertyName} <= @0", propDescriptor.Value);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }


                        // Using property name
                        //query = numDescriptor.Operator switch
                        //{
                        //    NumericalOperator.EqualsTo => query.Where(s => s.Grade == Convert.ToInt32(numDescriptor.Value)),
                        //    NumericalOperator.DoesNotEqualTo => query.Where(s => s.Grade != Convert.ToInt32(numDescriptor.Value)),
                        //    NumericalOperator.IsGreaterThan => query.Where(s => s.Grade > Convert.ToInt32(numDescriptor.Value)),
                        //    NumericalOperator.IsGreaterThanOrEqualTo => query.Where(s => s.Grade >= Convert.ToInt32(numDescriptor.Value)),
                        //    NumericalOperator.IsLessThan => query.Where(s => s.Grade < Convert.ToInt32(numDescriptor.Value)),
                        //    NumericalOperator.IsLessThanOrEqualTo => query.Where(s => s.Grade <= Convert.ToInt32(numDescriptor.Value)),
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