﻿using System;
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




public partial class utilizadores_unitarios_GerirParqueamento : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    int id;
    int id_req;
    int entidade = 10658;
    int referencia = 12378965;
    int id_carro;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;

        if (CheckBox1.Checked == true)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            Label3.Text = "Poderá editar, eliminar e adicionar os seus parqueamentos alterne no botão eleminar.";
        }
        else
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            Label3.Text = "Poderá editar, eliminar e adicionar os seus parqueamentos alterne no botão eleminar.";

        }


        
        id=id_utilizador.id_utiliza(id);
        //mostrar os carros ativos do utilizador na dropdownlist
       // Selecionecarro.Items.Clear();
        Carros_ativos.carros_at(id, Selecionecarro);
        //preencher griedview1 editar
        Parqueamento.Parque(GridView1);
        //preencher griedview2 eleminar
        Parqueamento.Parque(GridView2);


        //Datainicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
        //DateTime dt = Convert.ToDateTime(Datainicio.Text);
        if (Datainicio.Text != "")
        {
            DateTime dt = Convert.ToDateTime(Datainicio.Text);
            cmp6.ValueToCompare = dt.Date.ToString("yyyy-MM-dd");
        }
        cmp1.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
        cmp2.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
    }

    protected void Criar_Click(object sender, EventArgs e)
    {
        //ver os dias de requesição para calcualar o preço, 1 euro por dia
        string pagar;
       
        
        DateTime date1 = new DateTime();
        DateTime date2 = new DateTime();
        double dias=0;

        bool isDate1Valid = DateTime.TryParse(Datainicio.Text, out date1);
        bool isDate2Valid = DateTime.TryParse(Datafim.Text, out date2);

        if (isDate1Valid && isDate2Valid)
            dias = (date1 - date2).TotalDays;

        pagar= dias.ToString() + ",00€";


        //Criar entrada na requesição e ficar com o seu ids
        int id_req;
        String command2 = "INSERT INTO [Requisicao] ([Data_inicio], [Data_fim], [Entidade], [Referencia], [Valor], [Estado_pagamento]) VALUES (@d1, @d2, @d3, @d4, @d5, @d6)";
        string query2 = "SELECT MAX(Id_requisicao) FROM Requisicao";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim.Text);
        cmd2.Parameters.AddWithValue("@d3", entidade);
        cmd2.Parameters.AddWithValue("@d4", referencia++);
        cmd2.Parameters.AddWithValue("@d5", pagar);
        cmd2.Parameters.AddWithValue("@d6", "Por pagar");

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();
        co = new SqlConnection(connectionString);
        cmd2 = new SqlCommand(query2, co);
        co.Open();
        id_req = (int)cmd2.ExecuteScalar();
        co.Close();

        //ir buscar o id carro selecionado na dropbox
        String command3 = "SELECT [Id_carro] FROM [Carro] WHERE [matricula] = @s";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@s", Selecionecarro.SelectedItem.Text);

        c.Open();
        id_carro = (int)cmd3.ExecuteScalar(); ;
        c.Close();


        //entrada Requesição_carro uma requisição para um carro 
        String command1 = "INSERT INTO [Requisicao_carro] ([Id_requisicao], [Id_carro]) VALUES (@x1, @x2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd1.Parameters.AddWithValue("@x1", id_req);
        cmd1.Parameters.AddWithValue("@x2", id_carro);

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

        //gravar para a tabela utilizador_requisição - relação Requisição para utilizador
        String command9 = "INSERT INTO [Utilizador_requisicao] ([id_requisicao], [id_utilizador]) VALUES (@n1, @n2)";
        SqlConnection ccc = new SqlConnection(connectionString);
        SqlCommand cmd9 = new SqlCommand(command9, ccc);
        cmd9.Parameters.AddWithValue("@n1", id_req);
        cmd9.Parameters.AddWithValue("@n2", id);

        ccc.Open();
        cmd9.ExecuteNonQuery();
        ccc.Close();
        Selecionecarro.Items.Clear();
        //mostrar os carros ativos do utilizador na dropdownlist
        Carros_ativos.carros_at(id, Selecionecarro);
        //preencher griedview1 editar
        Parqueamento.Parque(GridView1);
        Label3.Text = "Adicionada requesição com sucesso!";
        Datafim.Text = "";     

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt = Convert.ToDateTime(GridView1.SelectedRow.Cells[4].Text);
        DateTime ds = Convert.ToDateTime(GridView1.SelectedRow.Cells[5].Text);
        string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
        if (dt.Date <= DateTime.Now.Date) //não pode editar por a data de inicio da requisição ser igual ou maior que hoje
        {
            MessageBox.Show("Já não pode editar esta requisição por já se encontrar no periudo de requesição!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Panel1.Visible = false;
            Panel2.Visible = true;
            //preencher novamente griedview1 editar
            Parqueamento.Parque(GridView1);
            Selecionecarro.Items.Clear();
            //mostrar os carros ativos do utilizador na dropdownlist
            Carros_ativos.carros_at(id, Selecionecarro);
        }
        else if(ds.Date < DateTime.Now.Date && dt.Date < DateTime.Now.Date)
        {
            MessageBox.Show("A requisição já passou!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Panel1.Visible = false;
            Panel2.Visible = true;
            //preencher novamente griedview1 editar
            Parqueamento.Parque(GridView1);
            Selecionecarro.Items.Clear();
            //mostrar os carros ativos do utilizador na dropdownlist
            Carros_ativos.carros_at(id, Selecionecarro);

        }
        else
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            string sisisi = GridView1.SelectedRow.Cells[1].Text;
            Carros_ativos.carros_at(id, Selecionecarro0);
            Selecionecarro0.SelectedValue = GridView1.SelectedRow.Cells[1].Text;
            string ola = GridView1.SelectedRow.Cells[3].Text;
            //Selecionaparque0.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            Datainicio0.Text = GridView1.SelectedRow.Cells[4].Text;
            Datafim0.Text = GridView1.SelectedRow.Cells[5].Text;
        }

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Tem a certeza que pretende apagar esta requesição?", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        if (result == DialogResult.OK)
        {

            string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dt = Convert.ToDateTime(GridView2.SelectedRow.Cells[5].Text);
            if (dt.Date <= DateTime.Now.Date)//pode eleminar se data do fim da requisição ser igual ou menor que hoje
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
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "Não foi possivel eleminar a requesição por não estar paga ou ainda não ter sido reconhecida como paga!";
                    Parqueamento.Parque(GridView2);
                    Selecionecarro.Items.Clear();
                    //mostrar os carros ativos do utilizador na dropdownlist
                    Carros_ativos.carros_at(id, Selecionecarro);
                }
                else
                {
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label3.Text = "Apagado com sucesso!";
                    Parqueamento.Parque(GridView2);
                    Selecionecarro.Items.Clear();
                    //mostrar os carros ativos do utilizador na dropdownlist
                    Carros_ativos.carros_at(id, Selecionecarro);
                }
            }
            else
            {
                    MessageBox.Show("Ainda não pode eleminar, por não ter passado a data de requisição", "Apagar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //voltar preencher griedview1 eleminar
                    Parqueamento.Parque(GridView2);
                Selecionecarro.Items.Clear();
                //mostrar os carros ativos do utilizador na dropdownlist
                Carros_ativos.carros_at(id, Selecionecarro);

            }
        }
        else
        {
            
            //voltar preencher griedview1 eleminar
            Parqueamento.Parque(GridView2);
            Selecionecarro.Items.Clear();
            //mostrar os carros ativos do utilizador na dropdownlist
            Carros_ativos.carros_at(id, Selecionecarro);
        }
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

        String command2 = "UPDATE Requisicao SET [Data_inicio]=@d1, [Data_fim]=@d2, [Entidade]=@d3, [Referencia]=@d4,  [Valor]=@d5, [Estado_pagamento]=@d6 WHERE [Id_requisicao]= @dd";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio0.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim0.Text);
        cmd2.Parameters.AddWithValue("@d3", entidade);
        cmd2.Parameters.AddWithValue("@d4", referencia++);
        cmd2.Parameters.AddWithValue("@d5", pagar);
        cmd2.Parameters.AddWithValue("@d6", "Por pagar");
        cmd2.Parameters.AddWithValue("@dd", id_req);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();

        //chamar a função para o carro
        string carro2 = Selecionecarro0.SelectedItem.Text;
        int id_carro2 = ver_id_parque_carro.ver_id_carro(carro2);


        //alterar Requesição_carro
        String command1 = "UPDATE Requisicao_carro SET [Id_requisicao]=@x1, [Id_carro]=@x2 WHERE Id_requisicao=@x3 AND Id_carro=@x4";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd1.Parameters.AddWithValue("@x1", id_req);
        cmd1.Parameters.AddWithValue("@x2", id_carro2);
        cmd1.Parameters.AddWithValue("@x3", id_req);
        cmd1.Parameters.AddWithValue("@x4", id_carroant);

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();

        //chamar a função para o id do parque
        string parquenov = Selecionaparque0.SelectedItem.Text;
        int id_parquenov = ver_id_parque_carro.ver_id_parque(parquenov);

        // fazer update gravar para a tabela Parque_requisição - relação Requisição para Parque
        String command4 = "UPDATE Parque_requisicao SET [id_requisicao]=@n1, [id_parque]=@n2 WHERE [id_requisicao]=@n3 AND [id_parque]=@n4";
        SqlConnection cc = new SqlConnection(connectionString);
        SqlCommand cmd4 = new SqlCommand(command4, cc);
        cmd4.Parameters.AddWithValue("@n1", id_req);
        cmd4.Parameters.AddWithValue("@n2", id_parquenov);
        cmd4.Parameters.AddWithValue("@n3", id_req);
        cmd4.Parameters.AddWithValue("@n4", id_parque);

        cc.Open();
        cmd4.ExecuteNonQuery();
        cc.Close();
        
        Label3.Text = "Alterado com sucesso";
        
        Parqueamento.Parque(GridView1);
        Selecionecarro.Items.Clear();
        //mostrar os carros ativos do utilizador na dropdownlist
        Carros_ativos.carros_at(id, Selecionecarro);
    }
    protected void voltar_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
       
        Parqueamento.Parque(GridView1);
        Selecionecarro.Items.Clear();
        //mostrar os carros ativos do utilizador na dropdownlist
        Carros_ativos.carros_at(id, Selecionecarro);
    }
}