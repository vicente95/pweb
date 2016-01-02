using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for id_utilizador
/// </summary>
public class id_utilizador
{
    public static int id_utiliza(int id)
    {
        //retorna o id do utilizador mediante o nome que esta logado
        // TODO: Add constructor logic here
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT [Id_utilizador] FROM [Utilizador] WHERE [Nome] = @st";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@st", nome);
        conn.Open();
        id = (Int32)Cm.ExecuteScalar();
        conn.Close();
        return id;
    }

    public static int id_utiliza_admin(string nome)
    {
        //retorna o id do utilizador para o admin que este quer apagar
        // TODO: Add constructor logic here
        int id;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT [Id_utilizador] FROM [Utilizador] WHERE [Nome] = @st";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@st", nome);
        conn.Open();
        id = (Int32)Cm.ExecuteScalar();
        conn.Close();
        return id;
    }
}