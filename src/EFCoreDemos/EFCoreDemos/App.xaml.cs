using EFCoreDemos.Models;
using EFCoreDemos.Views;

namespace EFCoreDemos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();

        this.Handler?.MauiContext?.Services.GetService<StudentDbContext>()?.InitializeDatabase();
    }
}