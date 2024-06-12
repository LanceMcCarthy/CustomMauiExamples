using EFCoreDemos.Models;

namespace EFCoreDemos.Views
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var dbContext = Application.Current.Handler.MauiContext.Services.GetService<StudentDbContext>();

            await dbContext.InitializeDatabaseAsync();
        }
    }
}
