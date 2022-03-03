
using ALATTest.Domain.DBContext;
using ALATTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ALATTest.Domain
{
    public class SeedingService
    {
       
        public static void AutoSeedStateandLGA(ALATDBContext context)
        { 
       

            if (context.States.Any())
                return; //DB has been seeded with language data
            int s = 1;
            var states = new State[]
            {
                new State{ Id = s++, Name ="Not Available"},
                new State{ Id = s++, Name ="Akwa Ibom" },
                new State{ Id = s++, Name ="Anambra" },
                new State{ Id = s++, Name ="Bauchi"},
                new State{ Id = s++, Name ="Adamawa"},
                new State{ Id = s++, Name ="Benue"},
                new State{ Id = s++, Name ="Borno"},
                new State{ Id = s++, Name ="Cross River"},
                new State{ Id = s++, Name ="FCT"},
                new State{ Id = s++, Name ="Delta"},
                new State{ Id = s++, Name ="Imo"},
                new State{ Id = s++, Name ="Kaduna"},
                new State{ Id = s++, Name ="Kano"},
                new State{ Id = s++, Name ="Katsina"},
                new State{ Id = s++, Name ="Kwara"},
                new State{ Id = s++, Name ="Lagos"},
                new State{ Id = s++, Name ="Niger"},
                new State{ Id = s++, Name ="Ogun"},
                new State{ Id = s++, Name ="Ondo"},
                new State{ Id = s++, Name ="Oyo"},
                new State{ Id = s++, Name ="Plateau"},
                new State{ Id = s++, Name ="Rivers"},
                new State{ Id = s++, Name ="Sokoto"},
                new State{ Id = s++, Name ="Abia"},
                new State{ Id = s++, Name ="Edo"},
                new State{ Id = s++, Name ="Enugu"},
                new State{ Id = s++, Name ="Jigawa"},
                new State{ Id = s++, Name ="Kebbi"},
                new State{ Id = s++, Name ="Kogi"},
                new State{ Id = s++, Name ="Osun"},
                new State{ Id = s++, Name ="Taraba"},
                new State{ Id = s++, Name ="Yobe"},
                new State{ Id = s++, Name ="Bayelsa"},
                new State{ Id = s++, Name ="Ebonyi"},
                new State{ Id = s++, Name ="Ekiti"},
                new State{ Id = s++, Name ="Gombe"},
                new State{ Id = s++, Name ="Nassarawa"},
                new State{ Id = s++, Name ="Zamfara"}
            };
            context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            context.States.AddRange(states);
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.States ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.States OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            

        }

       
      
    }
}
