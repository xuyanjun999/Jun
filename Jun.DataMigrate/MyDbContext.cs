using Jun.Core.Reflection;
using Jun.Domain.Entity;
using Jun.Domain.Entity.Sys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.DataMigrate
{
   public class MyDbContext:DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("charset=utf8;server=47.94.140.80;UID=root;PWD=sa!123456;Database=eap");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typeFinder = new TypeFinder();


            //var fun = new Func<Type, bool>(x=>typeof(IEntityTypeConfiguration<>).IsAssignableFrom(x)||(x.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, x));
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
