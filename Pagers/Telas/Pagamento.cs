using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagers
{
    public partial class Pagamento : Form
    {
        SqlConnection conn = new SqlConnection(Banco.conexao());
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        public Pagamento()
        {
            InitializeComponent();        
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pagersDataSet.Cadastro' table. You can move, or remove it, as needed.
            this.cadastroTableAdapter.Fill(this.pagersDataSet.Cadastro);
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet.Pagamento);
            cbCliente.SelectedIndex = -1;
            LimparDados();
            comando.Connection = conn;        
           
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string status = "Pendente";
            double valor = Convert.ToDouble(txtRecebido.Text);
            conn.Open();
            comando.CommandText = "Select * from Pagamento where status_pag='" + "Pendente" + "' and nome='"+cbCliente.Text+"'";
            dr = comando.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                conn.Open();
                double pago = Convert.ToDouble(txtRecebido.Text);             
                comando.CommandText = "Update Pagamento SET pago='" + pago + "',data_pag='" + DateTime.Now + "',status_pag='" + cbStatus.Text + "' WHERE cpf='" + txtCpf.Text + "'";
                comando.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Pagamento efetuado com sucesso!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pagamentoTableAdapter.InsertQueryP(cbCliente.Text, txtCpf.Text, valor, txtDataVenc.Text, status);
                LimparDados();
            }
            conn.Close();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText = "Select * from Cadastro Where nome='" + cbCliente.Text + "'";
            dr = comando.ExecuteReader();
            if (dr.Read())
            {
                txtCpf.Text = Convert.ToString(dr["cpf"]);               
                txtValor.Text = Convert.ToString(dr["valor"]);
                txtValor.Text = double.Parse(txtValor.Text).ToString("C2");
                txtDataVenc.Text = Convert.ToString(dr["data_ven"]);
            }
            conn.Close();
        }
        private void LimparDados()
        {
            txtCpf.Text = "";        
            txtDataVenc.Text = "";
            txtRecebido.Text = "";
            txtValor.Text = "";
        }

        private void pagamentoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pagamentoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pagersDataSet);

        }
    }  
}
