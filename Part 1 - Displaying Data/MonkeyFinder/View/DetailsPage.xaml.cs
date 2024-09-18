namespace MonkeyFinder;

public partial class DetailsPage : ContentPage
{
	public DetailsPage( MonkeyDetailsViewModel _ViewModel )
	{
		InitializeComponent();
		BindingContext = _ViewModel;
	}

    protected override void OnNavigatedTo( NavigatedToEventArgs args )
    {
        base.OnNavigatedTo( args );
    }
}