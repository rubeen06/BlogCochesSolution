using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCochesSolution.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Articulo> ListArticulos { get; set; }

        //Páginación del inicio
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
