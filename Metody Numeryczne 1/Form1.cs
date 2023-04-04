using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotekaNumeryczne.AlgebraLiniowa;

namespace Metody_Numeryczne_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            generuj();
        }

        int n;
        void generuj()
        {
            n = (int)numericUpDown1.Value;
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            dataGridView2.RowCount = n;
            dataGridView3.RowCount = n;
            dataGridView2.ColumnCount = 1;
            dataGridView3.ColumnCount = 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            generuj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random toss = new Random();

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dataGridView1[i, j].Value = toss.Next(-100, 100);
                }
                dataGridView3[0, i].Value = toss.Next(-100, 100);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            double[,] A;
            double[] B, X;

            A = new double[n + 1, n + 1];
            B = new double[n + 1];
            X = new double[n + 1];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    A[i+1,j+1] = double.Parse(dataGridView1[j,i].Value.ToString());
                    B[i+1] = double.Parse(dataGridView3[0,i].Value.ToString());
                }
            }

            int z = MetodaGaussa.Rozwiaz(A,B,X,1e-6);

            for(int i = 0; i<n; i++)
            {
                dataGridView2[0,i].Value = X[i+1].ToString("0.00");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random toss = new Random();
            double suma = 0;
            double s;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s = toss.Next(-100, 100);
                    dataGridView1[j, i].Value = s;
                    suma += s;
                }
                dataGridView3[0, i].Value = suma;
                suma = 0;
            }
        }
    }
}
