using System;

public class Logica_usuarios
{
    public Usuarios encontrarUsuarios(string correo, string clave)
    {
        Usuarios objeto = new suario();
        using (SqlConnection conexion = new SqlConnection("Data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\proyectoweb.mdf;integrated security=True;connect timeout=30"))
 {
            string consulta = "select Nombres, Correo, Clave, IdRol from Usuarios where Correo=@pcorreo and
Clave = @pclave";
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
                        Nombres = datos["Nombres"].ToString(),
                        Correo = datos["Correo"].ToString(),
                        Clave = datos["Clave"].ToString(),
                        IdRol = (int)datos["IdRol"],
                    };
                }
            }
        }
        return objeto;
    }

}
