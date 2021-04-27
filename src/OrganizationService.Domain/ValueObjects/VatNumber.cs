using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class VatNumber
    {
        public string VatNumberString { get; private set; }
        
        public VatNumber(string vatNumber)
        {
            VatNumberString = vatNumber;
        }

        public static implicit operator string(VatNumber self) => self.VatNumberString;
    }
}
