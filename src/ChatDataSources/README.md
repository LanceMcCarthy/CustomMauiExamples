# Chat Data Source Demos

## EntityFramework (Sqlite and SqlServer)

![chat](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/6e1bbc02-96a2-42ea-b1f5-d2f5ffc05b3c)

> ![!IMPORTANT]
> Notice we are using the CollectionChanged event of the Itemssource to save the messages to the database.

```csharp
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
```

## gRPC

TODO

## signalR

TODO