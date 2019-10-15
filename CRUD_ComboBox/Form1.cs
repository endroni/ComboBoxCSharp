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
            cboAlunos.ValueMember = "IdAluno";
            cboAlunos.DisplayMember = "Nome";
            cboAlunos.Text = "Selecione o aluno";
            LimpaFormulario();
        }

        private void LimpaFormulario()
        {
            foreach (var c in this.Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }
    }
}
