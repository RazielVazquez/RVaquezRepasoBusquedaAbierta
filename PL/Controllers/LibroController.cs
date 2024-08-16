using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetByAutor(ML.Libro libro)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                var responseTask = client.GetAsync("GetByAutor/{autor}?autor="+libro.Autor);
                responseTask.Wait();

                List<object> libros = new List<object>();
                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>(); //Instalar NuGet Microsoft.AspNet.WebApi.Client
                    readTask.Wait();
                    if(readTask.Result.TryGetValue("Libros", out object libroObject) && libroObject != null)
                    {
                        libros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(libroObject.ToString());
                    }
                    
                    libro.Libros = new List<ML.Libro>();

                    foreach(var jsonLibro in libros)
                    {
                        ML.Libro libroDes = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(jsonLibro.ToString());
                        libro.Libros.Add(libroDes);
                    }
                }
                else
                {

                }
            }

            return View(libro);
        }

        [HttpGet]
        public ActionResult GetByTitulo(ML.Libro libro)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                var responseTask = client.GetAsync("GetByTitulo/{titulo}?titulo=" + libro.TituloLibro);
                responseTask.Wait();

                List<object> libros = new List<object>();
                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    if(readTask.Result.TryGetValue("Libros", out object libroObject) && libroObject != null)
                    {
                        libros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(libroObject.ToString());
                    }

                    libro.Libros = new List<ML.Libro>();

                    foreach(var jsonLibro in  libros)
                    {
                        ML.Libro libroDes = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(jsonLibro.ToString());
                        libro.Libros.Add(libroDes);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            return View("GetByAutor", libro);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            Dictionary<string,object> result = new Dictionary<string, object>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"].ToString());
                var responseTask = client.PostAsJsonAsync("Add", libro);
                responseTask.Wait(); // Llamada al metodo de la api
                var respuesta = responseTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    result = readTask.Result;

                }
                else
                {
                    var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();
                    result = readTask.Result;
                }
            }
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {
                ViewBag.Mensaje = "El Usuario ha sido insertado";
            }
            else
            {
                string excepcion = (string)result["Excepcion"];
                ViewBag.Mensaje = "el Usuario no se pudo registrar" + excepcion;
            }
            return View();
        }
    }
}