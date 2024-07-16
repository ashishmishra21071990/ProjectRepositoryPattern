﻿using Microsoft.EntityFrameworkCore;
using RepositoryPatternMohit.Models;

namespace RepositoryPatternMohit.Repository.Services
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
