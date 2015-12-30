using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ver_id_parque_carro
/// </summary>
public class ver_id_parque_carro
{
    
    public static int ver_id_carro(string selecione)
    {
        int id_carro;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        //
        // TODO: Add constructor logic here
        //
        //ir buscar o id carro selecionado na dropbox para mudar na tabela requesição carro

        String command3 = "SELECT [Id_carro] FROM [Carro] WHERE [matricula] = @s";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@s", selecione);

        c.Open();
        id_carro = (int)cmd3.ExecuteScalar();
        c.Close();



        return id_carro;
    }
    public static int ver_id_parque(string nome)
    {
        int id_parque;
        //
        // TODO: Add constructor logic here
        //ir buscar o id do parque mediante o nome
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String com = "SELECT Id_parque FROM Parque WHERE nome=@n1";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", nome);

        coo.Open();
        id_parque = (int)cmd7.ExecuteScalar();
        coo.Close();


        return id_parque;
    }
    public static int ver_estado_Requesicao(int id)
    {
        int retorno=0;
        //string estado;
        //
        // TODO: Add constructor logic here
        //ver o estado da requisição pagamento- utilizado para eliminar carros
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String com = "SELECT Estado_pagamento FROM Requisicao WHERE Id_requisicao=@n1 AND Estado_pagamento=@p";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", id);
        cmd7.Parameters.AddWithValue("@p", "Por pagar");
        coo.Open();
        SqlDataReader dr = cmd7.ExecuteReader();
        while (dr.Read())
        {
            if (dr.HasRows == true)
            {
                retorno = 1;
                break;
            }
        }
        coo.Close();

       /* if (estado=="Por Pagar")
        {
            retorno = 1;
        }
        else
        {
            retorno = 0;
        }*/

        return retorno;
    }
    public static void requesicoes_de_um_carro(int id, DropDownList d)
    {
        //usado para eleminar no dadoscarros, mostra as requesicoes para um carro numa dropdownlist
        // TODO: Add constructor logic here
        //
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlDataReader dados;
        String StrSel = "SELECT [matricula] FROM [Carro] WHERE [estado] = 1 AND id_utilizador = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@id", id);
        conn.Open();
        dados = Cm.ExecuteReader();

        while (dados.Read())
        {
            ListItem li = new ListItem();
            li.Text = dados.GetValue(0).ToString();
            li.Value = dados.GetValue(0).ToString();
            d.Items.Add(li);
        }
        dados.Close();

        conn.Close();
    }
}