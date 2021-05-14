﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly OrganizationDbContext _context;
        public DbSet<T> DbData { get; set; }

        public RepositoryBase(OrganizationDbContext context)
        {
            _context = context;
            DbData = _context.Set<T>();
        }
    }
}
