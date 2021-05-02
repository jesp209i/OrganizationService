using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.Enum
{
    public enum Permission
    {
        SuperAdmin = 0,
        Admin = 1,
        ReadWrite = 2,
        ReadOnly = 3,
        NoAccess = 4,
        Undefined = 10
    }
}
