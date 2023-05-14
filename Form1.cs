using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicativo_Pollock_Seven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string vqueryAluno = @"SELECT N_IDALUNO FROM tb_alunos";


            cb_id.Items.Clear();

            cb_id.DataSource = Banco.dql(vqueryAluno);
            cb_id.DisplayMember = "T_NOMEALUNO";
            cb_id.ValueMember = "N_IDALUNO";


        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelecionado = 0;

            if (cb_id.SelectedValue != null && int.TryParse(cb_id.SelectedValue.ToString(), out idSelecionado))
            {
                string vqueryDadosAluno = @"
                    SELECT
                        T_NOMEALUNO,
                        T_TELEFONE,
                        T_STATUS
                    FROM 
                        tb_alunos
                    WHERE 
                        N_IDALUNO=" + idSelecionado;

                DataTable dtDadosAluno = Banco.dql(vqueryDadosAluno);

                if (dtDadosAluno.Rows.Count > 0)
                {
                    tb_nome.Text = dtDadosAluno.Rows[0]["T_NOMEALUNO"].ToString();
                    mtb_telefone.Text = dtDadosAluno.Rows[0]["T_TELEFONE"].ToString();
                    tb_status.Text = dtDadosAluno.Rows[0]["T_STATUS"].ToString();
                }
                else
                {
                    tb_nome.Text = "";
                    tb_status.Text = "";
                }


            }



        }

        private void tb_nome_TextChanged(object sender, EventArgs e)
        {
            int idSelecionado = 0;

            if (cb_id.SelectedValue != null && int.TryParse(cb_id.SelectedValue.ToString(), out idSelecionado))
            {
                string vquerDobras = @"
                SELECT 

                    T_DATA as 'Data',
                    N_IDALUNO as 'ID',
                    N_SUBESCAPULAR as 'Subescapular',
                    N_TRICIPIAL as 'Tricípial',
                    N_AXILARMEDIA as 'Axilar-Média',
                    N_SUPRAILIACA as 'Supra-Ilíaca',
                    N_PEITORAL as 'Peitoral',
                    N_ABDOMINAL as 'Abdominal',
                    N_COXA as 'Coxa'
                
                FROM
                    tb_pollock
                WHERE
                    N_IDALUNO=" + idSelecionado;

                DataTable dobras = Banco.dql(vquerDobras);

                if (dobras.Rows.Count > 0)
                {
                    dgv_pollock.DataSource = Banco.dql(vquerDobras);

                    dgv_pollock.Columns[0].Width = 80;
                    dgv_pollock.Columns[1].Width = 80;
                    dgv_pollock.Columns[2].Width = 80;
                    dgv_pollock.Columns[3].Width = 80;
                    dgv_pollock.Columns[4].Width = 80;
                    dgv_pollock.Columns[5].Width = 80;
                    dgv_pollock.Columns[6].Width = 80;
                    dgv_pollock.Columns[7].Width = 70;
                }
                
            }
        }

        private void dgv_pollock_Enter(object sender, EventArgs e)
        {

        }
    }
}

