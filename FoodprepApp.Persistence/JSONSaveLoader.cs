using System.Text.Json;

namespace FoodPrepApp.Persistence
{
    public class JSONSaveLoader
    {
        public static async Task WriteDataAsync(Items items, string path)
        {
            await Task.Run(() => WriteData(items, path));
        }
        public static void WriteData(Items items, string path)
        {
            string jsonString = JsonSerializer.Serialize(items);
            File.WriteAllText(path, jsonString);
        }

        public static async Task<Items> ReadDataAsync(string path)
        {
            return await Task.Run(() => ReadData(path));
        }

        public static Items ReadData(string path)
        {
            if (!File.Exists(path))
                return new Items();

            string jsonFromFile = File.ReadAllText(path);

            try
            {
                return JsonSerializer.Deserialize<Items>(jsonFromFile) ?? new Items();
            }
            catch (Exception)
            {
                //format changed
                return new Items();
            }
        }
    }
}
