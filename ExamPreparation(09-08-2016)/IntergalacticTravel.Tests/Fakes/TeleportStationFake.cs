using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Fakes
{
    public class TeleportStationFake : TeleportStation
    {
        public TeleportStationFake(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) : 
            base(owner, galacticMap, location)
        {
            this.Owner = owner;
            this.GalacticMap = galacticMap;
            this.Location = location;
            this.Resources = this.resources;
        }

        public IBusinessOwner Owner { get; }
        public IEnumerable<IPath> GalacticMap { get; }
        public ILocation Location { get; }
        public IResources Resources { get; }
    }
}
