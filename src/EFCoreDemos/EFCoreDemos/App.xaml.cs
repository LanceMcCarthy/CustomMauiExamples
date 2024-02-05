using EFCoreDemos.Models;

namespace EFCoreDemos
{
    public partial class App : Application
    {
        private readonly StudentDbContext dbContext;

        public App(StudentDbContext dbService)
        {
            dbContext = dbService;

            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // IMPORTANT!
            // This checks to see if the table exists.
            await dbContext.InitializeDatabaseAsync();

            // This is only to generate sample data for the demo (only if the table is empty)
            if (!dbContext.Students.Any())
            {
                for (var i = 0; i < 2000; i++)
                {
                    dbContext.Students.Add(new StudentEntity
                    {
                        FullName = $"StudentEntity {i+1}",
                        Grade = i % 2 == 0 ? 11 : 12
                    });
                }

                await dbContext.SaveChangesAsync();
            }

            base.OnStart();
        }
    }
}
