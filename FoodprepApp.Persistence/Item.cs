namespace FoodPrepApp.Persistence
{
    public class Item
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int NumberOfPortions { get; set; }

        public Item()
        {
            
        }
        public static Item CreateItem(string name, DateTime expirationDate, int numberOfPortions, string description = "")
        {
            Item newItem = new Item(Guid.NewGuid(), name, expirationDate, numberOfPortions, description);
            return newItem;
        }

        public Item(Guid id, string name, DateTime expirationDate, int numberOfPortions, string description = "", string? imagePath = null)
        {
            this.Id = id;
            this.Name = name;
            this.ExpirationDate = expirationDate;
            this.NumberOfPortions = numberOfPortions;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"{Name}, {NumberOfPortions} adag, {ExpirationDate.Year}.{ExpirationDate.Month}";
        }
    }
}
