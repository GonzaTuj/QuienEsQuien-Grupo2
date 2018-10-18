using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Personaje
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        private string _Nombre;
        [Required(ErrorMessage = "Campo obligatorio.")]
        private int _Categoria;

        public Personaje(string Nombre, int Categoria)
        {
            _Nombre = Nombre;
            _Categoria = Categoria;
        }

        public Personaje()
        {
            _Nombre = "";
            _Categoria = 0;
        }

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Categoria { get => _Categoria; set => _Categoria = value; }
    }
}