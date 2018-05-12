using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.Fakes
{
    internal class PackageInstallerFake : PackageInstaller
    {
        public PackageInstallerFake(IDownloader downloader, IProject project) :
            base(downloader, project)
        {
        }

        public int NumberOfPackages { get; private set; }

        public override void PerformOperation(IPackage package)
        {
            this.NumberOfPackages++;
        }
    }
}
