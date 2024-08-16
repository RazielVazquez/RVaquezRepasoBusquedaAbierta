using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static Dictionary<string, object> Add(ML.Libro libro)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false }
            };

            try
            {
                using(DL.RVazquezLibrosEntities context = new DL.RVazquezLibrosEntities())
                {
                    int librosAgregados = context.LibroAdd(
                        libro.Autor,
                        libro.TituloLibro,
                        libro.AñoPublicacion,
                        libro.Editorial);

                    if(librosAgregados > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> GetByAutor(string autor)
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false },
                { "Libro", libro }
            };

            try
            {
                using (DL.RVazquezLibrosEntities context = new DL.RVazquezLibrosEntities())
                {
                    var registros = context.LibroGetByAutor(autor).ToList();

                    if( registros != null)
                    {
                        libro.Libros = new List<ML.Libro>();

                        foreach( var registro in registros)
                        {
                            ML.Libro book = new ML.Libro();

                            book.IdLibro = registro.IdLibros;
                            book.Autor = registro.Autor;
                            book.TituloLibro = registro.TituloLibro;
                            book.AñoPublicacion = registro.AñoPublicacion;
                            book.Editorial = registro.Editorial;

                            libro.Libros.Add( book );
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch(Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> GetByTitulo(string titulo)
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false },
                { "Libro", libro }
            };

            try
            {
                using(DL.RVazquezLibrosEntities contex = new DL.RVazquezLibrosEntities())
                {
                    var registros = contex.LibroGetByTitulo(titulo).ToList();

                    if(registros != null)
                    {
                        libro.Libros = new List<ML.Libro>();

                        foreach(var registro in registros)
                        {
                            ML.Libro book = new ML.Libro();

                            book.IdLibro = registro.IdLibros;
                            book.Autor = registro.Autor;
                            book.TituloLibro = registro.TituloLibro;
                            book.AñoPublicacion = registro.AñoPublicacion;
                            book.Editorial = registro.Editorial;

                            libro.Libros.Add(book);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> GetByAutorFecha(string autor, string fecha)
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false },
                { "Libro", libro }
            };

            try
            {
                using (DL.RVazquezLibrosEntities contex = new DL.RVazquezLibrosEntities())
                {
                    var registros = contex.LibroGetByAutorFecha(autor, fecha).ToList();

                    if (registros != null)
                    {
                        libro.Libros = new List<ML.Libro>();

                        foreach (var registro in registros)
                        {
                            ML.Libro book = new ML.Libro();

                            book.IdLibro = registro.IdLibros;
                            book.Autor = registro.Autor;
                            book.TituloLibro = registro.TituloLibro;
                            book.AñoPublicacion = registro.AñoPublicacion;
                            book.Editorial = registro.Editorial;

                            libro.Libros.Add(book);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> GetByEditorial(string editorial)
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false },
                { "Libro", libro }
            };

            try
            {
                using (DL.RVazquezLibrosEntities contex = new DL.RVazquezLibrosEntities())
                {
                    var registros = contex.LibroGetByEditorial(editorial).ToList();

                    if (registros != null)
                    {
                        libro.Libros = new List<ML.Libro>();

                        foreach (var registro in registros)
                        {
                            ML.Libro book = new ML.Libro();

                            book.IdLibro = registro.IdLibros;
                            book.Autor = registro.Autor;
                            book.TituloLibro = registro.TituloLibro;
                            book.AñoPublicacion = registro.AñoPublicacion;
                            book.Editorial = registro.Editorial;

                            libro.Libros.Add(book);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> DeleteByAutor(string autor)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false }
            };

            try
            {
                using(DL.RVazquezLibrosEntities context = new DL.RVazquezLibrosEntities())
                {
                    int librosEliminados = context.LibroDeleteByAutor(autor);

                    if(librosEliminados > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> DeleteByEditorial(string editorial)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Excepcion", "" },
                { "Resultado", false }
            };

            try
            {
                using (DL.RVazquezLibrosEntities context = new DL.RVazquezLibrosEntities())
                {
                    int librosEliminados = context.LibroDeleteByEditorial(editorial);

                    if (librosEliminados > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
    }
}
