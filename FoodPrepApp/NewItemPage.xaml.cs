using FoodPrepApp.ViewModel;
namespace FoodPrepApp;

public partial class NewItemPage : ContentPage
{
	public NewItemPage(NewItemViewModel newItemViewModel)
	{
		InitializeComponent();
        BindingContext = newItemViewModel;
        newItemViewModel.ValidationErrorOccurred += OnValidationErrorOccurred;
    }

    private void OnValidationErrorOccurred(object sender, string message)
    {
        DisplayAlert("Hibás adat!", message, "OK");
    }
}