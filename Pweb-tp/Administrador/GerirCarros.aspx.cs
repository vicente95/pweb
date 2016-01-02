using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Administrador_GerirCarros : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    int id = 0;
    int quantosativos = 0;
    int id_hierar=0;
    int n;
    int estado;
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
        Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
        Administrador_tabelas.carros_tabela(GridView2, pesquisa1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda ou não foi encontrada a sua procura!";
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + pesquisa1.Text;
        Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
        Administrador_tabelas.carros_tabela(GridView2, pesquisa1);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Black;
        pesquisa1.Text = "";
        Label2.Text = "Aqui poderá ver os valores de pagamento assim como consultar o estado de requesições que fez";
        Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
        Administrador_tabelas.carros_tabela(GridView2, pesquisa1);
    }


    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // chamar a função para o carro
        string carr = GridView1.SelectedRow.Cells[3].Text;
        int id_carr = ver_id_parque_carro.ver_id_carro(carr);

        String com = "SELECT Id_utilizador FROM Carro WHERE Id_carro=@n1";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", id_carr);

        coo.Open();
        id = (int)cmd7.ExecuteScalar();
        coo.Close();

        String com2 = "SELECT Id_hierarquia FROM Utilizador_Hierarquia WHERE Id_Utilizador=@n1";
        SqlConnection coo2 = new SqlConnection(connectionString);
        SqlCommand cmd4 = new SqlCommand(com2, coo2);
        cmd4.Parameters.AddWithValue("@n1", id);

        coo2.Open();
        id_hierar = (int)cmd4.ExecuteScalar();
        coo2.Close();

        quantosativos = contar_activos.contar(quantosativos, id);//quantos carros tem ativos


        String com3 = "SELECT estado FROM Carro WHERE Id_carro=@n1";
        SqlConnection coo3 = new SqlConnection(connectionString);
        SqlCommand cmd5 = new SqlCommand(com3, coo3);
        cmd5.Parameters.AddWithValue("@n1", id_carr);

        coo3.Open();
        estado = (int)cmd5.ExecuteScalar();
        coo3.Close();
        int n = 0;
        int j;
        if (id_hierar == 1 && quantosativos == 2 && estado == 0)
        {
            n = 1;
        }else if (id_hierar == 2 && quantosativos == 8 && estado == 0) {

            n = 2;
        }


        String command = "UPDATE Carro SET [matricula]=@matr, [marca]=@marca, [modelo]=@mod, [estado]=@est, [condutor]=@cond WHERE ([id_utilizador] = @s1) AND ([matricula]=@s2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@s1", id);
        cmd.Parameters.AddWithValue("@s2", GridView1.SelectedRow.Cells[3].Text);
        cmd.Parameters.AddWithValue("@matr", TextBox3.Text);
        cmd.Parameters.AddWithValue("@marca", TextBox1.Text);
        cmd.Parameters.AddWithValue("@mod", TextBox2.Text);

        if (RadioButtonList4.SelectedItem.Text == "Activo" && n==1 || RadioButtonList4.SelectedItem.Text == "Activo" && n == 2 || n==0 && RadioButtonList4.SelectedItem.Text == "Activo")
        {
            cmd.Parameters.AddWithValue("@est", 1);
            j = 1;
        }
        else
        {
            cmd.Parameters.AddWithValue("@est", 0);
            j = 0;
        }
        cmd.Parameters.AddWithValue("@cond", TextBox4.Text);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        if (j==0 && n==1 || j==0 && n==2)
        {
            Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
            Label1.ForeColor = System.Drawing.Color.Red;
            Label2.Text = "ATENÇÃO: O CARRO FOI COLOCADO NOVAMENTE EM DESATIVO, DESATIVE PRIMEIRO UM DOS ATIVOS.";
        }
        else
        {
            Administrador_tabelas.carros_tabela(GridView1, pesquisa1);
            Panel1.Visible = false;
            Label1.ForeColor = System.Drawing.Color.Green;
            Label2.Text = "Feito com sucesso";
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;

        if(GridView1.SelectedRow.Cells[4].Text != "")
        {
            TextBox4.Enabled = true;
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
        }

        

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Tem a certeza que pretende apagar esta requesição? Poderá haver requesições não pagas referentes ao carro que serão apagadas", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        if (result == DialogResult.OK)
        {
            //ir buscar o id do carro que se pretende eleminar
            string matricula_carro;
            matricula_carro = GridView2.SelectedRow.Cells[3].Text;
            int id_c = 0;
            int donocarro;
            
            id_c = contar_activos.procura_id_carro(matricula_carro); //id do carro atravez da matricula
            donocarro = contar_activos.procura_dono_carro(id_c);//id do dono do carro
            int quantostem=0;
            quantostem = contar_activos.quantos_carros_tem(quantostem, donocarro);
            if (quantostem == 1)
            {
                //Response.Redirect("~/utilizadores_unitarios/DadosCarros.aspx");
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Não pode eleminar o carro pois o utilizador não possui mais nenhum carro!";
                Administrador_tabelas.carros_tabela(GridView2, pesquisa1);

            }
            else
            {
                //fazer delete das entradas em Utilizador_hierarquia
                String command3 = "DELETE FROM Utilizador_requisicao FROM Utilizador_requisicao INNER JOIN Requisicao ON Utilizador_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao WHERE(Requisicao_carro.Id_carro = @x)";
                SqlConnection conf = new SqlConnection(connectionString);
                SqlCommand cmdf = new SqlCommand(command3, conf);
                cmdf.Parameters.AddWithValue("@x", id_c);
                conf.Open();
                cmdf.ExecuteNonQuery();
                conf.Close();


                apagar_relacao_requesicao.apagar_relacao_principal(id_c);
                //fazer delete por id do carro
                String command4 = "DELETE FROM Carro WHERE id_carro=@id";
                SqlConnection cox = new SqlConnection(connectionString);
                SqlCommand cmu = new SqlCommand(command4, cox);
                cmu.Parameters.AddWithValue("@id", id_c);
                cox.Open();
                cmu.ExecuteNonQuery();
                cox.Close();

                Label2.ForeColor = System.Drawing.Color.Green;
                Label2.Text = "Carro apagado com sucesso!";
                Administrador_tabelas.carros_tabela(GridView2, pesquisa1);

            }
        }
        else
        {
            Administrador_tabelas.carros_tabela(GridView2, pesquisa1);
        }


    }
}