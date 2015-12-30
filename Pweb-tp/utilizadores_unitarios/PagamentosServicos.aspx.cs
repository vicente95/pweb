using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class utilizadores_unitarios_PagamentosServicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ver_pagamento.pagamento(GridView1);
        Pesquisa_pagamento_utilizador.pesquisa(GridView1, TextBox1);
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "Não tem registos para pagamentos ainda ou não foi encontrada a sua procura!";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Red;
        Label2.Text = "Esta a pesquizar por: " + TextBox1.Text;
        Pesquisa_pagamento_utilizador.pesquisa(GridView1, TextBox1);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.ForeColor = System.Drawing.Color.Black;
        TextBox1.Text = "";
        Label2.Text = "Aqui poderá ver os valores de pagamento assim como consultar o estado de requesições que fez";
        Pesquisa_pagamento_utilizador.pesquisa(GridView1, TextBox1);
    }
}