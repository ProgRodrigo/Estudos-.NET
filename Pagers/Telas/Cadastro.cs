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
    public partial class Cadastro : Form
    {
        SqlConnection conn = new SqlConnection(Banco.conexao());
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        bool Validacao = false;
        int dia =30;
    
        public Cadastro()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string status = "Pendente";
            Validacoes();
            if (lblNome.Visible == true || lblCpf.Visible == true || lblVeiculo.Visible ==true || lblAluguel.Visible ==true||lblPlaca.Visible ==true||lblVenc.Visible ==true||lblValor.Visible ==true)
            {
                MessageBox.Show("Existe dados incorretos! Por favor verifique os dados informados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Validacao = true;
            }
            if (Validacao == true)
            {
               
             double valor = Convert.ToDouble(txtValor.Text);        
             cadastroTableAdapter.InsertQueryC(txtNome.Text,txtCpf.Text,txtVeiculo.Text,txtPlaca.Text,txtAluguel.Text,valor,txtData.Text);            
             pagamentoTableAdapter.InsertQueryP(txtNome.Text, txtCpf.Text, valor,txtData.Text,status);                  
                
                MessageBox.Show("Concluido!");
                //LimparDados();
                /* mes = 01;
            data = DateTime.Today;
            MessageBox.Show("Esta data foi recebida:" + data);
            data = data.AddMonths(Convert.ToInt32(mes));
            MessageBox.Show("Alteração:" + data);*/

            }

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet.Cadastro' table. You can move, or remove it, as needed.
            this.cadastroTableAdapter.Fill(this.pagersDataSet.Cadastro);
            // TODO: This line of code loads data into the 'pagersDataSet.Pagamento' table. You can move, or remove it, as needed.
            this.pagamentoTableAdapter.Fill(this.pagersDataSet.Pagamento);
            // TODO: This line of code loads data into the 'pagersDataSet.Cadastro' table. You can move, or remove it, as needed.
            this.cadastroTableAdapter.Fill(this.pagersDataSet.Cadastro);


            comando.Connection = conn;

        }       

        private void txtCpf_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (txtNome.Text.Length < 9) { lblNome.Visible = true; }
                else { lblNome.Visible = false; }
            }
        }

        private void txtVeiculo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (txtCpf.MaskFull == false) { lblCpf.Visible = true; }
                else { lblCpf.Visible = false; }
            }               
        }

        private void txtPlaca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) {
                if (txtVeiculo.Text.Length < 3) { lblVeiculo.Visible = true; }
                else { lblVeiculo.Visible = false; }
            }                
        }

        private void txtAluguel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) {
                if (txtPlaca.MaskFull == false) { lblPlaca.Visible = true; }
                else { lblPlaca.Visible = false; }
            }                
        }

        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) {
                if (txtAluguel.Text == "") { lblAluguel.Visible = true; }
                else { lblAluguel.Visible = false; }
            }
                
        }

        private void txtData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) {
                if (txtValor.Text == "") { lblValor.Visible = true; }
                else { lblValor.Visible = false; }
            }                
        }

        private void btnSair_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) {
                if (txtData.Text == "") { lblVenc.Visible = true; }
                else { lblVenc.Visible = false; btnCadastrar.Enabled = true; }
            }
                
        }

        private void Validacoes()
        {
            if (txtNome.Text.Length < 9) { lblNome.Visible = true; }
            else { lblNome.Visible = false; }
            if (txtCpf.MaskFull == false) { lblCpf.Visible = true; }
            else { lblCpf.Visible = false; }
            if (txtVeiculo.Text.Length < 3) { lblVeiculo.Visible = true; }
            else { lblVeiculo.Visible = false; }    
            if (txtPlaca.MaskFull == false) { lblPlaca.Visible = true; }
            else { lblPlaca.Visible = false; }
            if (txtAluguel.Text == "") { lblAluguel.Visible = true; }
            else { lblAluguel.Visible = false; }
            if (txtValor.Text == "") { lblValor.Visible = true; }
            else { lblValor.Visible = false; }
            if (txtData.Text == "") { lblVenc.Visible = true; }
            else { lblVenc.Visible = false; }
        }

        private void cadastroBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cadastroBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.pagersDataSet);

        }
        private void LimparDados()
        {
            txtNome.Text = "";
            txtCpf.Text = "";
            txtVeiculo.Text = "";
            txtPlaca.Text = "";
            txtAluguel.SelectedIndex = -1;
            txtData.SelectedIndex = -1;
            txtValor.Text = "";
        }

        private void cadastroBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.cadastroBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pagersDataSet);

        }

        private void cadastroBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.cadastroBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pagersDataSet);

        }
    }
}
