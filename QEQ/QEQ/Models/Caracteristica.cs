using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Caracteristica
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        private int _ID;
        [Required(ErrorMessage = "Campo obligatorio.")]
        private string _Nombre;
        [Required(ErrorMessage = "Campo obligatorio.")]
        private int _IDCategoria;
        [Required(ErrorMessage = "Campo obligatorio.")]
        private string _Pregunta;

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

        public int IDCategoria
        {
            get
            {
                return _IDCategoria;
            }

            set
            {
                _IDCategoria = value;
            }
        }

        public string Pregunta
        {
            get
            {
                return _Pregunta;
            }

            set
            {
                _Pregunta = value;
            }
        }

        public Caracteristica()
        {
            _ID = ID;
            _Nombre = Nombre;
            _IDCategoria = IDCategoria;
            _Pregunta = Pregunta;
        }

        public Caracteristica(int ID, string Nombre, int IDCategoria, string Pregunta)
        {
            _ID = ID;
            _Nombre = Nombre;
            _IDCategoria = IDCategoria;
            _Pregunta = Pregunta;
        }
    }
}
