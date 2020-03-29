using System;
using Microsoft.EntityFrameworkCore;

namespace data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

    }
}
