using System.Collections.ObjectModel;
using FoodPrepApp.Persistence;

namespace FoodPrepApp.ViewModel
{
    public class ItemsViewModel: BindingSource
    {
        // fields
        private Model.FoodPrepModel _model;

        // properties
        public ObservableCollection<Item> Ingredients { get; private set; }
        public ObservableCollection<Item> Dishes { get; private set; }

        public ItemsViewModel(Model.FoodPrepModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");
            Ingredients = new ObservableCollection<Item>(_model.items.ingredients);
            Dishes = new ObservableCollection<Item>(_model.items.dishes);
        }

    }
}
