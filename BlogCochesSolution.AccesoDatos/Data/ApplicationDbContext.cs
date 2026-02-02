using BlogCochesSolution.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogCochesSolution.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {            
        }

        // Aquí irán los DbSet más adelante
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }

}
