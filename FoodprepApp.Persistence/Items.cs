namespace FoodPrepApp.Persistence
{
    public class Items
    {
        public List<Item> ingredients { get; set; }
        public List<Item> dishes { get; set; }

        public Items()
        {
            ingredients = new List<Item>();
            dishes = new List<Item>();
        }
    }
}
