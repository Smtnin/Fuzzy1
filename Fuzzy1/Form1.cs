using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //это быдло-код по книге "Методы и технологии искусственного интелелекта" Л.Рутковский
            // стр. 162 Пример 4.52
            // Йиихаа

            InitializeComponent();            
            InitializeDataGridView();
            numericUpDown1.Value = 4.3m;
            numericUpDown2.Value = 4.8m;
            numericUpDown3.Value = 4.2m;
            numericUpDown4.Value = 4.6m;
            InitGRAPH();

            StreamReader f = new StreamReader("test.txt");
            string s;
            const int n = 20;
            double[] a = new double[n];
            string[] buf;
            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(' ');
                double sum = 0;
                for (int i = 0; i < buf.Length; ++i)
                {
                    a[i] = Convert.ToDouble(buf[i]);
                    sum += a[i];
                }



            }
            double a1 = Convert.ToDouble(numericUpDown1.Value);
        }

        private void InitGRAPH()
        {
            int wX;
            int hX;
            double xF, yF;
            double[] dot;

            wX = pictureBox1.Width;
            hX = pictureBox1.Height; //Значение высоты

            // Система Координат
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
            flagGraphics.DrawLine(myPen, 25, hX-15, wX, hX-15);
            flagGraphics.DrawLine(myPen, 30, 0, 30, hX-12);
            Font dew = new Font("Veranda", 8, FontStyle.Bold);
            System.Drawing.Brush Brush = new SolidBrush(Color.Gray);
            flagGraphics.DrawString("     4,0    4,2    4,4    4,6    4,8    5,0         x", dew, Brush, 3, hX-12);

            flagGraphics.DrawString("0", dew, Brush, 6, hX - 22);
            flagGraphics.DrawString("0,2", dew, Brush, 0, hX - 45);
            flagGraphics.DrawString("0,4", dew, Brush, 0, hX - 75);
            flagGraphics.DrawString("0,6", dew, Brush, 0, hX - 105);
            flagGraphics.DrawString("0,8", dew, Brush, 0, hX - 135);
            flagGraphics.DrawString("1,0", dew, Brush, 0, hX - 165);
            flagGraphics.DrawString("u", dew, Brush, 6, hX - 195);
            
            // График
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            xF = 0;
            yF = (xF - numericUpDown1.Value) / (numericUpDown2.Value - numericUpDown1.Value);
            flagGraphics.DrawLine(myPen, 25, hX - 15, wX, hX - 15);
            flagGraphics.DrawLine(myPen, 30, 0, 30, hX - 12);
            /*
             *         
             * numericUpDown1.Value = 4.3m;
             * numericUpDown2.Value = 4.8m;
             * numericUpDown3.Value = 4.2m;
             * numericUpDown4.Value = 4.6m;
             * 
             * 
             * y=0 для 2<=x<=4,3
             * y=(x-4,3)/0,5 для 4,3<=x<=4,8
             * y=1 для 4,8<=x<=5
             * 
             * y=0 для 2<=x<=4,2
             * y=(x-4,2)/0,4 для 4,2<=x<=4,6
             * y=1 для 4,6<=x<=5
             *
             * -------------------------------
             * y=0 для 2<=x<=numericUpDown1.Value
             * y=(x-numericUpDown1.Value)/(numericUpDown2.Value-numericUpDown1.Value) для numericUpDown1.Value<=x<=numericUpDown2.Value
             * y=1 для numericUpDown2.Value<=x<=5
             * 
             * y=0 для 2<=x<=numericUpDown3.Value
             * y=(x-numericUpDown3.Value)/(numericUpDown4.Value-numericUpDown3.Value) для numericUpDown3.Value<=x<=numericUpDown4.Value
             * y=1 для numericUpDown4.Value<=x<=5
             */

            pictureBox1.Image = flag;


        }

        private void InitializeDataGridView()
        {
            // Create an unbound DataGridView by declaring a column count.
            dataGridView2.ColumnCount = 6;
            dataGridView2.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView2.Columns[0].Name = "Студент";
            dataGridView2.Columns[1].Name = "Электроника";
            dataGridView2.Columns[2].Name = "Информатика";
            dataGridView2.Columns[3].Name = "Математика";
            dataGridView2.Columns[4].Name = "Английский";
            dataGridView2.Columns[5].Name = "Немецкий";

            // Populate the rows.
            string[] row1 = new string[] { "Катя(х1)", "4,8", "5,0", "4,7", "4,3", "4,7" };
            string[] row2 = new string[] { "Маша(х2)", "4,4", "4,7", "4,8", "4,4", "4,4" };
            string[] row3 = new string[] { "Аня(х3)", "4,9", "4,9", "4,6", "4,7", "4,3" };
            string[] row4 = new string[] { "Томек(х4)", "4,5", "4,8", "4,9", "5,0", "4,5" };
            string[] row5 = new string[] { "Яцек(х5)", "5,0", "4,6", "4,7", "4,4", "5,0" };
            string[] row6 = new string[] { "Михаил(х6)", "4,9", "4,5", "5,0", "4,5", "4,4" };
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            foreach (string[] rowArray in rows)
            {
                dataGridView2.Rows.Add(rowArray);
            }
        }
    }
       
}
