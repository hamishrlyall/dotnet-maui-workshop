using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new( );
    public MonkeysViewModel( MonkeyService _MonkeyService )
    {
        Title = "Monkey Finder";
        monkeyService = _MonkeyService;
    }

    [RelayCommand]
    private async Task GoToDetailsAsync( Monkey _Monkey )
    {
        if( _Monkey is null )
            return;

        await Shell.Current.GoToAsync( $"{nameof(DetailsPage)}", true, 
            new Dictionary<string, object>
            {
                { "Monkey", _Monkey }
            } 
        );
    }

    [RelayCommand]
    private async Task GetMonkeysAsync( )
    {
        if( IsBusy )
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys( );

            if( monkeys.Count != 0 )
                Monkeys.Clear( );

            foreach( var monkey in monkeys )
                Monkeys.Add( monkey );
        }
        catch( Exception _Ex )
        {
            Debug.WriteLine( _Ex );

            await Shell.Current.DisplayAlert( "Error!",
                $"Unable to get monkeys: {_Ex.Message}", "Ok" );
        }
        finally
        {
            IsBusy = false;
        }
    }
}
