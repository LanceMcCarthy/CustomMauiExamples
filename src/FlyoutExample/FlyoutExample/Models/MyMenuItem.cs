using CommonHelpers.Common;

namespace FlyoutExample.Models;

public class MyMenuItem : BindableBase
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string IconPath { get; set; }

    public Type TargetType { get; set; }
}
