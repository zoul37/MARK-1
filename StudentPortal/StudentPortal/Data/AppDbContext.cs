﻿using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
namespace StudentPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { modelBuilder.Entity<Student>().ToTable("Students"); }
    }
            
                
}
