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

        Datainicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
        cmp1.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
        cmp2.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");

    }

    protected void Unnamed5_Click(object sender, EventArgs e)
    {
        //Criar entrada na requesição e ficar com o seu ids
        int id_req;
        String command2 = "INSERT INTO [Requisicao] ([Data_inicio], [Data_fim]) VALUES (@d1, @d2)";
        string query2 = "Select @@Identity";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim.Text);

        co.Open();
        cmd2.ExecuteNonQuery();
        cmd2.CommandText = query2;
        id_req = (int)cmd2.ExecuteScalar();
        co.Close();

        //ir buscar o id carro selecionado na dropbox
        int id_carro;
        String command3 = "SELECT [Id_carro] FROM [Carro] WHERE [matricula] = @s";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@s", Selecionecarro.SelectedItem.Text);

        c.Open();
        id_carro = (int)cmd3.ExecuteScalar(); ;
        c.Close();


        //entrada Requesição_carro 
        String command1 = "INSERT INTO [Requisicao_carro] ([Id_requisicao], [Id_carro]) VALUES (@x1, @x2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd2.Parameters.AddWithValue("@x1", id_carro);
        cmd2.Parameters.AddWithValue("@x2", id_req);

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
        
        //gravar para a tabela Parque_requisição - relação Requisição para Parque
        String command4 = "INSERT INTO [Parque_requisicao] ([id_requisicao], [id_parque]) VALUES (@n1, @n2)";
        SqlConnection cc = new SqlConnection(connectionString);
        SqlCommand cmd4 = new SqlCommand(command4, cc);
        cmd4.Parameters.AddWithValue("@n1", id_req);
        cmd4.Parameters.AddWithValue("@n2", Selecionaparque.SelectedValue);

        cc.Open();
        cmd4.ExecuteNonQuery();
        cc.Close();


    }

    protected void Editar_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView2.Visible = false;
    }

    protected void Eleminar_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = true;
    }
}