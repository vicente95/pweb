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

        String StrSel = "SELECT COUNT([matricula]) FROM [Carro] WHERE id_utilizador = @id";
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
    public static int procura_id_carro(string matricula)
    {
        //ver quantos carros um utilizador tem na base de dados, utilizado nos dados carros
        // TODO: Add constructor logic here
        //
        int num;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT [Id_carro] FROM [Carro] WHERE matricula= @mt";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@mt", matricula);
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

    public static int procura_dono_carro(int mat)
    {
        //ver dono do carro admin
        // TODO: Add constructor logic here
        //
        int num;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT [Id_utilizador] FROM [Carro] WHERE Id_carro= @mt";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand Cm = new SqlCommand(StrSel, conn);
        Cm.Parameters.AddWithValue("@mt", mat);
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
    public static int quantas_requesicoes_tem_carro(int id)
    {
        //utilizado para apagar carro
        // TODO: Add constructor logic here
        //
        int num;
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String StrSel = "SELECT COUNT([Id_requisicao]) FROM [Requisicao_carro] WHERE id_carro = @id";
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