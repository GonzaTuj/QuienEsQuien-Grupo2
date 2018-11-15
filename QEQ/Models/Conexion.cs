using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; 

namespace QEQ.Models
{
    public static class Conexion
    {
        public static string connectionString = "Server=10.128.8.16;Database=QEQC02;uid=QEQC02;pwd=QEQC02;";
        private static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection(connectionString);
            a.Open();
            return a;
        }

        public static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();
        }

        //USUARIO
        public static Usuario ObtenerUsuario (string Usuario, string Password, string Accion)
        {
            Usuario NuevoUsuario = new Usuario("","", 0);
            if ((Usuario != "") && (Password != ""))
               {
                    SqlConnection Conexion = Conectar();
                    SqlCommand Consulta = Conexion.CreateCommand();
                    Consulta.CommandText = "ObtenerUsuario";
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.Parameters.AddWithValue("@nombre", Usuario);
                    Consulta.Parameters.AddWithValue("@password", Password);
                    Consulta.Parameters.AddWithValue("@accion", Accion);
                    SqlDataReader dataReader = Consulta.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string nombre = dataReader["Usuario"].ToString();
                        string password = dataReader["Contraseña"].ToString();
                        int monedas = Convert.ToInt32(dataReader["Monedas"]);
                        bool esAdmin = Convert.ToBoolean(dataReader["EsAdministrador"]);

                        if (Accion == "InicioSesion")
                        {
                                NuevoUsuario.NombreUsuario = nombre;
                                NuevoUsuario.Password = password;
                                NuevoUsuario.Monedas = monedas; 
                                NuevoUsuario.EsAdmin = esAdmin;
                                Desconectar(Conexion);
                                return NuevoUsuario;
                        }

                        if (Accion == "Registro")
                        {
                                NuevoUsuario.NombreUsuario = nombre;
                                NuevoUsuario.Password = password;
                                NuevoUsuario.EsAdmin = esAdmin;
                                return NuevoUsuario;
                        }
                    }
                    Desconectar(Conexion);
                }
            return NuevoUsuario;
        }

        public static int InsertarUsuario (Usuario Usuario)
        {
            int regsAfectados = 0; 
            if (Usuario.NombreUsuario != "")
            {
                SqlConnection Conexion = Conectar();
                SqlCommand Consulta = Conexion.CreateCommand();
                Consulta.CommandText = "InsertarUsuario";
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.Parameters.AddWithValue("@nombre", Usuario.NombreUsuario);
                Consulta.Parameters.AddWithValue("@password", Usuario.Password);
                regsAfectados = Consulta.ExecuteNonQuery();
            }
            return regsAfectados;
        }

        //CARACTERISTICAS
        public static List<Caracteristica> ListarCaracteristica()
        { 
            List<Caracteristica> Caracteristicas = new List<Caracteristica>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", null);
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["IdCaract"]);
                string nombre = dataReader["Nombre"].ToString();
                int idcategoria = Convert.ToInt32(dataReader["FkCategoria"]);
                string pregunta = dataReader["Pregunta"].ToString();
                Caracteristica c = new Caracteristica(id, nombre, idcategoria, pregunta);
                Caracteristicas.Add(c);
            }
            Desconectar(Conexion);
            return Caracteristicas;
        }

        public static Caracteristica ObtenerCaracteristica (int ID)
        {
            Caracteristica c = new Caracteristica(0, "", 0, "");
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", ID);
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["IdCaract"]);
                string nombre = dataReader["Nombre"].ToString();
                int idcategoria = Convert.ToInt32(dataReader["fkCategoria"]);
                string pregunta = dataReader["Pregunta"].ToString();
                c = new Caracteristica(id, nombre, idcategoria, pregunta);
            }
            Desconectar(Conexion);
            return c;
        }

        public static int InsertarCaracteristica(Caracteristica c)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", c.Nombre);
            Consulta.Parameters.AddWithValue("@fkCategoria", c.IDCategoria);
            Consulta.Parameters.AddWithValue("@Pregunta", c.Pregunta);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        public static int ModificarCaracteristica(Caracteristica c)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@idCaract", c.ID);
            Consulta.Parameters.AddWithValue("@Nombre", c.Nombre);
            Consulta.Parameters.AddWithValue("@FkCategoria", c.IDCategoria);
            Consulta.Parameters.AddWithValue("@Pregunta", c.Pregunta);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        public static int EliminarCaracteristica(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@idCaract", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        //CATEGORIA CARACTERISTICA
        public static List<CategoriaCaracteristica> ListarCategoriaC()
        {
            List<CategoriaCaracteristica> CategoriasCaracteristicas = new List<CategoriaCaracteristica>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCategoriaC";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", "");
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["Id"]);
                string nombre = dataReader["Nombre"].ToString();
                CategoriaCaracteristica cc = new CategoriaCaracteristica(id, nombre);
                CategoriasCaracteristicas.Add(cc);
            }
            Desconectar(Conexion);
            return CategoriasCaracteristicas;
        }

        public static CategoriaCaracteristica ObtenerCategoriaC(int ID)
        {
            CategoriaCaracteristica cc = new CategoriaCaracteristica(0, "");
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCategoriaC";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", ID);
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["Id"]);
                string nombre = dataReader["Nombre"].ToString();
                cc = new CategoriaCaracteristica(id, nombre);
            }
            Desconectar(Conexion);
            return cc;
        }

        public static int InsertarCategoriaC(CategoriaCaracteristica cc)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarCategoriaC";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@NombreCatCar", cc.Nombre);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        public static void ModificarCategoriaC(CategoriaCaracteristica cc)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarCategoriaC";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IDcatCar", cc.ID);
            Consulta.Parameters.AddWithValue("@NombreCatCar", cc.Nombre);
        }

        public static int EliminarCategoriaC(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarCategoriaC";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IDCat", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        //CATEGORIAS PERSONAJES 
        public static List<CategoriaPersonaje> ListarCategoriaP()
        {
            List<CategoriaPersonaje> CategoriasPersonajes = new List<CategoriaPersonaje>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCategoriaP";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", "");
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["ID"]);
                string nombre = dataReader["Nombre"].ToString();
                CategoriaPersonaje cp = new CategoriaPersonaje(id, nombre);
                CategoriasPersonajes.Add(cp);
            }
            Desconectar(Conexion);
            return CategoriasPersonajes;
        }

        public static CategoriaPersonaje ObtenerCategoriaP(int ID)
        {
            CategoriaPersonaje cp = new CategoriaPersonaje(0, "");
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCategoriaP";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", ID);
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["ID"]);
                string nombre = dataReader["Nombre"].ToString();
                cp = new CategoriaPersonaje(id, nombre);
            }
            Desconectar(Conexion);
            return cp;
        }

        public static int InsertarCategoriaP(CategoriaPersonaje cp)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarCategoriaP";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@NombreCatPer", cp.Nombre);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        public static int ModificarCategoriaP(CategoriaPersonaje cp)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarCategoriaP";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IDcatPer", cp.ID);
            Consulta.Parameters.AddWithValue("@NombreCatPer", cp.Nombre);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        public static int EliminarCategoriaP(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarCategoriaP";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IDCat", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

        //PERSONAJES
        public static List<Personaje> ListarPersonaje()
        {
            List<Personaje> personajes = new List<Personaje>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", "");
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["idPers"]);
                string nombre = dataReader["Nombre"].ToString();
                int idcategoria = Convert.ToInt32(dataReader["fkCategoria"]);

                Personaje p = new Personaje(id, nombre, idcategoria);
                personajes.Add(p);
            }
            Desconectar(Conexion);
            return personajes;
        }

        public static Personaje ObtenerPersonaje(int ID)
        {
            Personaje p = new Personaje(0, "", 0); 
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", "");
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["idPers"]);
                string nombre = dataReader["Nombre"].ToString();
                int idcategoria = Convert.ToInt32(dataReader["fkCategoria"]);

                p = new Personaje(id, nombre, idcategoria);
            }
            Desconectar(Conexion);
            return p;
        }

        public static int InsertarPersonaje(Personaje p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nom", p.Nombre);
            Consulta.Parameters.AddWithValue("@Cat", p.FkCategoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }


        public static int ModificarPersonaje(Personaje p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id",p.IdPers);
            Consulta.Parameters.AddWithValue("@Nom", p.Nombre);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }


        public static int EliminarPersonaje(int ID)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", ID);
            int regsAfectados = Consulta.ExecuteNonQuery();
            return regsAfectados;
        }

    }
}