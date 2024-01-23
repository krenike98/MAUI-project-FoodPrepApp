using FoodPrepApp.Model;
using FoodPrepApp.ViewModel;

namespace FoodPrepApp
{
    public partial class App : Application
    {
        private NavigationPage _rootPage;
        private FoodPrepModel _model;
        private FoodPrepViewModel _mainViewModel;
        private ItemsViewModel _itemsViewModel;

        public App()
        {
            InitializeComponent();
            _model = new FoodPrepModel();
            _mainViewModel = new FoodPrepViewModel(_model);
            _itemsViewModel = new ItemsViewModel(_model);

            _mainViewModel.IngredientSelected += _mainViewModel_IngredientSelected;
            _mainViewModel.DishSelected += _mainViewModel_DishSelected;

            _rootPage = new NavigationPage(new MainPage());
            _rootPage.BindingContext = _mainViewModel;
            MainPage = _rootPage;
        }

        // viewModel event handlers
        private async void _mainViewModel_IngredientSelected(object sender, EventArgs e)
        {
            if (!(_rootPage.CurrentPage is IngredientsPage))
                await _rootPage.Navigation.PushAsync(new IngredientsPage(_itemsViewModel));
        }

        private async void _mainViewModel_DishSelected(object sender, EventArgs e)
        {
            if (!(_rootPage.CurrentPage is DishesPage))
                await _rootPage.Navigation.PushAsync(new DishesPage(_itemsViewModel));
        }
    }
}