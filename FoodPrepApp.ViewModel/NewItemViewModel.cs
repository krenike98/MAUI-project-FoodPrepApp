using FoodPrepApp.Persistence;

namespace FoodPrepApp.ViewModel
{
    public class NewItemViewModel: BindingSource
    {
        //fields
        private Model.FoodPrepModel _model;
        private bool _isIngredient;
        private bool _isDish;
        private string _name;
        private DateTime _expDate;
        private string _desc;
        private int _numOfPortions;


        // properties
        public bool IsIngredient
        {
            get => _isIngredient;
            set
            {
                if (value != _isIngredient)
                {
                    _isIngredient = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDish
        {
            get => _isDish;
            set
            {
                if (value != _isDish)
                {
                    _isDish = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime ExpDate
        {
            get => _expDate;
            set
            {
                if (value != _expDate)
                {
                    _expDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Desc
        {
            get => _desc;
            set
            {
                if (value != _desc)
                {
                    _desc = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NumOfPortions
        {
            get => _numOfPortions;
            set
            {
                if (value != _numOfPortions)
                {
                    _numOfPortions = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand ImageCommand { get; private set; }
        public DelegateCommand SaveNewItemCommand { get; private set; }

        //eventhandlers
        public event EventHandler SaveCompleted;
        public event EventHandler<string> ValidationErrorOccurred;

        private void OnValidationError(string message)
        {
            ValidationErrorOccurred?.Invoke(this, message);
        }

        private void OnSaveCompleted()
        {
            SaveCompleted?.Invoke(this, EventArgs.Empty);
        }


        //ctor
        public NewItemViewModel(Model.FoodPrepModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");

            SaveNewItemCommand = new DelegateCommand(Command_Save);
            ImageCommand = new DelegateCommand(Command_Image);
        }

        private void Command_Save(object obj)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                OnValidationError("Megnevezés megadása kötelező!");
                return;
            }

            if (ExpDate <= DateTime.Now)
            {
                OnValidationError("A lejárati dátum nem lehet a jelenlegi dátumnál korábbi!");
                return;
            }

            if (NumOfPortions < 1)
            {
                OnValidationError("Az adagok száma nem lehet kisebb egynél!");
                return;
            }

            Item item = Item.CreateItem(Name, ExpDate, NumOfPortions, Desc);
            if (_isDish)
                _model.items.dishes.Add(item);
            else
                _model.items.ingredients.Add(item);
            OnSaveCompleted();
        }
        private void Command_Image(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
