using System;
using BDVTest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BDVTest.DAL
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<WorkSheetOne> WorkSheetOnes { get; set; }
        
        public DbSet<WorkSheetTwo> WorkSheetTwos { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
    }
}
