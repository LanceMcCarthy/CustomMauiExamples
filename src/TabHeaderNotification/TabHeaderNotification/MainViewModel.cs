using CommonHelpers.Common;
using CommonHelpers.Mvvm;

namespace TabHeaderNotification;

public class MainViewModel : ViewModelBase
{
    private int notificationCount;

    public MainViewModel()
    {
        IncreaseNotificationCountCommand = new DelegateCommand(IncreaseCount);
        ClearNotificationCountCommand = new DelegateCommand(ClearCount);
    }

    public int NotificationCount
    {
        get => notificationCount;
        set => SetProperty(ref notificationCount, value);
    }

    public DelegateCommand IncreaseNotificationCountCommand { get; set; }

    public DelegateCommand ClearNotificationCountCommand { get; set; }

    private void IncreaseCount()
    {
        NotificationCount++;
    }

    private void ClearCount()
    {
        NotificationCount--;
    }
}