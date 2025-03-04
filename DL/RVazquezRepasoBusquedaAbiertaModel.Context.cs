﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RVazquezLibrosEntities : DbContext
    {
        public RVazquezLibrosEntities()
            : base("name=RVazquezLibrosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Libro> Libroes { get; set; }
    
        public virtual int LibroAdd(string autor, string tituloLibro, string añoPublicacion, string editorial)
        {
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            var tituloLibroParameter = tituloLibro != null ?
                new ObjectParameter("TituloLibro", tituloLibro) :
                new ObjectParameter("TituloLibro", typeof(string));
    
            var añoPublicacionParameter = añoPublicacion != null ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(string));
    
            var editorialParameter = editorial != null ?
                new ObjectParameter("Editorial", editorial) :
                new ObjectParameter("Editorial", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", autorParameter, tituloLibroParameter, añoPublicacionParameter, editorialParameter);
        }
    
        public virtual int LibroDeleteByAutor(string autor)
        {
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDeleteByAutor", autorParameter);
        }
    
        public virtual int LibroDeleteByEditorial(string editorial)
        {
            var editorialParameter = editorial != null ?
                new ObjectParameter("Editorial", editorial) :
                new ObjectParameter("Editorial", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDeleteByEditorial", editorialParameter);
        }
    
        public virtual ObjectResult<LibroGetByAutor_Result> LibroGetByAutor(string autor)
        {
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetByAutor_Result>("LibroGetByAutor", autorParameter);
        }
    
        public virtual ObjectResult<LibroGetByAutorFecha_Result> LibroGetByAutorFecha(string autor, string fecha)
        {
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            var fechaParameter = fecha != null ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetByAutorFecha_Result>("LibroGetByAutorFecha", autorParameter, fechaParameter);
        }
    
        public virtual ObjectResult<LibroGetByEditorial_Result> LibroGetByEditorial(string editorial)
        {
            var editorialParameter = editorial != null ?
                new ObjectParameter("Editorial", editorial) :
                new ObjectParameter("Editorial", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetByEditorial_Result>("LibroGetByEditorial", editorialParameter);
        }
    
        public virtual ObjectResult<LibroGetByFecha_Result> LibroGetByFecha(string fecha)
        {
            var fechaParameter = fecha != null ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetByFecha_Result>("LibroGetByFecha", fechaParameter);
        }
    
        public virtual ObjectResult<LibroGetByTitulo_Result> LibroGetByTitulo(string tituloLibro)
        {
            var tituloLibroParameter = tituloLibro != null ?
                new ObjectParameter("TituloLibro", tituloLibro) :
                new ObjectParameter("TituloLibro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetByTitulo_Result>("LibroGetByTitulo", tituloLibroParameter);
        }
    }
}
