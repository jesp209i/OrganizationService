using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Persistence.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly OrganizationDbContext _context;

        public RepositoryBase(OrganizationDbContext context)
        {
            _context = context;
        }
    }
}
