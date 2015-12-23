using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;



public partial class registo : System.Web.UI.Page
{
    string nomet;
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
    string n_cont = " ";
    //conexão a base de dados srtring
    protected void Page_Load(object sender, EventArgs e)
    {
        //nomet.Text = PreviousPage.Mensagem;
        nomet = HttpContext.Current.User.Identity.Name.ToString();
        
           //ver se o utilizador já tem número de contribuinte
            String command = "SELECT [N_contribuinte] FROM [Utilizador] WHERE [Nome] = @st";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand Cm = new SqlCommand(command, conn);
            Cm.Parameters.AddWithValue("@st", nomet);
            conn.Open();
            try
            {
                n_cont = (string)Cm.ExecuteScalar();
            }
            catch
            {

            }
            conn.Close();

            if (n_cont != " ")
            {
                Response.Redirect("~/inicio.aspx");
            }
            
    }

    protected void button_Click(object sender, EventArgs e)
    {
        
        

        if(DropDownList2.SelectedValue == "1")
        {
            

            //Enserir no utilizador já criado anteriormente o numero de contribuinte e o tipo de conta
            String command = "UPDATE Utilizador SET [N_contribuinte]=@cont, [Tipo_utilizador]=@tipo WHERE [Nome] = @status";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@status", nomet);
            cmd.Parameters.AddWithValue("@cont", N_contribuinte.Text);
            cmd.Parameters.AddWithValue("@tipo", DropDownList2.SelectedItem.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //ir buscar o id do utilizador que foi criado
            int id;
            String StrSel = "SELECT [Id_utilizador] FROM [Utilizador] WHERE [Nome] = @st";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand Cm = new SqlCommand(StrSel, conn);
            Cm.Parameters.AddWithValue("@st", nomet);
            conn.Open();
            id = (Int32) Cm.ExecuteScalar();
            conn.Close();


            //Relação utilizador e hierarquia -> o utilizador tem uma conta do tipo unitaria
            String command2 = "INSERT INTO [Utilizador_Hierarquia] ([Id_Utilizador], [Id_hierarquia]) VALUES (@id1, @id2)";
            SqlConnection co = new SqlConnection(connectionString);
            SqlCommand cmd2 = new SqlCommand(command2, co);
            cmd2.Parameters.AddWithValue("@id1",id);
            cmd2.Parameters.AddWithValue("@id2", 1);

            co.Open();
            cmd2.ExecuteNonQuery();
            co.Close();
            
            //incrementar o numero de registados no tipo de conta unitario
            String command3 = "UPDATE Hierarquia SET [n_registados] = [n_registados] + 1 WHERE [Id_hierarquia] = @id";
            SqlConnection c = new SqlConnection(connectionString);
            SqlCommand cmd3 = new SqlCommand(command3, c);
            cmd3.Parameters.AddWithValue("@id", 1);

            c.Open();
            cmd3.ExecuteNonQuery();
            c.Close();

            //acrescentar nas roles o utilizador como unitario
            string[] Grumetes = { nomet };

            Roles.AddUsersToRole(Grumetes, "unitario");

        }
        else
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
            //conexão a base de dados

            //Enserir no utilizador já criado anteriormente o numero de contribuinte e o tipo de conta
            String command = "UPDATE Utilizador SET [N_contribuinte]=@cont, [Tipo_utilizador]=@tipo WHERE [Nome] = @status";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@status", nomet);
            cmd.Parameters.AddWithValue("@cont", N_contribuinte.Text);
            cmd.Parameters.AddWithValue("@tipo", DropDownList2.SelectedItem.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //ir buscar o id do utilizador que foi criado
            int id;
            String StrSel = "SELECT [Id_utilizador] FROM [Utilizador] WHERE [Nome] = @st";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand Cm = new SqlCommand(StrSel, conn);
            Cm.Parameters.AddWithValue("@st", nomet);
            conn.Open();
            id = (Int32)Cm.ExecuteScalar();
            conn.Close();


            //Relação utilizador e hierarquia -> o utilizador tem uma conta do tipo unitaria
            String command2 = "INSERT INTO [Utilizador_Hierarquia] ([Id_Utilizador], [Id_hierarquia]) VALUES (@id1, @id2)";
            SqlConnection co = new SqlConnection(connectionString);
            SqlCommand cmd2 = new SqlCommand(command2, co);
            cmd2.Parameters.AddWithValue("@id1", id);
            cmd2.Parameters.AddWithValue("@id2", 2);

            co.Open();
            cmd2.ExecuteNonQuery();
            co.Close();

            //incrementar o numero de registados no tipo de conta unitario
            String command3 = "UPDATE Hierarquia SET [n_registados] = [n_registados] + 1 WHERE [Id_hierarquia] = @id";
            SqlConnection c = new SqlConnection(connectionString);
            SqlCommand cmd3 = new SqlCommand(command3, c);
            cmd3.Parameters.AddWithValue("@id", 2);

            c.Open();
            cmd3.ExecuteNonQuery();
            c.Close();

            //acrescentar nas roles o utilizador como unitario
            string[] Grumetes = { nomet };

            Roles.AddUsersToRole(Grumetes, "coletivo");

            Response.Redirect("~/inicio.aspx");


        }
    }
}