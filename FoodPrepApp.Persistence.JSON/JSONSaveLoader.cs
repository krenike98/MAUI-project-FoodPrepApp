using Bogus;
using System.IO;
using System.Text.Json;

namespace FoodPrepApp.Persistence.JSON
{
    public class JSONSaveLoader : IFoodPrepAppPersistence
    {
        static readonly string pathToJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "foodPrepData.json");
        public async Task<Items?> LoadData()
        {
            try
            {
                Items? items = null;
                if (File.Exists(pathToJson))
                {
                    string json = await File.ReadAllTextAsync(pathToJson);
                    items = JsonSerializer.Deserialize<Items>(json) ?? new Items();
                }
                return items;
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveData(Items items)
        {

            string json = JsonSerializer.Serialize(items);
            await File.WriteAllTextAsync(pathToJson, json);

        }


        public Items CreateDummyItems()
        {
            Items items = new();
            var faker = new Faker<Item>()
                       .RuleFor(i => i.Id, f => Guid.NewGuid())
                       .RuleFor(i => i.Name, f => f.Lorem.Word())
                       .RuleFor(i => i.Description, f => f.Random.Bool(0.2f) ? null : f.Lorem.Sentence())
                       .RuleFor(i => i.ExpirationDate, f => GetRandomExpirationDate(f))
                       .RuleFor(i => i.NumberOfPortions, f => f.Random.Number(1, 5));

            for (int i = 0; i < 20; i++)
            {
                var item = faker.Generate();
                items.Dishes.Add(item);
            }

            for (int i = 0; i < 20; i++)
            {
                var item = faker.Generate();
                items.Ingredients.Add(item);
            }

            return items;
        }
        private static DateTime GetRandomExpirationDate(Faker f)
        {
            var startDate = DateTime.Now.AddMonths(3);
            var endDate = DateTime.Now.AddYears(3);

            var randomDate = f.Date.Between(startDate, endDate);

            return new DateTime(randomDate.Year, randomDate.Month, 1);
        }

    }
}
