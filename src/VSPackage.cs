using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace OpenInGVim
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(Options), "VsVim", Vsix.Name, 101, 102, true, new string[0], ProvidesLocalizedCategoryName = false)]
    [Guid(PackageGuids.guidPackageString)]
    public sealed class VSPackage : Package
    {
        protected override void Initialize()
        {
            var options = (Options)GetDialogPage(typeof(Options));

            Logger.Initialize(this, Vsix.Name);
            OpenVimCommand.Initialize(this, options);
        }
    }
}
