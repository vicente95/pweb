using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Administrador_GerirParqueamento : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ver_pagamento.pagamento(GridView1);
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
        Administrador_tabelas.tabela_Parque(GridView1, pesquisa1);
        Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda ou não foi encontrada a sua procura!";
        }

        if (Panel1.Visible == true)
        {
            if (Datainicio0.Text != "")
            {
                DateTime dt = Convert.ToDateTime(Datainicio0.Text);
                cmp6.ValueToCompare = dt.Date.ToString("yyyy-MM-dd");
            }
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + pesquisa1.Text;
        Administrador_tabelas.tabela_Parque(GridView1, pesquisa1);
        Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Black;
        pesquisa1.Text = "";
        Label2.Text = "Aqui poderá ver os valores de pagamento assim como consultar o estado de requesições que fez";
        Administrador_tabelas.tabela_Parque(GridView1, pesquisa1);
        Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        Selecionaparque0.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
        Datainicio0.Text = GridView1.SelectedRow.Cells[4].Text;
        Datafim0.Text = GridView1.SelectedRow.Cells[5].Text;

    }

    protected void voltar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Administrador_tabelas.tabela_Parque(GridView1, pesquisa1);
    }

    protected void Modificar_Click(object sender, EventArgs e)
    {
        //ver os dias de requesição para calcualar o preço, 1 euro por dia
        string pagar;

        DateTime date1 = new DateTime();
        DateTime date2 = new DateTime();
        double dias = 0;

        bool isDate1Valid = DateTime.TryParse(Datainicio0.Text, out date1);
        bool isDate2Valid = DateTime.TryParse(Datafim0.Text, out date2);

        if (isDate1Valid && isDate2Valid)
            dias = (date1 - date2).TotalDays;

        pagar = dias.ToString() + ",00€";

        //chamar a função para o carro
        string carroant = GridView1.SelectedRow.Cells[1].Text;
        int id_carroant = ver_id_parque_carro.ver_id_carro(carroant);

        //chamar a função para o parque
        string parque = GridView1.SelectedRow.Cells[3].Text;
        int id_parque = ver_id_parque_carro.ver_id_parque(parque);

        //ir buscar o id da requesição
        int id_req;
        String com = "SELECT Requisicao.Id_requisicao FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao_carro INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Requisicao ON Requisicao_carro.Id_requisicao = Requisicao.Id_requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao WHERE (Carro.matricula = @n1) AND  (Carro.id_carro = @n5) AND (Parque.id_parque = @n2) AND (Requisicao.Data_inicio = @n3) AND (Requisicao.Data_fim = @n4)";
        SqlConnection coo = new SqlConnection(connectionString);
        SqlCommand cmd7 = new SqlCommand(com, coo);
        cmd7.Parameters.AddWithValue("@n1", GridView1.SelectedRow.Cells[1].Text);
        cmd7.Parameters.AddWithValue("@n5", id_carroant);
        cmd7.Parameters.AddWithValue("@n2", id_parque);
        cmd7.Parameters.AddWithValue("@n3", GridView1.SelectedRow.Cells[4].Text);
        cmd7.Parameters.AddWithValue("@n4", GridView1.SelectedRow.Cells[5].Text);

        coo.Open();
        id_req = (int)cmd7.ExecuteScalar();
        coo.Close();

        
        //alterar entrada na requesição e ficar com o seu ids

        String command2 = "UPDATE Requisicao SET [Data_inicio]=@d1, [Data_fim]=@d2, [Valor]=@d5 WHERE [Id_requisicao]= @dd";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio0.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim0.Text);
        cmd2.Parameters.AddWithValue("@d5", pagar);
        cmd2.Parameters.AddWithValue("@dd", id_req);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();
        //chamar a função para o id do parque
        string parquenov = Selecionaparque0.SelectedItem.Text;
        int id_parquenov = ver_id_parque_carro.ver_id_parque(parquenov);

        string parq = GridView1.SelectedRow.Cells[3].Text;
        int id_parq = ver_id_parque_carro.ver_id_parque(parq);

        // fazer update gravar para a tabela Parque_requisição - relação Requisição para Parque
        String command4 = "UPDATE Parque_requisicao SET [id_requisicao]=@n1, [id_parque]=@n2 WHERE [id_requisicao]=@n3 AND [id_parque]=@n4";
        SqlConnection cc = new SqlConnection(connectionString);
        SqlCommand cmd4 = new SqlCommand(command4, cc);
        cmd4.Parameters.AddWithValue("@n1", id_req);
        cmd4.Parameters.AddWithValue("@n2", id_parquenov);
        cmd4.Parameters.AddWithValue("@n3", id_req);
        cmd4.Parameters.AddWithValue("@n4", id_parq);

        cc.Open();
        cmd4.ExecuteNonQuery();
        cc.Close();
        Administrador_tabelas.tabela_Parque(GridView1, pesquisa1);
    }


    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Tem a certeza que pretende apagar esta requesição?", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        if (result == DialogResult.OK)
        {
                int id_p;
                string parque = GridView2.SelectedRow.Cells[3].Text;
                string matricula = GridView2.SelectedRow.Cells[1].Text;
                string data = GridView2.SelectedRow.Cells[4].Text;
                int executar;

                if (parque == "Avenida Fernao Magalhaes")
                {
                    id_p = 1;

                }
                else if (parque == "Quinta das Flores")
                {
                    id_p = 2;
                }
                else
                {
                    id_p = 3;
                }

                executar = apagar_parqueamento.ap_parqueamento(id_p, matricula, data);
                if (executar == 0)
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Não foi possivel eleminar a requesição por não estar paga ou ainda não ter sido reconhecida como paga!";
                     Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
               
                }
                else
                {

                    Label2.ForeColor = System.Drawing.Color.Green;
                    Label2.Text = "Apagado com sucesso!";
                    Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
                  

                }

        }
        else
        {

            Administrador_tabelas.tabela_Parque(GridView2, pesquisa1);
            //Response.Redirect("~/utilizadores_unitarios/GerirParqueamento.aspx")

        }
    }
}