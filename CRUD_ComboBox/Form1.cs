using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_ComboBox
{
    public partial class Form1 : Form
    {
        int codigoAluno;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void CarregaDados()
        {
            cboAlunos.DataSource = alunoModel.GetAlunos();
            cboAlunos.ValueMember = "id_aluno";
            cboAlunos.DisplayMember = "Nome";
            cboAlunos.Text = "Selecione o aluno";
            LimpaFormulario();
        }

        private void LimpaFormulario()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }

        private void cboAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            alunoEnt aluno = new alunoEnt();

            codigoAluno = Convert.ToInt32(((DataRowView)cboAlunos.SelectedItem)["id_aluno"]);

            aluno = alunoModel.GetAluno(codigoAluno);
            PreencheDados(aluno);
        }

        private void PreencheDados(alunoEnt aluno)
        {
            txtID.Text = aluno.IdAluno.ToString();
            txtNome.Text = aluno.Nome;
            txtEndereco.Text = aluno.Email;
            txtTelefone.Text = aluno.Telefone;
        }
    
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (btnIncluir.Text.Equals("Incluir"))
            {
                btnIncluir.Text = "Salvar";
                LimpaFormulario();
                txtID.Enabled = false;
                txtNome.Focus();
            }
            else if (btnIncluir.Text.Equals("Salvar"))
            {
                btnIncluir.Text = "Incluir";
                txtID.Enabled = true;
                try
                {
                    alunoEnt aluno = new alunoEnt();

                    aluno.Nome = txtNome.Text;
                    aluno.Endereco = txtEndereco.Text;
                    aluno.Email = txtEmail.Text;

                    alunoModel.Add(aluno);
                    CarregaDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                alunoEnt aluno = new alunoEnt();

                aluno.IdAluno = Convert.ToInt32(txtID.Text);
                aluno.Nome = txtNome.Text;
                aluno.Endereco = txtEndereco.Text;
                aluno.Email = txtEmail.Text;
                aluno.Telefone = txtTelefone.Text;

                alunoModel.Update(aluno);
                CarregaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                alunoModel.Delete(codigoAluno);
                CarregaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }
    }
}

