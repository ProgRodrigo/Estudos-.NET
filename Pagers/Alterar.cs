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
    public partial class Alterar : Form
    {
        SqlConnection conn = new SqlConnection(Banco.conexao());
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        public Alterar()
        {
            InitializeComponent();
        }

        private void cadastroBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
           
       

        }

        private void Alterar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pagersDataAce
            comando.Connection = conn;
            cbSelecao.SelectedIndex = -1;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = true;
            conn.Open();
            comando.CommandText = "SELECT * FROM Cadastro WHERE nome='" + cbSelecao.Text + "'";
            dr = comando.ExecuteReader();
            if (dr.Read())
            {
                txtNome.Text = Convert.ToString(dr["nome"]);
                txtCpf.Text = Convert.ToString(dr["cpf"]);
                txtVeiculo.Text = Convert.ToString(dr["veiculo"]);
                txtPlaca.Text = Convert.ToString(dr["placa"]);
                txtAluguel.Text = Convert.ToString(dr["aluguel"]);
                txtValor.Text = Convert.ToString(dr["valor"]);
                txtData.Text = Convert.ToString(dr["dia_ven"]);

            }
            conn.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText ="UPDATE Cadastro SET nome='"+txtNome.Text+"',cpf='"+txtCpf.Text+"',veiculo='"+txtVeiculo.Text+"',placa='"+txtPlaca.Text+"',aluguel='"+txtAluguel.Text+"',valor='"+txtValor.Text+"',dia_ven='"+txtData.Text+"' WHERE cpf =('"+txtCpf.Text+"')";
            comando.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Cadastro atualizado!", "- Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparDados();   
        }
        private void LimparDados()
        {
            txtNome.Text = "";
            txtCpf.Text = "";
            txtVeiculo.Text = "";
            txtAluguel.SelectedIndex = -1;
            txtData.Text = "";
            txtPlaca.Text = "";
            txtValor.Text = "";
        
        }
    }
}
