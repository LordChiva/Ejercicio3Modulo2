using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            var options = new DbContextOptionsBuilder<BDContext>();
            options.UseSqlServer("Data Source=CHIVA-SYSTEM\\SQLEXPRESS;Initial Catalog=SimpleIMDB;Integrated Security=True;Encrypt=False");
            var context = new BDContext(options.Options);
            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            var result = context.Actor.ToList();

            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor
            var obtenerActrices = context.Actor.Where(actrices => actrices.Genero == "F");
            #endregion

            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor
            var obtenerMayores50 = context.Actor.Where(mayores => mayores.Edad > 50);
            #endregion

            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"
            var verEdadJulia = context.Actor
                .Where(julia => julia.NombreArtistico == "Pretty Woman")
                .Select(j => j.Edad).ToList();

            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.

            Actor nuevoActor = new Actor() { Nombre = "Ricardo", Apellido = "Darin", Edad = 67, NombreArtistico = "Ricardo Darin", Nacionalidad = "argentino", Genero = "M" };

            context.Actor.Add( nuevoActor );

            context.SaveChanges();

            var check = context.Actor.ToList();
            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.
            var verCantActores = context.Actor
                .Where(from => from.Nacionalidad != "USA")
                .Count();
            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.

            //aca me quedo la duda de por qué trae 2 veces el nombre y el apellido
            var verActoresMasc = context.Actor
                .Where(gen => gen.Genero == "M")
                .Select(actores => new {actores.Nombre, actores.Apellido}).ToList();
            #endregion
        }
    }
}