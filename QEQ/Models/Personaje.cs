﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Personaje
    {
        private int _IdPers;
        private string _Nombre;
        private int _fkCategoria;

        public int IdPers { get => _IdPers; set => _IdPers = value; }
        [Required]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        [Required]
        public int FkCategoria { get => _fkCategoria; set => _fkCategoria = value; }

    public Personaje(int IdPers, string Nombre, int fkCategoria)
        {
            this.IdPers = IdPers;
            this.Nombre = Nombre;
            FkCategoria = fkCategoria;
        }

        public Personaje()
        {
            IdPers = 0;
            Nombre = "";
            FkCategoria = 0;
        }
    }
}