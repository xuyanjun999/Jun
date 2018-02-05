using Jun.Domain.Entity.Sys;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jun.DataMigrate
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuEntity m = new MenuEntity();
            using (MyDbContext context=new MyDbContext())
            {
                context.Database.Migrate();
            }
        }
    }

    abstract class Test2<T> where T:class
    {

    }

    class MyClass:Test2<MenuEntity>
    {

    }
}
