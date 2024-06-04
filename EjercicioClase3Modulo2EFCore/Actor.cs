using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase3Modulo2EFCore
{
    public class Actor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreArtistico { get; set; }
        public int Edad { get; set;}
        public string Nacionalidad { get; set; }
        public string Genero { get; set; }

    }
}
