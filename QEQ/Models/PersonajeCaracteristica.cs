﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class PersonajeCaracteristica
    {
        private int _fkPersonaje;
        private int _fkCaracteristica;
        private string _NombreCaracteristica;
        private bool _Checked;

        public int fkPersonaje
        {
            get
            {
                return _fkPersonaje;
            }

            set
            {
                _fkPersonaje = value;
            }
        }

        public int fkCaracteristica
        {
            get
            {
                return _fkCaracteristica;
            }

            set
            {
                _fkCaracteristica = value;
            }
        }

        public string NombreCaracteristica
        {
            get
            {
                return _NombreCaracteristica;
            }

            set
            {
                _NombreCaracteristica = value;
            }
        }

        public bool Checked
        {
            get
            {
                return _Checked;
            }

            set
            {
                _Checked = value;
            }
        }

        public PersonajeCaracteristica()
        {
            _fkPersonaje = fkPersonaje;
            _fkCaracteristica = fkCaracteristica;
            _NombreCaracteristica = NombreCaracteristica;
            _Checked = Checked; 
        }

        public PersonajeCaracteristica(int fkPersonaje, int fkCaracteristica, string NombreCaracteristica, bool Checked)
        {
            _fkPersonaje = fkPersonaje;
            _fkCaracteristica = fkCaracteristica;
            _NombreCaracteristica = NombreCaracteristica;
            _Checked = Checked; 
        }
    }
}