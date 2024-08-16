using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class LibroController : ApiController
    {
        [HttpPost]
        [Route("api/Libro/Add")]
        public IHttpActionResult Add(ML.Libro libro)
        {
            Dictionary<string, object> result = BL.Libro.Add(libro);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)result["Excepcion"]);
            }
        }

        [HttpGet]
        [Route("api/Libro/GetByAutor/{autor}")]
        public IHttpActionResult GetByAutor(string autor)
        {
            if(autor == null)
            {
                autor = "";
            }

            Dictionary<string, object> result = BL.Libro.GetByAutor(autor);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                ML.Libro libro = new ML.Libro();
                libro = (ML.Libro)result["Libro"];
                return Content(HttpStatusCode.OK, libro);
            }
            else
            {
                string excepcion = (string)result["Excepcion"];
                return BadRequest(excepcion);
            }
        }

        [HttpGet]
        [Route("api/Libro/GetByTitulo/{titulo}")]
        public IHttpActionResult GetByTitulo(string titulo)
        {
            Dictionary<string, object> result = BL.Libro.GetByTitulo(titulo);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                ML.Libro libro = (ML.Libro)result["Libro"];
                return Content(HttpStatusCode.OK, libro);
            }
            else
            {
                string excepcion = (string)result["Excepcion"];
                return BadRequest(excepcion);
            }
        }

        [HttpGet]
        [Route("api/Libro/GetByAutorFecha/{autor}/{fecha}")]
        public IHttpActionResult GetByAutorFecha(string autor, string fecha)
        {
            Dictionary<string,object> result = BL.Libro.GetByAutorFecha(autor, fecha);
            bool resultado = (bool)result["Resultado"];

            if(resultado)
            {
                ML.Libro libro = (ML.Libro)result["Libro"];
                return Content(HttpStatusCode.OK, libro);
            }
            else
            {
                string excpecion = (string)result["Excepcion"];
                return BadRequest(excpecion);
            }
        }

        [HttpGet]
        [Route("api/libro/GetByEditorial/{editorial}")]
        public IHttpActionResult GetByEditorial(string editorial)
        {
            Dictionary<string, object> result = BL.Libro.GetByEditorial(editorial);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                ML.Libro libro = (ML.Libro)result["Libro"];
                return Content(HttpStatusCode.OK, libro);
            }
            else
            {
                string excepcion = (string)result["Excepcion"];
                return BadRequest(excepcion);
            }
        }

        [HttpDelete]
        [Route("api/Libro/DeleteByAutor/{autor}")]
        public IHttpActionResult DeleteByAutor(string autor)
        {
            Dictionary<string, object> result = BL.Libro.DeleteByAutor(autor);
            bool resultado = (bool)result["Resultado"];

            if(resultado == true || (string)result["Excepcion"] == "" )
            {
                return Ok(true);
            }
            else
            {
                return BadRequest((string)result["Excepcion"]);
            }
        }

        [HttpDelete]
        [Route("api/Libro/DeleteByEditorial/{editorial}")]
        public IHttpActionResult DeleteByEditorial(string editorial)
        {
            Dictionary<string, object> result = BL.Libro.DeleteByEditorial(editorial);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)result["Excepcion"]);
            }
        }
    }
}
