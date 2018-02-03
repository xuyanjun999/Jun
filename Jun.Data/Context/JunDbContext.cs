using Jun.Core.Dependency;
using Jun.Core.Reflection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Data.Context
{
    public class JunDbContext : DbContext
    {
        public JunDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typeFinder = IocManager.Instance.Resolve<ITypeFinder>();

            var typeMaps = typeFinder.Find(x => typeof(IEntityTypeConfiguration<>).IsAssignableFrom(x));

            foreach (var typeMap in typeMaps)
            {
                if (typeMap.FullName.Contains("EntityConfigurationBase"))
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
