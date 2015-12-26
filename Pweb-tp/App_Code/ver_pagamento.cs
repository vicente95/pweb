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
/// Summary description for ver_pagamento
/// </summary>
public class ver_pagamento
{
    public static void pagamento(GridView ddl)
    {
        //
        // TODO: Add constructor logic here
        //
        //
        // TODO: Add constructor logic here
        //
        int d = 0;
        d = id_utilizador.id_utiliza(d);
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Carro.marca, Carro.matricula, Carro.modelo, Requisicao.Data_inicio, Requisicao.Data_fim, Parque.nome, Requisicao.Entidade, Requisicao.Referencia, Requisicao.Valor, Requisicao.Estado_pagamento FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Utilizador_requisicao ON Requisicao.Id_requisicao = Utilizador_requisicao.Id_requisicao WHERE (Utilizador_requisicao.Id_utilizador = @id)", con))
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
