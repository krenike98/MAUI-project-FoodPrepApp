using FoodPrepApp.ViewModel;
namespace FoodPrepApp;

public partial class DishesPage : ContentPage
{
	public DishesPage(ItemsViewModel itemsViewModel)
	{
		InitializeComponent();
        BindingContext = itemsViewModel;
    }
}