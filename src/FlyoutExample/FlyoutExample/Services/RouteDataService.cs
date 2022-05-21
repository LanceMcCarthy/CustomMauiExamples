using CommonHelpers.Services;
using FlyoutExample.Models;
using Newtonsoft.Json;
using System.Net;

namespace FlyoutExample.Services;

public class RouteDataService
{
    private readonly string dataFilePath;
    private readonly HttpClient client;
    private List<Pilot> pilots;

    public RouteDataService()
    {
        dataFilePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pilots.json");

        var handler = new HttpClientHandler();
        if (handler.SupportsAutomaticDecompression)
            handler.AutomaticDecompression = DecompressionMethods.All;

        client = new HttpClient(handler);
    }

    private async Task InitializeAsync()
    {
        if (File.Exists(dataFilePath))
        {
            LoadSavedData();
        }
        else
        {
            var employees = SampleDataService.Current.GenerateEmployeeData();

            this.pilots = new List<Pilot>();
            var rand = new Random();

            foreach (var employee in employees)
            {
                // instantiation creates unique ID guid
                var p = new Pilot();

                // copy properties over to pilot object
                p.GeneratePilotFromEmployee(employee, rand.Next(0,1000));

                pilots.Add(p);
            }
            
            var facesNeeded = pilots.Count; // should not be more than 100, which is the max per-page from the API. Otherwise I need to implement paging.
            
            var jsonResult = await client.GetStringAsync($"https://api.generated.photos/api/v1/faces?confidence=0.9&api_key=Wfv6KDcZokTlni9LWSdrGw&age=adult&per_page={facesNeeded}");

            var result = JsonConvert.DeserializeObject<FaceApiResult>(jsonResult);
            
            if (result?.Faces == null || result.Faces.Count < facesNeeded)
            {
                Console.WriteLine("WARNING - The Faces API did not return the expected number of faces");
                return;
            }

            for (var i = 0; i < pilots.Count - 1; i++)
            {
                var pilot = pilots[i];
                var face = result.Faces[i];

                pilot.Gender = face.Meta.Gender.FirstOrDefault();
                pilot.Ethnicity = face.Meta.Ethnicity.FirstOrDefault();
                pilot.EyeColor = face.Meta.EyeColor.FirstOrDefault();
                pilot.HairColor = face.Meta.HairColor.FirstOrDefault();
                pilot.HairLength = face.Meta.HairLength.FirstOrDefault();

                // Need to fix names after getting more data from API
                var isMale = pilot.Gender == "male";
                var splitName = pilot.Name.Split(' ', StringSplitOptions.TrimEntries);
                var isEven = i % 2 == 0;
                var isThird = i % 3 == 0;
                var isFourth = i % 4 == 0;
                var firstName = "";

                if (isFourth)
                {
                    firstName = isMale ? "Chris" : "Eva";
                }
                else if (isThird)
                {
                    firstName = isMale ? "Peter" : "Theresa";
                }
                else if (isEven)
                {
                    firstName = isMale ? "Mike" : "Megan";
                }
                else
                {
                    firstName = isMale ? "John" : "Jane";
                }

                pilot.Name = $"{firstName} {splitName[1]}";

                Dictionary<string, Uri> bestUrl = null;

                foreach (var currentUrl in face.Urls.Where(currentUrl => currentUrl.Keys.Any(key => key == "512")))
                {
                    bestUrl = currentUrl;
                }
                
                if (bestUrl == null)
                {
                    Console.WriteLine("WARNING - Face Url doesn't have a value");
                    continue;
                }
                
                var imageUrlToSave = bestUrl.Values.FirstOrDefault()?.OriginalString;
                var imgBytes = await client.GetByteArrayAsync(imageUrlToSave);
                var imageFilePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{pilot.Id}.jpg");

                await File.WriteAllBytesAsync(imageFilePath, imgBytes);

                Console.WriteLine($"Saved {imgBytes.Length} bytes for {pilot.Name} profile photo.");

                pilot.PhotoUrl = imageFilePath;
            }

            SaveData();
        }
    }

    public async Task<List<Pilot>> GetPilotsAsync()
    {
        if (pilots == null)
            await InitializeAsync();

        return pilots;
    }

    public Task AddPilotAsync(Pilot routePilot)
    {
        this.pilots.Add(routePilot);

        SaveData();

        return Task.CompletedTask;
    }

    public Task UpdatePilotAsync(Pilot editedPilot)
    {
        var pilot = this.pilots.FirstOrDefault(e => e.Id == editedPilot.Id);

        if (pilot != null)
        {
            pilot.Name = editedPilot.Name;
            pilot.Position = editedPilot.Position;
            pilot.Salary = editedPilot.Salary;
            pilot.StartDate = editedPilot.StartDate;
            pilot.VacationTotal = editedPilot.VacationTotal;
            pilot.VacationUsed = editedPilot.VacationUsed;
            pilot.PhotoUrl = editedPilot.PhotoUrl;
            pilot.Ethnicity = editedPilot.Ethnicity;
            pilot.Gender = editedPilot.Gender;
            pilot.EyeColor = editedPilot.EyeColor;
            pilot.HairColor = editedPilot.HairColor;
            pilot.HairLength = editedPilot.HairLength;

            SaveData();
        }

        return Task.CompletedTask;
    }

    public Task<bool> RemovePilotAsync(Pilot routePilot)
    {
        if (this.pilots.Contains(routePilot))
        {
            this.pilots.Remove(routePilot);

            SaveData();

            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    private void SaveData()
    {
        var json = JsonConvert.SerializeObject(this.pilots);
        File.WriteAllText(dataFilePath, json);
    }

    private void LoadSavedData()
    {
        var json = File.ReadAllText(dataFilePath);
        var savedPilots = JsonConvert.DeserializeObject<List<Pilot>>(json);
        this.pilots = savedPilots;
    }
}
