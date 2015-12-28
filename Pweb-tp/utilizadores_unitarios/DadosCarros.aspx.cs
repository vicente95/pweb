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
    int quantostem = 0;
    int quantosativos = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        carros_tudo.carro(GridView1);
        carros_tudo.carro(GridView2);

        quantosativos = contar_activos.contar(quantosativos, id);
        id = id_utilizador.id_utiliza(id);
        quantostem = contar_activos.quantos_carros_tem(quantostem, id);

        if (CheckBox1.Checked == true)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            Label1.Text = "Pode editar e eleminar a sua informação.";

        }
        else
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            Label1.Text = "Pode editar e eleminar a sua informação.";
            //Label1.Visible = false;
        }
    }

    protected void adcarro_Click(object sender, EventArgs e)
    { 

        if (quantostem < 3)
        {
            String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @id)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@matr", matricula.Text);
            cmd.Parameters.AddWithValue("@marca", marca.Text);
            cmd.Parameters.AddWithValue("@mod", modelo.Text);

            
 
            if (RadioButtonList1.SelectedItem.Text == "Ativo" && quantosativos<2)
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

            if (RadioButtonList1.SelectedItem.Text == "Ativo" && quantosativos == 2)
            {
                Label1.Text = "Feito com sucesso. ATENÇÃO: O CARRO FOI COLOCADO EM DESATIVO, POR JÁ TER 2 ATIVOS.";
            }
            else
            {
                Label1.Text = "Feito com sucesso";
            }
        }
        else
        {
            Label1.Text = "Já tem 3 carros! Não pode adicionar mais";
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        TextBox1.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox3.Text = GridView1.SelectedRow.Cells[4].Text;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {

        String command = "UPDATE Carro SET [matricula]=@matr, [marca]=@marca, [modelo]=@mod, [estado]=est, WHERE [id_utilizador] = @s1 AND [matricula]=@s2";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@matr", matricula.Text);
        cmd.Parameters.AddWithValue("@marca", marca.Text);
        cmd.Parameters.AddWithValue("@mod", modelo.Text);

        if (RadioButtonList1.SelectedItem.Text == "Ativo" && quantosativos < 2)
        {
            cmd.Parameters.AddWithValue("@est", 1);
        }
        else
        {
            cmd.Parameters.AddWithValue("@est", 0);
        }
        cmd.Parameters.AddWithValue("@s1", id);
        cmd.Parameters.AddWithValue("@s2", GridView1.SelectedRow.Cells[2].Text);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        if (RadioButtonList1.SelectedItem.Text == "Ativo" && quantosativos == 2)
        {
            Label1.Text = "ATENÇÃO: O CARRO FOI COLOCADO NOVAMENTE EM DESATIVO, DESATIVE PRIMEIRO UM DOS ATIVOS.";
        }
        else
        {
            Label1.Text = "Feito com sucesso";
        }

    }
}