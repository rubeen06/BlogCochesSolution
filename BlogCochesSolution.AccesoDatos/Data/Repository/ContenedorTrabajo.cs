using BlogCochesSolution.AccesoDatos.Data.Repository.IRepository;
using BlogCochesSolution.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCochesSolution.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(
        ApplicationDbContext db, 
        UserManager<ApplicationUser> userManager
        )
    {
        _db = db;

        Categoria = new CategoriaRepository(_db);
        Articulo = new ArticuloRepository(_db);
        Slider = new SliderRepository(_db);
        Usuario = new UsuarioRepository(_db, userManager);
    }

        public ICategoriaRepository Categoria {  get; private set; }
        public IArticuloRepository Articulo {  get; private set; }
        public ISliderRepository Slider {  get; private set; }
        public IUsuarioRepository Usuario {  get; private set; }
       

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
