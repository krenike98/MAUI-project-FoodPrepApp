using System.Collections.ObjectModel;
using FoodPrepApp.Persistence;

namespace FoodPrepApp.ViewModel
{
    public class ItemsViewModel: BindingSource
    {
        // fields
        private Model.FoodPrepModel _model;

        // properties
        public ObservableCollection<ItemViewModel> Ingredients { get; private set; }
        public ObservableCollection<ItemViewModel> Dishes { get; private set; }


        public ItemsViewModel(Model.FoodPrepModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");
            Ingredients = ConvertModels(_model.Items.Ingredients);
            Dishes = ConvertModels(_model.Items.Dishes);
        }

        private ObservableCollection<ItemViewModel> ConvertModels(List<Item> items)
        {
            return new ObservableCollection<ItemViewModel>(items.Select(item => new ItemViewModel(item)));
        }


    }
}
