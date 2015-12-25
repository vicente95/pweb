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
    int id;
    int id_req;
    int entidade = 10658;
    int id_carro;
    protected void Page_Load(object sender, EventArgs e)
    {
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

        Panel1.Visible = false;
        id=id_utilizador.id_utiliza(id);
        Carros_ativos.carros_at(id, Selecionecarro);


        Datainicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        String command2 = "INSERT INTO [Requisicao] ([Data_inicio], [Data_fim], [Entidade], [Valor], [Estado_pagamento]) VALUES (@d1, @d2, @d3, @d4, @d5)";
        string query2 = "Select @@Identity";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim.Text);
        cmd2.Parameters.AddWithValue("@d3", entidade);
        cmd2.Parameters.AddWithValue("@d4", pagar);
        cmd2.Parameters.AddWithValue("@d5", "Por pagar");

        co.Open();
        cmd2.ExecuteNonQuery();
        cmd2.CommandText = query2;
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


        //entrada Requesição_carro 
        String command1 = "INSERT INTO [Requisicao_carro] ([Id_requisicao], [Id_carro]) VALUES (@x1, @x2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd2.Parameters.AddWithValue("@x2", id_carro);
        cmd2.Parameters.AddWithValue("@x1", id_req);

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


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Selecionecarro0.SelectedValue = GridView1.SelectedRow.Cells[1].Text;
        Selecionaparque0.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
        Datainicio0.Text = GridView1.SelectedRow.Cells[3].Text;
        Datafim0.Text = GridView1.SelectedRow.Cells[4].Text;

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

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


        //alterar entrada na requesição e ficar com o seu ids

        String command2 = "UPDATE Requisicao SET [Data_inicio]=@d1, [Data_fim]=@d2, [Entidade]=@d3, [Valor]=@d4, [Estado_pagamento]=@d5 WHERE [Id_requesicao]= @dd";
        SqlConnection co = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(command2, co);
        cmd2.Parameters.AddWithValue("@d1", Datainicio0.Text);
        cmd2.Parameters.AddWithValue("@d2", Datafim0.Text);
        cmd2.Parameters.AddWithValue("@d3", entidade);
        cmd2.Parameters.AddWithValue("@d4", pagar);
        cmd2.Parameters.AddWithValue("@d5", "Por pagar");
        cmd2.Parameters.AddWithValue("@dd", id_req);

        co.Open();
        cmd2.ExecuteNonQuery();
        co.Close();

        //ir buscar o id carro selecionado na dropbox
        int id_carro2;
        String command3 = "SELECT [Id_carro] FROM [Carro] WHERE [matricula] = @s";
        SqlConnection c = new SqlConnection(connectionString);
        SqlCommand cmd3 = new SqlCommand(command3, c);
        cmd3.Parameters.AddWithValue("@s", Selecionecarro0.SelectedItem.Text);

        c.Open();
        id_carro2 = (int)cmd3.ExecuteScalar(); ;
        c.Close();


        //alterar Requesição_carro ---continuar daqui
        String command1 = "UPDATE Requisicao_carro SET [Id_requisicao]=@x1, [Id_carro]=@x2 WHERE Id_requisicao=@x3 AND Id_carro=@x4";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd1 = new SqlCommand(command1, con);
        cmd2.Parameters.AddWithValue("@x1", id_req);
        cmd2.Parameters.AddWithValue("@x2", id_carro2);
        cmd2.Parameters.AddWithValue("@x3", id_req);
        cmd2.Parameters.AddWithValue("@x4", id_carro);

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
}