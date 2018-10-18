﻿using System;
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

        public static Usuario ObtenerUsuario (string Usuario, string Password, string Accion)
        {
            Usuario NuevoUsuario = new Usuario("","");
            if ((Usuario != "") && (Password != ""))
               {
                    SqlConnection Conexion = Conectar();
                    SqlCommand Consulta = Conexion.CreateCommand();
                    Consulta.CommandText = "ObtenerUsuario";
                    Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    Consulta.Parameters.AddWithValue("@nombre", Usuario);
                    Consulta.Parameters.AddWithValue("@password", Password);
                    SqlDataReader dataReader = Consulta.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string nombre = dataReader["Usuario"].ToString();
                        string password = dataReader["Contraseña"].ToString();
                        bool esAdmin = Convert.ToBoolean(dataReader["EsAdministrador"]);

                        if (Accion == "InicioSesion")
                        {
                            if ((nombre == Usuario) && (password == Password))
                            {
                                NuevoUsuario.NombreUsuario = nombre;
                                NuevoUsuario.Password = password;
                                NuevoUsuario.EsAdmin = esAdmin;
                                Desconectar(Conexion);
                                return NuevoUsuario;
                            }
                        }

                        if (Accion == "Registro")
                        {
                            if (nombre == Usuario)
                            {
                                NuevoUsuario.NombreUsuario = nombre;
                                NuevoUsuario.Password = password;
                                NuevoUsuario.EsAdmin = esAdmin;
                                return NuevoUsuario;
                            }
                        }
                    }
                    Desconectar(Conexion);
                }
            return NuevoUsuario;
        }

        public static int InsertarUsuario (Usuario Usuario)
        {
            int regsAfectados = 0; 
            if (Usuario.NombreUsuario == "")
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
    }
}