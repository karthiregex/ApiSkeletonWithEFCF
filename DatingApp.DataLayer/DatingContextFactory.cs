using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DatingApp.DataLayer
{
    public class DatingContextFactory : IDesignTimeDbContextFactory<DatingAppDbContext>
    {
        public IConfiguration Configuration { get; }
        public DatingAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatingAppDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnStr"));

            return new DatingAppDbContext(optionsBuilder.Options);
        }
    }
}
