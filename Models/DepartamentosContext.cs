using Microsoft.EntityFrameworkCore;

namespace contactos.Models
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options)
            : base(options)
            {

            }
            public DbSet<Departamento> Departamento {get; set;}
            public DbSet<User> User {get; set;}
    }
}