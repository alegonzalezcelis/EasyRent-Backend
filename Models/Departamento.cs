using System;
// using System.ComponentModel.DataAnnotations;


// Agregar Data Anotations para futuras validaciones
namespace contactos.Models
{
    public class Departamento
    {
        public long? id {get; set;}

        public string nombre {get; set;}
        public string descripcion {get; set;}

        public string tamanio {get; set;}

        public string ubicacion {get; set;}

        public string precio {get; set;}

        public string condiciones {get; set;}

        public Boolean estado {get; set;}
    }
}