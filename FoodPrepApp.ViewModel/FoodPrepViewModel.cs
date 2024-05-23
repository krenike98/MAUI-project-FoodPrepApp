namespace FoodPrepApp.ViewModel
{
    public class FoodPrepViewModel : BindingSource
    {
        // fields
        private Model.FoodPrepModel _model;
        private int _numOfDishes;
        private int _numOfIngredients;
        


        // properties
        public DelegateCommand NewButtonCommand { get; private set; }
        public DelegateCommand IngredientsButtonCommand { get; private set; }
        public DelegateCommand DishesButtonCommand { get; private set; }

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

        //events
        public event EventHandler? IngredientSelected;
        public event EventHandler? DishSelected;
        public event EventHandler? NewItem;

        // constructor
        public FoodPrepViewModel(Model.FoodPrepModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");
            _numOfDishes = _model.GetNumOfDishes();
            _numOfIngredients = _model.GetNumOfIngredients();
            IngredientsButtonCommand = new DelegateCommand(Command_Ingredients);
            DishesButtonCommand = new DelegateCommand(Command_Dishes);
            NewButtonCommand = new DelegateCommand(Command_New);
        }

        // command methods
        private void Command_Ingredients(object? param)
        {
            OnIngredientSelected();
        }

        private void Command_Dishes(object? param)
        {
            OnDishSelected();
        }

        private void Command_New(object? param)
        {
            NewItem?.Invoke(this, EventArgs.Empty);
        }



        // private methods
        private void OnIngredientSelected() => IngredientSelected?.Invoke(this, EventArgs.Empty);
        private void OnDishSelected() => DishSelected?.Invoke(this, EventArgs.Empty);
    }
}