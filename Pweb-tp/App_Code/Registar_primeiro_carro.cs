using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Registar_primeiro_carro
/// </summary>
public class Registar_primeiro_carro
{
    public static void Registar_primeiro(TextBox matricula, TextBox marca, TextBox modelo, RadioButtonList List1 )
    {
        //usado no registo2 para registar o primeiro carro de um utilizador, cumprir a condição 1 utilizador tem pelo menos um caro
        // TODO: Add constructor logic here
        //
        int id = 0;
        id=id_utilizador.id_utiliza(id);
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @id)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@matr", matricula.Text);
        cmd.Parameters.AddWithValue("@marca", marca.Text);
        cmd.Parameters.AddWithValue("@mod", modelo.Text);
        if (List1.SelectedItem.Text == "Ativo")
        {
            cmd.Parameters.AddWithValue("@est", 1);
        }
        else
        {
            cmd.Parameters.AddWithValue("@est", 0);
        }
        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public static void Registar_coletivo(TextBox matricula, TextBox marca, TextBox modelo, RadioButtonList List1, TextBox condutor)
    {
        //usado no registo2 para registar o primeiro carro de um utilizador, cumprir a condição 1 utilizador tem pelo menos um caro
        // TODO: Add constructor logic here
        //
        int id = 0;
        id = id_utilizador.id_utiliza(id);
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;

        String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [condutor] [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @cond, @id)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@matr", matricula.Text);
        cmd.Parameters.AddWithValue("@marca", marca.Text);
        cmd.Parameters.AddWithValue("@mod", modelo.Text);
        if (List1.SelectedItem.Text == "Ativo")
        {
            cmd.Parameters.AddWithValue("@est", 1);
        }
        else
        {
            cmd.Parameters.AddWithValue("@est", 0);
        }
        cmd.Parameters.AddWithValue("@cond", condutor.Text);
        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}