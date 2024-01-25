using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

using R503FingerprintComms.Interfaces;

using System.Threading.Tasks;

namespace FingerprintManager.ViewModels;

public partial class MainViewModel : ViewModelBase, IMainViewModel
{
    // ###########################################################################################################
    // # Relay Commands
    // ###########################################################################################################
    #region Relay Commands

    /// <summary>
    /// The method that is called when the user clicks the Find Fingerprint Module button.
    /// </summary>
    [RelayCommand]
    public async Task FindFingerprintModule()
    {
        if ( _comms != null )
        {
            await _comms.InitialiseR503Async( "COM9" );
        }
    }

    #endregion Relay Commands

    // ###########################################################################################################
    // # Constructor
    // ###########################################################################################################
    #region Constructor

    public MainViewModel()
    {
        _comms = App.Current?.Services?.GetService<IR503Comms>();
    }

    #endregion Constructor

    // ###########################################################################################################
    // # Fields
    // ###########################################################################################################
    #region Fields

    private IR503Comms? _comms;

    #endregion Fields
}
