using FoodPrepApp.Persistence;

namespace FoodPrepApp.Model
{
    public class FoodPrepModel
    {
        // fields
        public Items Items { get; set; }
        private IFoodPrepAppPersistence _persistence;

        // events
        public event EventHandler DataLoadFailed;
        public event EventHandler DataSaveFailed;
        // constructor
        public FoodPrepModel(IFoodPrepAppPersistence persistence)
        {
            _persistence = persistence;
        }

        // save data
        public async void SaveData()
        {
            try
            {
                await _persistence.SaveData(Items);
            }catch 
            {
                OnDataSaveFailed();
            }
        }

        private void OnDataSaveFailed()
        {
            DataSaveFailed?.Invoke(this, EventArgs.Empty);
        }

        // load data
        public async Task<bool> LoadDataAsync()
        {
            if (_persistence != null)
            {
                Items = await _persistence.LoadData();
                if(Items == null)
                {
                    OnDataLoadFailed();
                }
                return true;
            }
            return false;
        }

        protected virtual void OnDataLoadFailed()
        {
            DataLoadFailed?.Invoke(this, EventArgs.Empty);
        }

        public int GetNumOfDishes()
        {
            return Items.Dishes.Count;
        }
        public int GetNumOfIngredients()
        {
            return Items.Ingredients.Count;
        }
    }
}