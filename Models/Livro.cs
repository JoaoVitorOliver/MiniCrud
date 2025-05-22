using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Livro
    {
        public int Id { get; set; } 
        public string? Titulo { get; set; } 
        public string? Autor { get; set; } 
        public string? Genero { get; set; } 
        public double Preco { get; set; } 
        public int Quantidade { get; set; } 
    }
}