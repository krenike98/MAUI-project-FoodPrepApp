
namespace FoodPrepApp.Persistence
{
    public interface IFoodPrepAppPersistence
    {
        public Task<Items?> LoadData();
        public Task SaveData(Items items);
        public Items CreateDummyItems();
    }
}
