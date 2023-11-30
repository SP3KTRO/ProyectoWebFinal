using ProyectoWebFinal.Models;
using System.Data;
using System.Data.SqlClient;



public class Logica_usuarios
{
    private SqlConnection conexion;

    public usuario encontrarUsuarios(string correo, string clave)
    {
        usuario objeto = new usuario();
        using (SqlConnection conexion = new SqlConnection("Data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\proyectoweb.mdf;integrated security=True;connect timeout=30"))
        {
            string consulta = "select Nombres, Correo, Clave, IdRol from Usuarios where Correo=@pcorreo and Clave = @pclave";
 SqlCommand comando = new SqlCommand(consulta, conexion);

            comando.Parameters.AddWithValue("@pcorreo", correo);
            comando.Parameters.AddWithValue("@pclave", clave);
            comando.CommandType = CommandType.Text;
            conexion.Open();
            using (SqlDataReader datos = comando.ExecuteReader())
            {
                while (datos.Read())
                {
                    objeto = new usuario()
                    {
                        id_usuario = (int)datos["IdUsuario"],
                        nombre_usuario = datos["Nombres"].ToString(),
                        id_rol = (int)datos["IdRol"],
                    };
                }
            }
        }
        return objeto;
    }

}
