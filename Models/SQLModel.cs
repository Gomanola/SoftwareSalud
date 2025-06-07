using System.Data.SqlClient;
using System.Data;

namespace SistemaCuidado.Models
{
    public class SQLModel
    {
        public static void Registrar(ClaseUsuarios Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            SqlCommand cmd = new SqlCommand("sp_registrar", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            con.Open();

            cmd.Parameters.AddWithValue("@Correo", Usuarios.Correo);
            cmd.Parameters.AddWithValue("@Nombre", Usuarios.Nombre);
            cmd.Parameters.AddWithValue("@ApePaterno", Usuarios.ApePaterno);
            cmd.Parameters.AddWithValue("@ApeMaterno", Usuarios.ApeMaterno);
            cmd.Parameters.AddWithValue("@Contraseña", Usuarios.Contraseña);
            cmd.Parameters.AddWithValue("@FechNac", Usuarios.FechNac);
            cmd.Parameters.AddWithValue("@Edad", Usuarios.Edad);

            int resultado = cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool Logueo(ClaseUsuarios Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            SqlCommand cmd = new SqlCommand("sp_logueo", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            con.Open();

            cmd.Parameters.AddWithValue("@Correo", Usuarios.Correo);
            cmd.Parameters.AddWithValue("@Contraseña", Usuarios.Contraseña);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public static bool Actualizar(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            SqlCommand cmd = new SqlCommand("sp_actualizar", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            con.Open();

			cmd.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
			cmd.Parameters.AddWithValue("@Altura", _Usuarios.Altura);
            cmd.Parameters.AddWithValue("@Peso", _Usuarios.Peso);
            cmd.Parameters.AddWithValue("@Genero", _Usuarios.Genero);
            cmd.Parameters.AddWithValue("@Enfermedades", _Usuarios.Enfermedades);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public static bool Verificar(ClaseUsuarios Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_verificacion", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Correo", Usuarios.Correo);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public static string Nombre(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Nombre = dr.GetString(1);
            }
            return _Usuarios.Nombre;
        }
        public static string ApePaterno(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios  where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.ApePaterno = dr.GetString(2);
            }
            return _Usuarios.ApePaterno;
        }
        public static string ApeMaterno(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.ApeMaterno = dr.GetString(3);
            }
            return _Usuarios.ApeMaterno;
        }
        public static string Contraseña(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Contraseña = dr.GetString(4);
            }
            return _Usuarios.Contraseña;
        }
        public static DateTime FechNac(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.FechNac = dr.GetDateTime(5);
            }
            return _Usuarios.FechNac;
        }
        public static int Edad(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Edad = dr.GetInt32(6);
            }
            return _Usuarios.Edad;
        }
        public static decimal Altura(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Altura = (dr.GetDecimal(7));
            }
            return _Usuarios.Altura;
        }
        public static int Peso(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Peso = dr.GetInt32(8);
            }
            return _Usuarios.Peso;
        }
        public static string Genero(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso,Genero from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Genero = dr.GetString(9);
            }
            return _Usuarios.Genero;
        }
        public static string Enfermedades(ClaseUsuarios _Usuarios)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=SistemaCuidado; Integrated Security=True");
            con.Open();
            string query = "select Correo,NombreUsuario,ApPaternoUsuario,ApMaternoUsuario,Contraseña,FechNac,Edad,Altura,Peso,Genero,Enfermedades from Usuarios where Correo=@Correo";
            SqlCommand cdm = new SqlCommand(query, con);
            cdm.Parameters.AddWithValue("@Correo", _Usuarios.Correo);
            SqlDataReader dr = cdm.ExecuteReader();
            if (dr.Read())
            {
                _Usuarios.Enfermedades = dr.GetString(10);
            }
            return _Usuarios.Enfermedades;
        }
    }
}
