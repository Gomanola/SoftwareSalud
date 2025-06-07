using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SistemaCuidado.Models;
using SistemaCuidado.Recursos.ChatGPT;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

namespace SistemaCuidado.Controllers
{
    public class SistemaController : Controller
    {
        static public ClaseUsuarios Usuario;
        public static string _EndPoint = "https://api.openai.com/";
        public static string _URI = "v1/chat/completions";
        public static string _APIKey = "Mi API de OpenAI";

		//Incio del sistema
		public IActionResult Inicio()
        {
            return View();
        }

        //Registro del sistema
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(ClaseUsuarios _Usuarios)
        {
            if(SQLModel.Verificar(_Usuarios) == true)
            {
                ViewBag.Error = "Usuario ya registrado";
                return View();
            }
            if (_Usuarios.FechNac<Convert.ToDateTime("1/1/1753")|| _Usuarios.FechNac > DateTime.Today)
            {
                ViewBag.Error = "Fecha invalida";
                return View();
            }
            _Usuarios.Edad = ValidacionesModel.Edad(_Usuarios.FechNac);
            SQLModel.Registrar(_Usuarios);
            Usuario = _Usuarios;
            Usuario.Nombre = SQLModel.Nombre(Usuario);
            Usuario.ApePaterno = SQLModel.ApePaterno(Usuario);
            Usuario.ApeMaterno = SQLModel.ApeMaterno(Usuario);
            Usuario.Edad= SQLModel.Edad(Usuario);
            Usuario.Altura = SQLModel.Altura(Usuario);
            Usuario.Peso = SQLModel.Peso(Usuario);
            Usuario.Genero = SQLModel.Genero(Usuario);
            Usuario.Enfermedades = SQLModel.Enfermedades(Usuario);
            _Usuarios = Usuario;
            return View("RegistroExito", _Usuarios);
        }

        public IActionResult RegistroExito()
        {
            return View("PáginaUsuarios",Usuario);
        }

        //Logueo del sistema
        [HttpGet]
        public IActionResult Logueo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logueo(ClaseUsuarios _Usuarios)
        {
            if (SQLModel.Logueo(_Usuarios) == true)
            {
                Usuario = _Usuarios;
                Usuario.Nombre = SQLModel.Nombre(Usuario);
                Usuario.ApePaterno = SQLModel.ApePaterno(Usuario);
                Usuario.ApeMaterno = SQLModel.ApeMaterno(Usuario);
				Usuario.Edad = SQLModel.Edad(Usuario);
				Usuario.Altura = SQLModel.Altura(Usuario);
				Usuario.Peso = SQLModel.Peso(Usuario);
				Usuario.Genero = SQLModel.Genero(Usuario);
				Usuario.Enfermedades = SQLModel.Enfermedades(Usuario);
                _Usuarios = Usuario;
				return View("PáginaUsuarios",_Usuarios);
            }
            ViewBag.Error = "Error al Iniciar Sesión";
            return View();
        }

        //Inicio de usuarios
        [HttpGet]
        public IActionResult PáginaUsuarios(ClaseUsuarios _Usuarios)
        {
            if (Usuario == null || Usuario.Correo=="")
            {
                return View("Logueo");
            }
            _Usuarios = Usuario;
            return View(_Usuarios);
        }
        [HttpPost]
        public IActionResult PáginaUsuarios(ClaseUsuarios _Usuarios, string op)
        {
            _Usuarios = Usuario;
            string pSolicitud = "Hola, soy "+Usuario.Nombre+", con base a mi siguiente información: Edad: "+Usuario.Edad+
                " Peso: "+Usuario.Peso+" Altura: "+Usuario.Altura+" m Genero: "+Usuario.Genero+ 
                " Kg. No me des un diagnostico, pero dame recomendaciones básicas para mis siguientes enfermedades: "+Usuario.Enfermedades;
            if(op== "Actualizar")
            {
                return View("Actualizar", _Usuarios);
            }
            if (op=="Cerrar Sesión")
            {
                Usuario = null;
                return View("Inicio");
            }
            if (op == "Recomendaciones")
            {
                try
                {
                    var strRespuesta = "";
                    //Consumir la API
                    var oCliente = new RestClient(_EndPoint);
                    var oSolicitud = new RestRequest(_URI, Method.Post);
                    oSolicitud.AddHeader("Content-Type", "application/json");
                    oSolicitud.AddHeader("Authorization", "Bearer " + _APIKey);

                    //Creamos el cuerpo de la solicitud
                    var oCuerpo = new Request()
                    {
                        model = "gpt-3.5-turbo",
                        messages = new List<Message>()
                    {
                        new Message()
                        {
                            role = "user",
                            content = pSolicitud
                        }

                    }
                    };

                    var jsonString = JsonConvert.SerializeObject(oCuerpo);

                    oSolicitud.AddJsonBody(jsonString);

                    var oRespuesta = oCliente.Post<Response>(oSolicitud);
                    strRespuesta = oRespuesta.choices[0].message.content;

                    ViewBag.Respuesta = strRespuesta;
                    return View("PáginaUsuarios", _Usuarios);
                }
                catch (Exception ex)
                {
                    ViewBag.Respuesta = "Recarga la página para continuar usando";
                    return View("PáginaUsuarios", _Usuarios);
                }
            }
            return View(_Usuarios);
        }

        //Actualización de datos
        [HttpGet]
        public IActionResult Actualizar()
        {
            ClaseUsuarios _Usuarios= new ClaseUsuarios();
            _Usuarios = Usuario;
            return View(_Usuarios);
        }
        [HttpPost]
        public IActionResult Actualizar(ClaseUsuarios _Usuarios)
        {
            Usuario.Altura=_Usuarios.Altura;
            Usuario.Peso = _Usuarios.Peso;
            Usuario.Genero = _Usuarios.Genero;
            Usuario.Enfermedades = _Usuarios.Enfermedades;
            _Usuarios = Usuario;
            SQLModel.Actualizar(_Usuarios);
            return View("PáginaUsuarios", _Usuarios);
        }
        public IActionResult Nosotros()
        {
            return View();
        }
        /*[HttpGet]
        public IActionResult ActualizarExito()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ActualizarExito(ClaseUsuarios _Usuarios)
        {
            return View();
        }*/
    }
}
