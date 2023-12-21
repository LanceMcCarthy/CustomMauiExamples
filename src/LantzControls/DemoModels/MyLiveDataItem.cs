using Telerik.Maui.Controls;

namespace LantzControls.DemoModels;

public class MyLiveDataItem : NotifyPropertyChangedBase
{
    private string status;
    private string description;
    private string createdBy;
    private string recipient;
    private bool isFetchingData;

    public string Status
    {
        get => status;
        set => UpdateValue(ref status, value);
    }

    public string Description
    {
        get => description;
        set => UpdateValue(ref description, value);
    }

    public string CreatedBy
    {
        get => createdBy;
        set => UpdateValue(ref createdBy, value);
    }

    public string Recipient
    {
        get => recipient;
        set => UpdateValue(ref recipient, value);
    }

    public bool IsFetchingData
    {
        get => isFetchingData;
        set => UpdateValue(ref isFetchingData, value);
    }
}