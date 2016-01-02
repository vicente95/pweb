using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Administrador_apagar
/// </summary>
public class Administrador_apagar
{
    public static void apagar_carro_a_carro(int idutilizador, Guid id_roles)
    {
        //
        // TODO: Add constructor logic here
        //
        string n;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("SELECT Id_carro FROM Carro WHERE Id_utilizador=@x1", con);

        cmd.Parameters.AddWithValue("@x1", idutilizador);
        con.Open();
        try
        {
            //selecionar carro a carro do utilizador e pagar tudo o que envolve
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //if (dr.HasRows == true)
                //{
                n = dr.GetValue(0).ToString();
                apagar_requesicoes(n);
                apagar_carro(n);//apagar carro
                

                //}
            }
        }
        catch
        {

        }
        apagar_utilizador_requisicao(idutilizador);//apagar as requesições todas do utilizador
        apagar_utilizador(idutilizador, id_roles);// no fim de tudo apagar utilizador
        con.Close();
    }
    public static void apagar_requesicoes(string g)
    {
        //
        // TODO: Add constructor logic here
        //
        string n;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("SELECT Id_requisicao FROM Requisicao_carro WHERE Id_carro=@x1", con);

        cmd.Parameters.AddWithValue("@x1", g);
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
    public static void apagar_utilizador_requisicao(int idreq)
    {
        //
        // TODO: Add constructor logic here
        //
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        String command3 = "DELETE FROM Utilizador_requisicao WHERE Id_utilizador=@x";
        SqlConnection conf = new SqlConnection(constring);
        SqlCommand cmdf = new SqlCommand(command3, conf);
        cmdf.Parameters.AddWithValue("@x", idreq);
        conf.Open();
        cmdf.ExecuteNonQuery();
        conf.Close();


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

    public static void apagar_utilizador(int id, Guid id_roles)
    {
        //
        // TODO: Add constructor logic here
        //
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;


        String command1 = "DELETE FROM Utilizador_Hierarquia WHERE Id_Utilizador=@x";
        String command2 = "DELETE FROM Utilizador WHERE Id_Utilizador=@x";
        String command3 = "DELETE FROM UsersInRoles WHERE UserId=@x";
        String command4 = "DELETE FROM Memberships WHERE UserId=@x";
        String command5 = "DELETE FROM Users WHERE UserId=@x";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        SqlCommand cmd2 = new SqlCommand(command2, con);
        SqlCommand cmd3 = new SqlCommand(command3, con);
        SqlCommand cmd4 = new SqlCommand(command4, con);
        SqlCommand cmd5 = new SqlCommand(command5, con);
        cmd1.Parameters.AddWithValue("@x", id);
        cmd2.Parameters.AddWithValue("@x", id);
        cmd3.Parameters.AddWithValue("@x", id_roles);
        cmd4.Parameters.AddWithValue("@x", id_roles);
        cmd5.Parameters.AddWithValue("@x", id_roles);

        con.Open();
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        cmd3.ExecuteNonQuery();
        cmd4.ExecuteNonQuery();
        cmd5.ExecuteNonQuery();
        con.Close();


    }

    public static void apagar_carro(string id)
    {
        //
        // TODO: Add constructor logic here
        //
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        //fazer delete por id do carro
        String command4 = "DELETE FROM Carro WHERE id_carro=@id";
        SqlConnection cox = new SqlConnection(connectionString);
        SqlCommand cmu = new SqlCommand(command4, cox);
        cmu.Parameters.AddWithValue("@id", id);
        cox.Open();
        cmu.ExecuteNonQuery();
        cox.Close();


    }
}