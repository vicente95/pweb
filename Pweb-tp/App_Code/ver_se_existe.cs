using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ver_se_existe
/// </summary>
public class ver_se_existe
{
    public static void ver_matricula(TextBox txtEmail)
    {
        //ver se uma determinada matricula já existe na base de dados
        // TODO: Add constructor logic here
        //
        {
           
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("Select * from EmailSignUp where EmailId= @EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", txtEmail.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    MessageBox.Show("EmailId = " + dr[5].ToString() + " Already exist");
                    txtEmail.Clear();
                    break;
                }
            }
        }
}