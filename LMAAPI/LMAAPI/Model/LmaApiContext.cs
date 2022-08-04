using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMAAPI.Model
{
    public class LmaApiContext : DbContext
    {


        
        public LmaApiContext(DbContextOptions<LmaApiContext> options)
            : base(options)
        {
        }
        public DbSet<Login> Logins { get; set; }

    }
}