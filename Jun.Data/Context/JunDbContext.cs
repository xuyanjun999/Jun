using Jun.Core.Dependency;
using Jun.Core.Reflection;
using Jun.Domain.Entity.Org;
using Jun.Domain.Entity.Sys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Data.Context
{
    public class JunDbContext : DbContext
    {

        public DbSet<MenuEntity> Menus { get; set; }

        public DbSet<CompanyEntity> Companys { get; set; }

        public JunDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typeFinder = IocManager.Instance.Resolve<ITypeFinder>();

            var typeMaps = typeFinder.Find(typeof(IEntityTypeConfiguration<>));

            foreach (var typeMap in typeMaps)
            {
                if (typeMap.FullName.Contains("EntityConfigurationBase"))
                    continue;
                if (typeMap.FullName.Contains("Microsoft.EntityFrameworkCore"))
                    continue;
                dynamic map = Activator.CreateInstance(typeMap);
                modelBuilder.ApplyConfiguration(map);
            }

            base.OnModelCreating(modelBuilder);
        }

        public string GetTableName(Type type)
        {
            return this.Model.FindEntityType(type).Relational().TableName;
        }
    }
}
