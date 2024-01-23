using FoodPrepApp.Persistence;
namespace FoodPrepApp.Model
{
    public class FoodPrepModel
    {
        static string pathToJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "foodPrepData.json");
        // fields
        public Items items { get; set; }

        // constructor
        public FoodPrepModel()
        {
            items = JSONSaveLoader.ReadData(pathToJson);
            //CreateDummyItems();
            //JSONSaveLoader.WriteData(items, pathToJson);
        }


        public int getNumOfDishes()
        {
            return items.dishes.Count;
        }
        public int getNumOfIngredients()
        {
            return items.ingredients.Count;
        }

        private void CreateDummyItems()
        {

            items.ingredients.Add(new Item(Guid.Parse("796565d4-9a17-48ab-b547-aa273de13107"), "Kockázott sütőtök", DateTime.Parse("2024-12-01T00:00:00"), 5, "Kb fél kilós adagokban lefagyaszva", "FoodPrepApp.Model.Data.Images.default.jpg"));
            items.ingredients.Add(new Item(Guid.Parse("99864052-3cd7-4886-9663-5c7ed3bf1ad4"), "Áfonya", DateTime.Parse("2025-01-01T00:00:00"), 3, "Bolti 450g", "FoodPrepApp.Model.Data.Images.default.jpg"));
            items.ingredients.Add(new Item(Guid.Parse("8ec0f67f-fe7c-4ea6-b71a-4b0202802100"), "Gyalult tök", DateTime.Parse("2025-10-01T00:00:00"), 2, "3-400g", "FoodPrepApp.Model.Data.Images.default.jpg"));
            //items.ingredients.Add(new Item(Guid.Parse("9c0091fd-f787-40f6-a99b-6c2555085d70"), "Sliced Zucchini", DateTime.Parse("2024-06-01T00:00:00"), 4, "Fresh, 300g packs", "FoodPrepApp.Model.Data.Images.default.jpg"));

            items.dishes.Add(new Item(Guid.Parse("bc665650-f9ec-4607-ae73-122e1a684a5e"), "Rakott karfiol", DateTime.Parse("2024-12-01T00:00:00"), 4, "Ikea üveg ételhordókban", "FoodPrepApp.Model.Data.Images.default.jpg"));
            items.dishes.Add(new Item(Guid.Parse("d3d82f7d-ac11-4ecc-8abe-91fbace1e248"), "Lasagne", DateTime.Parse("2024-03-01T00:00:00"), 2, "A zöld ételhordóban", "FoodPrepApp.Model.Data.Images.default.jpg"));
            items.dishes.Add(new Item(Guid.Parse("4f3be875-0749-4cf0-8d01-1d1064271cca"), "Kókuszgolyó", DateTime.Parse("1999-03-04T00:00:00"), 5, "Lila edényben", "FoodPrepApp.Model.Data.Images.default.jpg"));
            items.dishes.Add(new Item(Guid.Parse("58482e6d-527c-4a0f-b652-cf0e593e2b8f"), "Vegetarian Stir-Fry", DateTime.Parse("2024-06-01T00:00:00"), 6, "Colorful veggies in a savory sauce", "FoodPrepApp.Model.Data.Images.default.jpg"));
        }
    }
}