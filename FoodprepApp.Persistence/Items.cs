namespace FoodPrepApp.Persistence
{
    public class Items
    {
        public List<Item> Ingredients { get; set; }
        public List<Item> Dishes { get; set; }

        public Items()
        {
            Ingredients = new List<Item>();
            Dishes = new List<Item>();
        }


    }
}
