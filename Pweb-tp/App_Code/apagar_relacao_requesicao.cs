using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for apagar_relacao_requesicao
/// </summary>
public class apagar_relacao_requesicao
{
    public static void apagar_relacao_principal(int idcarro)
    {
        //
        // TODO: Add constructor logic here
        //
        string n;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("SELECT Id_requisicao FROM Requisicao_carro WHERE Id_carro=@x1", con);

        cmd.Parameters.AddWithValue("@x1", idcarro);
        con.Open();
        try
        {

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //if (dr.HasRows == true)
                //{
                    n = dr.GetValue(0).ToString();
                    apagar_requesicao_carro(n);
                    apagar_Parque_requesicao(n);
                    apagar_requesicao(n);
                    
                //}
            }
        }
        catch
        {

        }

        con.Close();
    }


    public static void apagar_requesicao(string idreq)
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

    public static void apagar_requesicao_carro(string idreq)
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

    public static void apagar_Parque_requesicao(string idreq)
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
}