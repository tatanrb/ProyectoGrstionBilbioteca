using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_Biblioteca.Utilidades;

namespace Gestion_de_Biblioteca.Entidades
{
    public abstract class Biblioteca
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoPublicacion { get; set; }
        public EstadoLibro Estado { get; set; }

        public Biblioteca(string titulo, string autor, int añoPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            AñoPublicacion = añoPublicacion;
            Estado = EstadoLibro.Disponible;
        }

        public virtual void MostrarInformacion()
        {
            Console.Write($"\nTítulo: {Titulo}\nAutor: {Autor}\nAño de Publicación: {AñoPublicacion}\nEstado: {Estado}\n");
        }

        public void CambiarEstado(EstadoLibro estado)
        {
            Estado = estado;
            Console.WriteLine($"El estado ha cambiado a {Estado} correctamente");
        }

        public abstract void ActualizarInformación();
    }
}




