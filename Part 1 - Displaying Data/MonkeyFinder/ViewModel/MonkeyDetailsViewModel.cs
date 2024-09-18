namespace MonkeyFinder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    public MonkeyDetailsViewModel( ) 
    {
    }

    [ObservableProperty]
    Monkey _Monkey;

    private async Task GoBackAsync( )
    {
        await Shell.Current.GoToAsync( ".." );
    }
}
