using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AeroAPI.Model;

namespace AeroAPI.Models
{
    public class AeroAPIContext : DbContext
    {
        public AeroAPIContext (DbContextOptions<AeroAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AeroAPI.Model.Passageiro> Passageiro { get; set; }
    }
}
