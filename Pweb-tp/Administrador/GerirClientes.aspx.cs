using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

public partial class Administrador_GerirClientes : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;

        if (CheckBox1.Checked == true)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
        }
        //ver_pagamento.pagamento(GridView1);
        Administrador_tabelas.utilizadores_tabela(GridView1, pesquisa1);
        Administrador_tabelas.utilizadores_tabela(GridView2, pesquisa1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda ou não foi encontrada a sua procura!";
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + pesquisa1.Text;
        Administrador_tabelas.utilizadores_tabela(GridView1, pesquisa1);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Black;
        pesquisa1.Text = "";
        Label2.Text = "Aqui poderá ver os valores de pagamento assim como consultar o estado de requesições que fez";
        Administrador_tabelas.utilizadores_tabela(GridView1, pesquisa1);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Textnome.Text = GridView1.SelectedRow.Cells[1].Text;
        Textemail.Text = GridView1.SelectedRow.Cells[2].Text;
        Textcontribuinte.Text = GridView1.SelectedRow.Cells[3].Text;
        DropDownList2.SelectedValue = GridView1.SelectedRow.Cells[4].Text;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int id = 0;
        id = id_utilizador.id_utiliza_admin(GridView1.SelectedRow.Cells[1].Text);

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

       // Label1.Text = "Feito com sucesso";
        //Label1.Visible = true;

        Guid id_user;
        String com = "SELECT UserId FROM Users WHERE UserName=@n1";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", GridView1.SelectedRow.Cells[1].Text);

        coo.Open();
        id_user = (Guid)cmd7.ExecuteScalar();
        coo.Close();

        string hierarquia="";
        if(DropDownList2.SelectedItem.Text == "Cliente Unitario")
        {
            hierarquia = "unitario";

        }else if (DropDownList2.SelectedItem.Text == "Cliente coletivo")
        {
            hierarquia = "coletivo";
        }

        Guid id_role;
        String com2 = "SELECT RoleId FROM Roles WHERE RoleName=@n1";
        SqlConnection coo2 = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(com2, coo2);
        cmd2.Parameters.AddWithValue("@n1", hierarquia);

        coo2.Open();
        id_role = (Guid)cmd2.ExecuteScalar();
        coo2.Close();

        String command3 = "UPDATE UsersInRoles SET [RoleId]=@n WHERE [UserId] = @status";
        SqlConnection con3 = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, con3);
        cmd3.Parameters.AddWithValue("@n", id_role);
        cmd3.Parameters.AddWithValue("@status", id_user);

        con3.Open();
        cmd3.ExecuteNonQuery();
        con3.Close();

        Label2.Text = "Feito com sucesso";
        Label2.Visible = true;
        Administrador_tabelas.utilizadores_tabela(GridView1, pesquisa1);


    }

    protected void voltar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Administrador_tabelas.utilizadores_tabela(GridView1, pesquisa1);

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Tem a certeza que pretende apagar este utilizador? Todos os seus dados serão apagados.", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        if (result == DialogResult.OK)
        {
            //id do utilizador que se pretende
            int id = 0;
            id = id_utilizador.id_utiliza_admin(GridView2.SelectedRow.Cells[1].Text);

            Guid id_user;
            String com = "SELECT UserId FROM Users WHERE UserName=@n1";
            SqlConnection coo = new SqlConnection(connectionString);
            SqlCommand cmd7 = new SqlCommand(com, coo);
            cmd7.Parameters.AddWithValue("@n1", GridView2.SelectedRow.Cells[1].Text);

            coo.Open();
            id_user = (Guid)cmd7.ExecuteScalar();
            coo.Close();


            Administrador_apagar.apagar_carro_a_carro(id, id_user);
                

                Label2.ForeColor = System.Drawing.Color.Green;
                Label2.Text = "Utilizador apagado com sucesso!";
                Administrador_tabelas.utilizadores_tabela(GridView2, pesquisa1);


        }
        else
        {
            Administrador_tabelas.utilizadores_tabela(GridView2, pesquisa1);
        }


    }
}
