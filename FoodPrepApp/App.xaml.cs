using FoodPrepApp.Model;
using FoodPrepApp.Persistence;
using FoodPrepApp.ViewModel;

namespace FoodPrepApp
{
    public partial class App : Application
    {
        private NavigationPage _rootPage;
        private FoodPrepModel _model;
        private FoodPrepViewModel _mainViewModel;
        private ItemsViewModel _itemsViewModel;
        private NewItemViewModel _newItemViewModel;
        private IFoodPrepAppPersistence _persistence;

        public App()
        {
            InitializeComponent();
            _persistence = new Persistence.JSON.JSONSaveLoader();
            _model = new FoodPrepModel(_persistence);

            _model.DataLoadFailed += OnDataLoadFailed;
            _model.DataSaveFailed += OnDataSaveFailed;

            _rootPage = new NavigationPage(new MainPage());
            MainPage = _rootPage;
        }


        protected override async void OnStart()
        {
            await InitAsync();

            base.OnStart();
        }

        private async Task InitAsync()
        {
            var dataLoaded = await _model.LoadDataAsync();
            if (dataLoaded)
            {
                _mainViewModel = new FoodPrepViewModel(_model);
                _itemsViewModel = new ItemsViewModel(_model);
                _newItemViewModel = new NewItemViewModel(_model);

                _mainViewModel.IngredientSelected += _mainViewModel_IngredientSelected;
                _mainViewModel.DishSelected += _mainViewModel_DishSelected;
                _mainViewModel.NewItem += _mainViewModel_NewItem;
                _newItemViewModel.SaveCompleted += _newItemViewModel_Saved;

                _rootPage.BindingContext = _mainViewModel;
            }
            else
            {
                OnDataLoadFailed(this, EventArgs.Empty);
            }
        }
        /*
        protected override async void OnSleep()
        {
            await _model.SaveGameAsync();
            base.OnSleep();
        }
        protected override async void OnResume()
        {
            await _model.LoadGameAsync();
            base.OnResume();
        }
         */

        private async void _mainViewModel_NewItem(object sender, EventArgs e)
        {
            if (!(_rootPage.CurrentPage is NewItemPage))
                await _rootPage.Navigation.PushAsync(new NewItemPage(_newItemViewModel));
        }

        // event handlers
        private void OnDataLoadFailed(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.DisplayAlert("Error", "Failed to load data.", "OK");
            });
        }

        private void OnDataSaveFailed(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.DisplayAlert("Error", "Failed to save data.", "OK");
            });
        }

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

        private async void _newItemViewModel_Saved(object sender, EventArgs e)
        {
            //DisplayAlert("Success", "Item saved successfully", "OK");
            _itemsViewModel = new ItemsViewModel(_model);
            await _rootPage.PopAsync();
        }
    }
}