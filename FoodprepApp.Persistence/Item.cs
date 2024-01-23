namespace FoodPrepApp.Persistence
{
    public class Item
    {
        public Guid id { get; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime expirationDate { get; set; }
        public int numberOfPortions { get; set; }
        public string? imagePath { get; set; }

        public static Item CreateItem(string name, DateTime expirationDate, int numberOfPortions, string description = "", string? imagePath = null)
        {
            Item newItem = new Item(Guid.NewGuid(), name, expirationDate, numberOfPortions, description, imagePath);
            return newItem;
        }

        public Item(Guid id, string name, DateTime expirationDate, int numberOfPortions, string description = "", string? imagePath = null)
        {
            this.id = id;
            this.name = name;
            this.expirationDate = expirationDate;
            this.numberOfPortions = numberOfPortions;
            this.description = description;
            if (imagePath != null) this.imagePath = imagePath;
            else this.imagePath = "FoodPrepApp.Model.Data.Images.default.jpg";
        }

        public override string ToString()
        {
            return $"{name}, {numberOfPortions} adag, {expirationDate.Year}.{expirationDate.Month}";
        }
    }
}
