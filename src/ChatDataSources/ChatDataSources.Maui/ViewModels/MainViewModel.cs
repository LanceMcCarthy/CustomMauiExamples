using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ChatDataSources.Maui.Models;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Chat;

namespace ChatDataSources.Maui.ViewModels;

public class MainViewModel : NotifyPropertyChangedBase
{
    private readonly MessagesDbContext dbContext;
    private Author? me;

    public MainViewModel(MessagesDbContext dbService)
    {
        dbContext = dbService;

        this.Me = new Author { Name = "human" };
        this.Bot = new Author { Name = "Bot" };
    }

    public Author Me
    {
        get => this.me;
        set => UpdateValue(ref this.me, value);
    }

    public Author Bot { get; set; }

    public ObservableCollection<SimpleChatItem>? Items { get; set; } = new();

    public async Task Initialize()
    {
        await dbContext.InitializeDatabaseAsync();

        // Get the messages in the database
        var itemsInDatabase = dbContext.Messages.ToList();

        foreach (var item in itemsInDatabase)
        {
            Items.Add(item);
        }

        // Once we're done loading the database data subscribe to the collection changed event, the event handler is where we copy the item form the collection to the database
        Items.CollectionChanged += Items_CollectionChanged;

        // FIRST RUN ONLY
        // Add a couple messages if the database is empty
        if (this.Items.Count == 0)
        {
            Items.Add(new SimpleChatItem { AuthorName = Bot.Name, Text = "Hello there! How are you doing today?" });
            Items.Add(new SimpleChatItem { AuthorName = Me.Name, Text = "I'm fine, thank you!" });
            Items.Add(new SimpleChatItem { AuthorName = Bot.Name, Text = "What can I do for you?" });
        }
    }

    // Save any items added in the chat to the database
    private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems?.Count > 0)
        {
            foreach (var item in e.NewItems)
            {
                if (item is SimpleChatItem chatItem)
                {
                    dbContext.Messages.Add(chatItem);
                }
            }

            // After adding all the items to the dbContext, we save the database
            dbContext.SaveChanges();
        }
    }
}