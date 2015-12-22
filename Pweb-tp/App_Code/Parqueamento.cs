using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Configuration;

/// <summary>
/// Summary description for Parqueamento
/// </summary>
public class Parqueamento
{
    public static void Parque(GridView ddl)
    {
        //
        // TODO: Add constructor logic here
        //
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Carro.modelo, Carro.marca, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Carro CROSS JOIN Requisicao CROSS JOIN Parque INNER JOIN Requisicao_carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Parque_carro ON Parque_carro.Id_carro = Carro.Id_carro WHERE (Requisicao_carro.Id_carro = @status)", con))
            {

                cmd.Parameters.AddWithValue("@status", nome);

                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl.DataSource = dt;
                        ddl.DataBind();
                    }
                }
            }
        }
    }
}
