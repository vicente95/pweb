﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_DadosCarros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        utilizadores.BindGrid(GridView1);
        Label1.Visible = false;
    }

    protected void adcarro_Click(object sender, EventArgs e)
    {
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;


        String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @id)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@matr", matricula.Text);
        cmd.Parameters.AddWithValue("@marca", marca.Text);
        cmd.Parameters.AddWithValue("@mod", modelo.Text);
        cmd.Parameters.AddWithValue("@est", RadioButtonList1.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@id", nome);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        Label1.Text = "Feito com sucesso";
        Label1.Visible = true;
    }
}