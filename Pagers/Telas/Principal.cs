using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagers
{
    public partial class Principal : Form
    {
        SqlConnection conn = new SqlConnection(Banco.conexao());
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        public Principal()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Pagamento"] != null) { Application.OpenForms["Pagamento"].Close(); }
            if (Application.OpenForms["Alterar"] != null) { Application.OpenForms["Alterar"].Close(); }
            Cadastro Cad = new Cadastro();
            Cad.Show();
            gridPagamentos.Visible = false;
            gridCliente.Visible = false;
            btnEfetuar.Visible = false;
           
            btnPago.Visible = false;
            btnAlteracao.Visible = false;
            BtnExcluir.Visible = false;
            btnEfetuar.Location = new Point(270, 219);
            btnPago.Location = new Point(708, 219);
         
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pagersDataSet1.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet1.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet1.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet1.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            comando.Connection = conn;
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
           
            btnAlteracao.Visible = true;
            BtnExcluir.Visible = true;
            gridPagamentos.Visible = false;
            gridCliente.Visible = true;
            CarregarCadastros();
            if (Application.OpenForms["Cadastro"] != null) { Application.OpenForms["Cadastro"].Close(); }
            if (Application.OpenForms["Pagamento"] != null) { Application.OpenForms["Pagamento"].Close(); }
            if (Application.OpenForms["Alterar"] != null) { Application.OpenForms["Alterar"].Close(); }
            btnEfetuar.Visible = false;
         
            btnPago.Visible = false;
            btnEfetuar.Location = new Point(270, 219);
            btnPago.Location = new Point(708, 219);
     
        }

        private void BtnDebitos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Cadastro"] != null) { Application.OpenForms["Cadastro"].Close(); }
            if (Application.OpenForms["Alterar"] != null) { Application.OpenForms["Alterar"].Close(); }
            gridCliente.Visible = false;
            btnEfetuar.Visible = true;
           
            btnPago.Visible = true;
            btnAlteracao.Visible = false;
            BtnExcluir.Visible = false;

        }       
        private void CarregarCadastros()
        {
            conn.Open();
            SqlDataAdapter SqlDa = new SqlDataAdapter("Select * FROM Cadastro", conn);
            DataTable dtbl = new DataTable();
            SqlDa.Fill(dtbl);
            gridCliente.DataSource = dtbl;
            conn.Close();
        }
        private void CarregarPagamentos()
        {
            conn.Open();
            SqlDataAdapter SqlDa = new SqlDataAdapter("Select * FROM Pagamento where status_pag='" + "Ok" + "' select * from Pagamento where status_pag='" + "Atraso" + "'", conn);
            DataTable dtbl = new DataTable();
            SqlDa.Fill(dtbl);
            gridPagamentos.DataSource = dtbl;
            conn.Close();
        }
        private void BtnEfetuar_Click(object sender, EventArgs e)
        {
            gridPagamentos.Visible = false;
            Pagamento pag = new Pagamento();
            pag.Show();
            btnEfetuar.Location = new Point(270, 59);
            btnPago.Location = new Point(708, 59);
          
        }
        private void BtnDevedor_Click(object sender, EventArgs e)
        {

            btnEfetuar.Location = new Point(270, 59);
            btnPago.Location = new Point(708, 59);
           
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            btnEfetuar.Location = new Point(270, 59);
            btnPago.Location = new Point(708, 59);

            gridPagamentos.Visible = true;
            CarregarPagamentos();
        }


        private void gridCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult = MessageBox.Show("Deseja excluir esse cliente? ", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    comando.CommandText = "Delete from Cadastro where cod_cadastro =" + gridCliente.CurrentRow.Cells[0].Value;
                    comando.ExecuteNonQuery();
                    conn.Close();

                }

            }
            CarregarCadastros();
        }

        private void btnCliente_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conn.Open();
                comando.CommandText = "DELETE FROM Cadastro where cod_cadastro=" + gridCliente.CurrentRow.Cells[0].Value;
                comando.ExecuteNonQuery();
                conn.Close();
                CarregarCadastros();
            }
        }

        private void btnAlteracao_Click(object sender, EventArgs e)
        {
            btnAlteracao.Visible = false;
            BtnExcluir.Visible = false;
            gridCliente.Visible = false;
            Alterar alt = new Alterar();
            alt.Show();
        }


    }
}
