namespace FoodPrepApp.ViewModel
{
    public class FoodPrepViewModel : BindingSource
    {
        // fields
        private Model.FoodPrepModel _model;
        private int _numOfDishes;
        private int _numOfIngredients;

        public int NumOfDishes
        {
            get => _numOfDishes;
            private set
            {
                if (value != _numOfDishes)
                {
                    _numOfDishes = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NumOfIngredients
        {
            get => _numOfIngredients;
            private set
            {
                if (value != _numOfIngredients)
                {
                    _numOfIngredients = value;
                    OnPropertyChanged();
                }
            }
        }

        // constructor
        public FoodPrepViewModel(Model.FoodPrepModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");
            _numOfDishes = _model.getNumOfDishes();
            _numOfIngredients = _model.getNumOfIngredients();
        }
    }
}