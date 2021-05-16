using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.ApplicationService.Interfaces.Mapper
{
    public abstract class AbstractMapper<Tin,Tout> : IMapper<Tin, Tout>
    {
        protected Tin _input;
        public IMapper<Tin, Tout> Map(Tin input)
        {
            _input = input;
            return this;
        }

        public abstract Tout ToOutFormat();
    }
}
