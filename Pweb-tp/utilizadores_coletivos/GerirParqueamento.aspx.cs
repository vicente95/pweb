using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_GerirParqueamento : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void adiciona_Click(object sender, EventArgs e)
    {

        //Criar entrada na requesição
        String command2 = "INSERT INTO [Requisicao] ([Data_inicio], [Data_fim]) VALUES (@d1, @d2)";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim.Text);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();

        //entrada Requesição_carro -----continuar daqui
        String command1 = "INSERT INTO [Requisicao_carro] ([Id_requisicao], [Id_carro]) VALUES (@x1, @x2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd2.Parameters.AddWithValue("@x1", Datainicio.Text);
        cmd2.Parameters.AddWithValue("@x2", Datafim.Text);

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
        /*
        //incrementar o numero de registados no tipo de conta unitario
        String command3 = "UPDATE Hierarquia SET [n_registados] = [n_registados] + 1 WHERE [Id_hierarquia] = @id";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@id", 1);

        c.Open();
        cmd3.ExecuteNonQuery();
        c.Close();*/

    }
}