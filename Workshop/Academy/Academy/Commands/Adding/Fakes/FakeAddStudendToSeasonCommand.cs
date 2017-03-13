using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Contracts;

namespace Academy.Commands.Adding.Fakes
{
    internal class FakeAddStudendToSeasonCommand : AddStudentToSeasonCommand
    {
        public FakeAddStudendToSeasonCommand(IAcademyFactory factory, IEngine engine) : 
            base(factory, engine)
        {
        }

        public IAcademyFactory Factory
        {
            get { return this.factory; }
        }

        public IEngine Engine
        {
            get { return this.engine; }
        }
    }
}
