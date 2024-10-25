using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_en_duo_
{
    internal class Libro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string isbn  { get; set; }
        public string genero { get; set; }
        public bool disponibilidad { get; set; } 
        public Libro(string Titulo, string Autor, string ISBN, string Genero, bool Disponibilidad)
        { 
            titulo = Titulo;
            autor = Autor;
            isbn = ISBN;
            genero = Genero;
            disponibilidad = Disponibilidad;
        }
        
    }
}

