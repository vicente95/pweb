using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for requisicao
/// </summary>
public class requisicao
{
    public static void requi()
    {
        //Não faz nada é não esta a ser usado
        // TODO: Add constructor logic here

        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        //Selecionar o id da requisicao
        String command2 = "SELECT [Id_requisicao] FROM [Requisicao] WHERE [Nome] = @st";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
       // cmd2.Parameters.AddWithValue("@d1", Datainicio.Text);
       // cmd2.Parameters.AddWithValue("@d2", Datafim.Text);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();
    }
}