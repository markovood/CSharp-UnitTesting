using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Repositories.FakesAndCustomExceptions
{
    public class PackageRepositoryFake : PackageRepository
    {
        public PackageRepositoryFake(ILogger logger, ICollection<IPackage> packages = null) :
            base(logger, packages)
        {
            this.Packages = this.packages;
            this.Logger = this.logger;
        }

        public ICollection<IPackage> Packages { get; }

        public ILogger Logger { get; }

        public override bool Update(IPackage package)
        {
            throw new UpdateMethodCalledException("Update method was called");
        }
    }
}
