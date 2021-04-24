namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface IAppPackagesViewModel
    {
        bool SelectX64PackageEnabled { get; }
        bool SelectX86PackageEnabled { get; }
        bool SelectArmPackageEnabled { get; }
    }
}
