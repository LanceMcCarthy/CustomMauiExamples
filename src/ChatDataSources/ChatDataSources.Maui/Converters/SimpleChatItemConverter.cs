using ChatDataSources.Maui.Models;
using ChatDataSources.Maui.ViewModels;
using Telerik.Maui.Controls.Chat;

namespace ChatDataSources.Maui.Converters;

public class SimpleChatItemConverter : IChatItemConverter
{
    public ChatItem ConvertToChatItem(object dataItem, ChatItemConverterContext context)
    {
        var vm = (MainViewModel)context.Chat.BindingContext;

        // return the built-in message type
        return new TextMessage
        {
            Data = dataItem,
            Author = ((SimpleChatItem)dataItem).AuthorName == vm.Me.Name ? vm.Me : vm.Bot,
            Text = ((SimpleChatItem)dataItem).Text
        };
    }
    public object ConvertToDataItem(object message, ChatItemConverterContext context)
    {
        var vm = (MainViewModel)context.Chat.BindingContext;

        // return the custom message type
        return new SimpleChatItem { AuthorName = vm.Me.Name, Text = (string)message, };
    }
}