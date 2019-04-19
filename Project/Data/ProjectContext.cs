using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Project.Models.Loja> Loja { get; set; }

        public DbSet<Project.Models.Roupa> Roupa { get; set; }

        public DbSet<Project.Models.Carrinho> Carrinho { get; set; }
    }
}
