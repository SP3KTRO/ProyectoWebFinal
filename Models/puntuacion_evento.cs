//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoWebFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class puntuacion_evento
    {
        public int id_puntuacion { get; set; }
        public int puntuacion { get; set; }
        public string comentarios { get; set; }
        public int id_evento { get; set; }
        public int cedula_cli { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual evento evento { get; set; }
    }
}
