using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_inicio_unitario : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        utilizadores.BindGrid(GridView1);
        Panel1.Visible = false;
        Label1.Visible = false;
        /*nome_label.text=gridview.selectedrow.cell[x].text*/
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Textnome.Text = GridView1.SelectedRow.Cells[1].Text;
        Textemail.Text = GridView1.SelectedRow.Cells[2].Text;
        Textcontribuinte.Text = GridView1.SelectedRow.Cells[3].Text;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int id = 0;
        id = id_utilizador.id_utiliza(id);

        String command = "UPDATE Utilizador SET [nome]=@nome, [Email]=@email, [N_contribuinte]=@cont, [Tipo_utilizador]=@tipo WHERE [Id_utilizador] = @status";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@nome", Textnome.Text);
        cmd.Parameters.AddWithValue("@email", Textemail.Text);
        cmd.Parameters.AddWithValue("@cont", Textcontribuinte.Text);
        cmd.Parameters.AddWithValue("@tipo", DropDownList2.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@status", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        Label1.Text = "Feito com sucesso";
        Label1.Visible = true;

    }

    protected void voltar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        utilizadores.BindGrid(GridView1);
    }
}