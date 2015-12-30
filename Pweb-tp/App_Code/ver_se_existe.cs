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
    public static int ver_email(TextBox txtEmail)
    {
        //ver se uma determinada matricula já existe na base de dados
        // TODO: Add constructor logic here
        //
        int n=0;
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("Select Email from Utilizador where Email= @EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", txtEmail.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    //MessageBox.Show("EmailId = " + dr[5].ToString() + " Already exist");
                    //txtEmail.Clear();
                    n = 1;
                    break;
                }
            }
        con.Close();
        return n;
    }



    public static int ver_se_carro_tem_req(int idcarro)
    {
        //ver se uma determinado carro tem requesição já existe na base de dados
        // TODO: Add constructor logic here
        //
        int n = 0;
        string constring = ConfigurationManager.ConnectionStrings["ConnectionString_usr"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("SELECT Requisicao.Id_requisicao FROM Requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao WHERE(Requisicao.Estado_pagamento = @x1) AND (Requisicao_carro.Id_carro = @x2)", con);
        cmd.Parameters.AddWithValue("@x1", "Por pagar");
        cmd.Parameters.AddWithValue("@x2", idcarro);
        con.Open();
        try {

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    //MessageBox.Show("EmailId = " + dr[5].ToString() + " Already exist");
                    //txtEmail.Clear();
                    n = 1;
                    break;
                }
            }
        }
        catch
        {

        }
       
        con.Close();
        return n;
    }



}