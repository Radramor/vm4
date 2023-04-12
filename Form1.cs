using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vm4
{
    public partial class Form1 : Form
    {
        List<float> X = new List<float>();
        List<float> Y = new List<float>();
        public Form1()
        {


            InitializeComponent();
            
        }
        public void ReadDataGridView()
        {
            X.Clear();
            Y.Clear();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                X.Add(int.Parse(dataGridView1.Rows[0].Cells[i].Value.ToString()));
                Y.Add(int.Parse(dataGridView1.Rows[1].Cells[i].Value.ToString()));
            }
            
        }

        public List<List<float>> CountC()
        {
            List<float> C = new List<float>();
            float h = X[1] - X[0];
            List<List<float>> matrix1= new List<List<float>>();

            for (int i = 0; i < X.Count - 2; i++)
                matrix1.Add(new List<float>());

            for (int i = 0; i < matrix1.Count; i++)
            {
                for (int j = 0; j < X.Count - 2; j++)
                {
                    if (i == 0)
                    {
                        if (i == j)
                            matrix1[i].Add(4 * h);
                        else if (j - i == 1)
                            matrix1[i].Add(h);
                        else
                            matrix1[i].Add(0);
                    }
                    else if (i == X.Count - 3)
                    {
                        if (i == j)
                            matrix1[i].Add(4 * h);
                        else if (i - j == 1)
                            matrix1[i].Add(h);
                        else
                            matrix1[i].Add(0);
                    }
                    else
                    {
                        if (i == j)
                            matrix1[i].Add(4*h);
                        else if (i - j == 1 || j - i == 1)
                            matrix1[i].Add(h);
                        else 
                            matrix1[i].Add(0);
                    }
                }
            }    
           
            return matrix1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadDataGridView();
            List<List<float>> C = CountC();
        }
    }
}
