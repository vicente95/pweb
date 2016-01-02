using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_inicio_unitario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        utilizadores.BindGrid(GridView1);
        Panel1.Visible = false;
        Label1.Visible = false;
        /*nome_label.text=gridview.selectedrow.cell[x].text*/
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Textnome.Text = GridView1.SelectedRow.Cells[1].Text;
        Textemail.Text = GridView1.SelectedRow.Cells[2].Text;
        Textcontribuinte.Text = GridView1.SelectedRow.Cells[3].Text;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string nome = HttpContext.Current.User.Identity.Name.ToString();
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        int id = 0;
        id = id_utilizador.id_utiliza(id);

        int existe;
        int contribuinte;
        contribuinte = ver_se_existe.ver_contribuinte_dentro(Textcontribuinte, nome);
        existe = ver_se_existe.ver_email_dentro(Textemail, nome);
        if (contribuinte == 1)
        {
            Label2.ForeColor = System.Drawing.Color.Red;
            Label2.Text = "Esse numero contribuinte já esta registado!!!";
        }
        else
        {

            if (existe == 1)
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Esse email já esta registado!!!";
            }
            else
            {
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

                Guid id_user;
                String com = "SELECT UserId FROM Users WHERE UserName=@n1";
                SqlConnection coo = new SqlConnection(connectionString);
                SqlCommand cmd7 = new SqlCommand(com, coo);
                cmd7.Parameters.AddWithValue("@n1", Textnome.Text);

                coo.Open();
                id_user = (Guid)cmd7.ExecuteScalar();
                coo.Close();

                string hierarquia = "";
                if (DropDownList2.SelectedItem.Text == "Cliente Unitario")
                {
                    hierarquia = "unitario";

                }
                else if (DropDownList2.SelectedItem.Text == "Cliente coletivo")
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

                Label1.Text = "Feito com sucesso";
                Label1.Visible = true;

                string[] a = Roles.GetRolesForUser();
                if (a[0] == "unitario")
                {
                    Response.Redirect("~/utilizadores_unitarios/inicio_unitario.aspx");
                }
                else if (a[0] == "coletivo")
                {
                    Response.Redirect("~/utilizadores_coletivos/inicio_coletivo.aspx");
                }
            }
        }

    }

    protected void voltar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        utilizadores.BindGrid(GridView1);
    }
}