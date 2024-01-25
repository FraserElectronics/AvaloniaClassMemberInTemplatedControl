using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintManager.ViewModels
{
    public interface IMainViewModel
    {
        // ###########################################################################################################
        // # Relay Commands
        // ###########################################################################################################
        #region Relay Commands

        /// <summary>
        /// The method that is called when the user clicks the Find Fingerprint Module button.
        /// </summary>
        Task FindFingerprintModule();

        #endregion Relay Commands
    }
}
