using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF
{
    /// <summary>
    /// For Instantiating Parameterless PizzaPalaceDbContext Indirectly from the Business Logic
    /// </summary>
    public class PizzaPalaceDbContextFactory : IDesignTimeDbContextFactory<PizzaPalaceDbContext>
    {
        public PizzaPalaceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaPalaceDbContext>();

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Pizza_Palace;Trusted_Connection=True;");

            return new PizzaPalaceDbContext(optionsBuilder.Options);
        }
    }
}