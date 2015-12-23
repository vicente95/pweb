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
        int d=0;
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        id_utilizador.id_utiliza(d);
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Carro.matricula, Carro.modelo, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Carro INNER JOIN Requisicao_carro ON Carro.Id_carro = Requisicao_carro.Id_carro INNER JOIN Requisicao ON Requisicao_carro.Id_requisicao = Requisicao.Id_requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao WHERE (Carro.id_utilizador = @id)", con))
            {

                cmd.Parameters.AddWithValue("@id", d);

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
