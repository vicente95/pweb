using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for apagar_parqueamento
/// </summary>
public class apagar_parqueamento
{
    public static int ap_parqueamento(int id_p, string matricula, string data)
    {
        //
        // TODO: Add constructor logic here
        //
        int id_c;
        id_c = selecionar_idcarro(matricula);
        int id_req;

        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        //ir buscar o id carro selecionado na dropbox
        String command3 = "SELECT Requisicao.Id_requisicao FROM Requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Parque_requisicao ON Requisicao.Id_requisicao = Parque_requisicao.Id_requisicao WHERE (Carro.Id_carro = @x1) AND (Requisicao.Data_inicio = @x2) AND (Parque_requisicao.id_parque = @x3)";
        SqlConnection c = new SqlConnection(constring);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@x1", id_c);
        cmd3.Parameters.AddWithValue("@x2", data);
        cmd3.Parameters.AddWithValue("@x3", id_p);

        c.Open();
        id_req = (int)cmd3.ExecuteScalar();
        c.Close();
        int naopago;
        naopago = ver_se_req_esta_paga(id_req);

        if (naopago == 1)
        {
            return 0;
        }
        else
        {
            apagar_requesicao_carro(id_req);
            apagar_Parque_requesicao(id_req);
            apagar_Utilizador_requisicao(id_req);
            apagar_requesicao(id_req);
            return 1; 
        }
    }

    public static int selecionar_idcarro(string mat)
    {
        //
        // TODO: Add constructor logic here
        //
        int id;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "SELECT Id_carro FROM Carro WHERE matricula=@x";
        SqlConnection conf = new SqlConnection(constring);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", mat);
        conf.Open();
        id= (int)cmdf.ExecuteScalar();
        conf.Close();

        return id;
    }

    public static void apagar_requesicao_carro(int idreq)
    {
        //
        // TODO: Add constructor logic here
        //
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "DELETE FROM Requisicao_carro WHERE Id_requisicao=@x";
        SqlConnection conf = new SqlConnection(constring);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", idreq);
        conf.Open();
        cmdf.ExecuteNonQuery();
        conf.Close();


    }
    public static void apagar_Parque_requesicao(int idreq)
    {
        //
        // TODO: Add constructor logic here
        //
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "DELETE FROM Parque_requisicao WHERE Id_requisicao=@x";
        SqlConnection conf = new SqlConnection(constring);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", idreq);
        conf.Open();
        cmdf.ExecuteNonQuery();
        conf.Close();


    }
    public static void apagar_requesicao(int idreq)
    {
        //
        // TODO: Add constructor logic here
        //
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "DELETE FROM Requisicao WHERE Id_requisicao=@x";
        SqlConnection conf = new SqlConnection(constring);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", idreq);
        conf.Open();
        cmdf.ExecuteNonQuery();
        conf.Close();


    }

    public static int ver_se_req_esta_paga(int idreq)
    {
        //ver se uma determinado carro tem requesição já existe na base de dados
        // TODO: Add constructor logic here
        //
        int n = 0;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("SELECT Requisicao.Estado_pagamento FROM Requisicao WHERE Id_requisicao=@x1 AND Estado_pagamento=@x2", con);
        cmd.Parameters.AddWithValue("@x1", idreq);
        cmd.Parameters.AddWithValue("@x2", "Por pagar");
        con.Open();
        try
        {

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {

                    n = 1;
                    
                    break;
                }
            }
        }
        catch
        {

        }

        con.Close();
        return n;
    }
    public static void apagar_Utilizador_requisicao(int idreq)
    {
        //
        // TODO: Add constructor logic here
        //
        //fazer delete da entrada em Utilizador_hierarquia
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "DELETE FROM Utilizador_requisicao WHERE Id_requisicao=@x";
        SqlConnection conf = new SqlConnection(connectionString);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", idreq);
        conf.Open();
        cmdf.ExecuteNonQuery();
        conf.Close();

    }
}