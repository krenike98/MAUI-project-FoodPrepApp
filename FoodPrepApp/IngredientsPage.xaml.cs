using FoodPrepApp.ViewModel;

namespace FoodPrepApp;

public partial class IngredientsPage : ContentPage
{
	public IngredientsPage(ItemsViewModel itemsViewModel)
	{
		InitializeComponent();
        BindingContext = itemsViewModel;
    }
}