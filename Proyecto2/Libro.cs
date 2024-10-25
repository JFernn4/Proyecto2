using System;
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
        public Libro(string Titulo, string Autor, string ISBN, string Genero, bool Disponibilidad)
        { 
            Titulo = Titulo;
            Autor = Autor;
            Isbn = ISBN;
            Genero = Genero;
            Disponibilidad = Disponibilidad;
        }
        
    }
}

