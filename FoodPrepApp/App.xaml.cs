using FoodPrepApp.Model;
using FoodPrepApp.ViewModel;

namespace FoodPrepApp
{
    public partial class App : Application
    {
        private NavigationPage _rootPage;
        private FoodPrepModel _model;
        private FoodPrepViewModel _mainViewModel;
        public App()
        {
            InitializeComponent();
            _model = new FoodPrepModel();
            _mainViewModel = new FoodPrepViewModel(_model);

            _rootPage = new NavigationPage(new MainPage());
            _rootPage.BindingContext = _mainViewModel;
            MainPage = _rootPage;
        }


    }
}