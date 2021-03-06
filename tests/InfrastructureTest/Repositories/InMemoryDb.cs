using Microsoft.EntityFrameworkCore;
using System;

namespace InfrastructureTest.Repositories
{
    public class InMemoryDb<T> where T : DbContext
    {
        private readonly DbContextOptionsBuilder<T> _builder;

        public InMemoryDb()
        {
            _builder = new DbContextOptionsBuilder<T>();
            _builder.UseInMemoryDatabase($"test_{Guid.NewGuid()}");
        }

        public DbContextOptions<T> GetOptions()
        {
            return _builder.Options;
        }
    }
}
