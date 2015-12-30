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
/// Summary description for Pesquisa_pagamento_utilizador
/// </summary>
public class Pesquisa_pagamento_utilizador
{
    public static void pesquisa(GridView ddl, TextBox procurar)
    {
        int d = 0;
        d = id_utilizador.id_utiliza(d);
        ddl.DataSource = null;

        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        string query = "SELECT Carro.marca, Carro.matricula, Carro.modelo, Requisicao.Data_inicio, Requisicao.Data_fim, Parque.nome, Requisicao.Entidade, Requisicao.Referencia, Requisicao.Valor, Requisicao.Estado_pagamento FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Utilizador_requisicao ON Requisicao.Id_requisicao = Utilizador_requisicao.Id_requisicao WHERE (Utilizador_requisicao.Id_utilizador = @id) AND (Carro.matricula LIKE '%' + @matricula + '%')";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand( query, con))
            {

                cmd.Parameters.AddWithValue("@id", d);
                cmd.Parameters.AddWithValue("@matricula", procurar.Text);
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataSet dt = new DataSet())
                    {
                        sda.Fill(dt);
                        ddl.DataSource = dt;
                        ddl.DataBind();
                    }
                }
            }
        }
        //
        // TODO: Add constructor logic here
        //
    }
}