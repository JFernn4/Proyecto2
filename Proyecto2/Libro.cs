﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn  { get; set; }
        public string Genero { get; set; }
        public bool Disponibilidad { get; set; } 
        public Libro(string titulo, string autor, string iSBN, string genero, bool disponibilidad)
        { 
            Titulo = titulo;
            Autor = autor;
            Isbn = iSBN;
            Genero = genero;
            Disponibilidad = disponibilidad;
        }
        
    }
}

