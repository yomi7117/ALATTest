using ALATTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Domain.DBContext
{
    public class ALATDBContext : DbContext
    {
        //public ALATDBContext()
        //{

        //}

        public ALATDBContext(DbContextOptions<ALATDBContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> LGA { get; set; }
        public DbSet<OTP> OTP { get; set; }
    }

}
