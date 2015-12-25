using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Carros_ativos
/// </summary>
public class Carros_ativos
{
    public static void carros_at(int id, DropDownList d)
    {
        //usado no parqueamento, mostr os carros do utilizador ativos na dropdownlist do utilizador
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