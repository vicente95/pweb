using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for contar_activos
/// </summary>
public class contar_activos
{
    public static int contar(int num, int id)
    {
        //contar os carros ativos do utilizador na base de dados, utilizado nos dados carros
        // TODO: Add constructor logic here
        //

        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT COUNT([estado]) FROM [Carro] WHERE [estado] = 1 AND id_utilizador = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@id", id);
        conn.Open();
        try {
            num = (Int32)Cm.ExecuteScalar();
        }
        catch
        {
            num = 0;
        }
        conn.Close();
        return num;
    }
    public static int quantos_carros_tem(int num, int id)
    {
        //ver quantos carros um utilizador tem na base de dados, utilizado nos dados carros
        // TODO: Add constructor logic here
        //

        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT COUNT([matricula]) FROM [Carro] id_utilizador = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@id", id);
        conn.Open();
        try
        {
            num = (Int32)Cm.ExecuteScalar();
        }
        catch
        {
            num = 0;
        }
        conn.Close();
        return num;
    }

}