using System;
using System.Data.SqlClient;
using System.Data;

namespace SistemaCuidado.Models
{
	public class ClaseUsuarios
	{
        public string Correo { get; set; }
		public string Nombre { get; set; }
		public string ApePaterno { get; set; }
		public string ApeMaterno { get; set; }
		public string Contraseña { get; set; }
		public DateTime FechNac{ get; set; }
		public int Edad { get; set; }
		public int Peso { get; set; }
		public decimal Altura { get; set; }
        public string Genero { get; set; }
        public string Enfermedades { get; set; }

        /*static private string correo;
        static private string nombre;
        static private string apepaterno;
        static private string apematerno;
        static private string contraseña;
        static private DateTime fechnac;
        static private int edad;
        static private int peso;
        static private float altura;
        static public string Correo { get => correo; set => correo = value; }
        static public string Nombre { get => nombre; set => nombre = value; }
        static public string ApePaterno { get => apepaterno; set => apepaterno = value; }
        static public string ApeMaterno { get => apematerno; set => apematerno = value; }
        static public string Contraseña { get => contraseña; set => contraseña = value; }
        static public DateTime FechNac { get => fechnac; set => fechnac = value; }
        static public int Edad { get => edad; set => edad = value; }
        static public int Peso { get => peso; set => peso = value; }
        static public float Altura { get => altura; set => altura = value; }*/


    }
}
