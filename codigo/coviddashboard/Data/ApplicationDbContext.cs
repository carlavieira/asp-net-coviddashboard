using System;
using System.Collections.Generic;
using System.Text;
using app_aspnet_core.Models;
using coviddashboard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace coviddashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<CovidData> CovidData { get; set; }
    }
}
