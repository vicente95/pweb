using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_DadosCarros : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        carros_tudo.carro(GridView1);
        carros_tudo.carro(GridView2);
        

        if (CheckBox1.Checked == true)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
           
        }
        else
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            Label1.Visible = false;
        }
    }

    protected void adcarro_Click(object sender, EventArgs e)
    {
        id=id_utilizador.id_utiliza(id);
      
        String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @id)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@matr", matricula.Text);
        cmd.Parameters.AddWithValue("@marca", marca.Text);
        cmd.Parameters.AddWithValue("@mod", modelo.Text)
        
        if (RadioButtonList1.SelectedItem.Text == "Ativo")
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

        Label1.Text = "Feito com sucesso";
        Label1.Visible = true;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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