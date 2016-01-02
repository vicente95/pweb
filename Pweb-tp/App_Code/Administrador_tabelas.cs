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
/// Summary description for Administrador_tabelas
/// </summary>
public class Administrador_tabelas
{
    public static void utilizadores_tabela(GridView ddl, TextBox procura)
    {
        //
        // TODO: Add constructor logic here
        //
        ddl.DataSource = null;
        ddl.DataBind();
        //string nome = HttpContext.Current.User.Identity.Name.ToString();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [Nome], [Email], [N_contribuinte], [Tipo_utilizador] FROM [Utilizador] WHERE (nome LIKE '%' + @status + '%')", con))
            {

                cmd.Parameters.AddWithValue("@status", procura.Text);

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


    public static void carros_tabela(GridView ddl, TextBox procura)
    {
        //griedview da página dadoscarros
        // TODO: Add constructor logic here
        //
        //ddl.SelectedIndex = -1;
        ddl.DataSource = null;
        ddl.DataBind();
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int n_cont = 0;
        n_cont = id_utilizador.id_utiliza(n_cont);

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT [modelo], [marca], [matricula], [condutor], [estado] FROM Carro WHERE (matricula LIKE '%' + @status + '%')", con))
            {

                cmd.Parameters.AddWithValue("@status", procura.Text);

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

    public static void tabela_Parque(GridView ddl, TextBox procurar)
    {
        //
        // TODO: Add constructor logic here
        //
        ddl.DataSource = null;
        ddl.DataBind();
        int d = 0;
        d = id_utilizador.id_utiliza(d);
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Carro.matricula, Carro.modelo, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Carro INNER JOIN Requisicao_carro ON Carro.Id_carro = Requisicao_carro.Id_carro INNER JOIN Requisicao ON Requisicao_carro.Id_requisicao = Requisicao.Id_requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao WHERE (Carro.matricula LIKE '%' + @status + '%')", con))
            {

                cmd.Parameters.AddWithValue("@status", procurar.Text);

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

    public static void tabela_pagamento(GridView ddl, TextBox procura)
    {
        //ver os pagamentos de cada utilizador
        // TODO: Add constructor logic here
        //
        int d = 0;
        d = id_utilizador.id_utiliza(d);
        string constring = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Carro.marca, Carro.matricula, Carro.modelo, Requisicao.Data_inicio, Requisicao.Data_fim, Parque.nome, Requisicao.Entidade, Requisicao.Referencia, Requisicao.Valor, Requisicao.Estado_pagamento FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Utilizador_requisicao ON Requisicao.Id_requisicao = Utilizador_requisicao.Id_requisicao WHERE (Carro.matricula LIKE '%' + @status + '%')", con))
            {

                cmd.Parameters.AddWithValue("@status", procura.Text);

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