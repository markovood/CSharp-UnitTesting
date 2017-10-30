using PackageManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.Fakes
{
    internal class InstallCommandFake : InstallCommand
    {
        public InstallCommandFake(IInstaller<IPackage> installer, IPackage package) :
            base(installer, package)
        {
            this.Installer = this.installer;
            this.Package = this.package;
        }

        public IInstaller<IPackage> Installer { get; }
        public IPackage Package { get; }
    }
}
