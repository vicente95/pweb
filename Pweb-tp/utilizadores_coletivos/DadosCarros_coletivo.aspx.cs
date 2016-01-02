using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class utilizadores_unitarios_DadosCarros : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    int id = 0;
    int quantostem = 0;
    int quantosativos = 0;
    string matricul;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "";
        carros_tudo_coletivo.carro(GridView1, procurar);
        carros_tudo_coletivo.carro(GridView2, procurar);
        if (GridView1.Rows.Count == 0 || GridView2.Rows.Count == 0)
        {
            Label2.Text = "Não tem carros!";
        }
        Panel2.Visible = false;
        id = id_utilizador.id_utiliza(id);

        quantosativos = contar_activos.contar(quantosativos, id);

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

        if (quantostem < 10)
        {
            String command = "INSERT INTO [Carro] ([matricula], [marca], [modelo], [estado], [condutor], [id_utilizador]) VALUES (@matr, @marca, @mod, @est, @cond, @id)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@matr", matricula.Text);
            cmd.Parameters.AddWithValue("@marca", marca.Text);
            cmd.Parameters.AddWithValue("@mod", modelo.Text);



            if (RadioButtonList3.SelectedItem.Text == "Activo" && quantosativos < 8)
            {
                cmd.Parameters.AddWithValue("@est", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@est", 0);
            }
            cmd.Parameters.AddWithValue("@cond", condutor.Text);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            if (RadioButtonList3.SelectedItem.Text == "Activo" && quantosativos == 2)
            {
                carros_tudo_coletivo.carro(GridView1, procurar);
                Label1.Text = "Feito com sucesso. ATENÇÃO: O CARRO FOI COLOCADO EM DESATIVO, POR JÁ TER 2 ATIVOS.";
            }
            else
            {
                carros_tudo_coletivo.carro(GridView1, procurar);
                Label1.Text = "Feito com sucesso";
            }
        }
        else
        {
            carros_tudo_coletivo.carro(GridView1, procurar);
            Label1.Text = "Já tem 3 carros! Não pode adicionar mais";
        }

        matricula.Text = "";
        marca.Text = "";
        modelo.Text = "";
        condutor.Text = "";

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
        matricul = GridView1.SelectedRow.Cells[3].Text;
        condutor2.Text = GridView1.SelectedRow.Cells[4].Text;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        quantosativos--;
        String command = "UPDATE Carro SET [matricula]=@matr, [marca]=@marca, [modelo]=@mod, [estado]=@est, [condutor]=@cond WHERE ([id_utilizador] = @s1) AND ([matricula]=@s2)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(command, con);
        cmd.Parameters.AddWithValue("@s1", id);
        cmd.Parameters.AddWithValue("@s2", GridView1.SelectedRow.Cells[3].Text);
        cmd.Parameters.AddWithValue("@matr", TextBox3.Text);
        cmd.Parameters.AddWithValue("@marca", TextBox1.Text);
        cmd.Parameters.AddWithValue("@mod", TextBox2.Text);

        if (RadioButtonList2.SelectedItem.Text == "Activo" && quantosativos < 2)
        {
            cmd.Parameters.AddWithValue("@est", 1);
        }
        else
        {
            cmd.Parameters.AddWithValue("@est", 0);
        }
        cmd.Parameters.AddWithValue("@cond", condutor2.Text);
        

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        if (RadioButtonList2.SelectedItem.Text == "Activo" && quantosativos == 2)
        {
            carros_tudo_coletivo.carro(GridView1, procurar);
            Label1.Text = "ATENÇÃO: O CARRO FOI COLOCADO NOVAMENTE EM DESATIVO, DESATIVE PRIMEIRO UM DOS ATIVOS.";
        }
        else
        {
            carros_tudo_coletivo.carro(GridView1, procurar);
            Panel1.Visible = true;
            Label1.Text = "Feito com sucesso";
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        carros_tudo_coletivo.carro(GridView1, procurar);
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Tem a certeza que pretende apagar esta requesição?", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        if (result == DialogResult.OK)
        {
            //ir buscar o id do carro que se pretende eleminar
            string matricula_carro;
            matricula_carro = GridView2.SelectedRow.Cells[3].Text;
            int id_c = 0;
            int sim;
            int numeroderequesicoes;
            id_c = contar_activos.procura_id_carro(matricula_carro); //id do carro atravez da matricula
            sim = ver_se_existe.ver_se_carro_tem_req(id_c);          //ver se tem requesiçoes por pagar
            numeroderequesicoes = contar_activos.quantas_requesicoes_tem_carro(id_c);//contar as requesições que tem o carro usado apenas em caso de se puder eleminar

            if (sim == 1)
            {
                //Response.Redirect("~/utilizadores_unitarios/DadosCarros.aspx");
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Não pode eleminar o carro pois possui uma requesição que ainda não foi paga ou reconhecida como paga!";
                carros_tudo_coletivo.carro(GridView2, procurar);

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

                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Carro apagado com sucesso!";

                carros_tudo_coletivo.carro(GridView2, procurar);

            }
        }
        else
        {
            carros_tudo_coletivo.carro(GridView2, procurar);
        }


    }

    protected void pesq_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + TextBox1.Text;
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.Color.Black;
        TextBox1.Text = "";
        Label2.Text = "";
        Label1.Text = "Pode editar e eleminar a sua informação.";
        carros_tudo_coletivo.carro(GridView1, procurar);
        carros_tudo_coletivo.carro(GridView2, procurar);
    }
}