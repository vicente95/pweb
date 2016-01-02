using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Administrador_PagamentoServiços : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        //ver_pagamento.pagamento(GridView1);
        Administrador_tabelas.tabela_pagamento(GridView1, pesquisa1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda ou não foi encontrada a sua procura!";
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + pesquisa1.Text;
        Administrador_tabelas.tabela_pagamento(GridView1, pesquisa1);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Black;
        pesquisa1.Text = "";
        Label2.Text = "Aqui poderá ver os valores de pagamento assim como consultar o estado de requesições que fez";
        Administrador_tabelas.tabela_pagamento(GridView1, pesquisa1);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox7.Text = GridView1.SelectedRow.Cells[6].Text;
        TextBox4.Text = GridView1.SelectedRow.Cells[7].Text;
        TextBox5.Text = GridView1.SelectedRow.Cells[8].Text;
        TextBox6.Text = GridView1.SelectedRow.Cells[9].Text;
        DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[10].Text;
    }

    protected void Alterar_Click(object sender, EventArgs e)
    {
        //chamar a função para o carro
        string carro = GridView1.SelectedRow.Cells[2].Text;
        int id_carro = ver_id_parque_carro.ver_id_carro(carro);

        //chamar a função para o parque
        string parque = GridView1.SelectedRow.Cells[6].Text;
        int id_parque = ver_id_parque_carro.ver_id_parque(parque);

        //ir buscar o id da requesição
        int id_req;
        String com = "SELECT Requisicao.Id_requisicao FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao_carro INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Requisicao ON Requisicao_carro.Id_requisicao = Requisicao.Id_requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao WHERE (Carro.matricula = @n1) AND  (Carro.id_carro = @n5) AND (Parque.id_parque = @n2) AND (Requisicao.Data_inicio = @n3) AND (Requisicao.Data_fim = @n4)";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", GridView1.SelectedRow.Cells[2].Text);
        cmd7.Parameters.AddWithValue("@n5", id_carro);
        cmd7.Parameters.AddWithValue("@n2", id_parque);
        cmd7.Parameters.AddWithValue("@n3", GridView1.SelectedRow.Cells[4].Text);
        cmd7.Parameters.AddWithValue("@n4", GridView1.SelectedRow.Cells[5].Text);

        coo.Open();
        id_req = (int)cmd7.ExecuteScalar();
        coo.Close();


        //alterar entrada na requesição e ficar com o seu ids

        String command2 = "UPDATE Requisicao SET [Estado_pagamento]=@d6 WHERE [Id_requisicao]= @dd";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d6", DropDownList1.SelectedValue.ToString());
        cmd2.Parameters.AddWithValue("@dd", id_req);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();
        Panel2.Visible = false;
        //ver_pagamento.pagamento(GridView1);
        Administrador_tabelas.tabela_pagamento(GridView1, pesquisa1);
    }
}