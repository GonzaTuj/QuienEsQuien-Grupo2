using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace QEQ.Models
{
    public class CategoriaCaracteristica
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        private int _ID;
        [Required(ErrorMessage = "Campo obligatorio.")]
        private string _Nombre;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public CategoriaCaracteristica()
        {
            _ID = ID;
            _Nombre = Nombre;
        }

        public CategoriaCaracteristica(int ID, string Nombre)
        {
            _ID = ID;
            _Nombre = Nombre;
        }
    }
}