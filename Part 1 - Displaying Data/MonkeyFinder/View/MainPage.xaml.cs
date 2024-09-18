namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel _ViewModel)
	{
		InitializeComponent();
		BindingContext = _ViewModel;
	}
}

