using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] elements = textBox1.Text.Split(' ');
            int[] intArray = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                if (Int32.TryParse(elements[i], out int value))
                {
                    intArray[i] = value;
                }
                else
                {
                    MessageBox.Show("Неверный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Array<int>.Delegate delegateMethod = PrintArray;
            Array<int> array = new Array<int>(intArray);
            array.ShellSort(delegateMethod);

            textBox2.Text = "Отсортированный массив: ";
            foreach (int element in array.array)
            {
                textBox2.Text += element + " ";
            }
            textBox2.Text += Environment.NewLine;
            textBox2.Text += "Диапазон: " + array.FindRange(delegateMethod);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void PrintArray(int[] array)
        {
            textBox2.Text = "Отсортированный массив: ";
            foreach (int element in array)
            {
                textBox2.Text += element + " ";
            }
            textBox2.Text += Environment.NewLine;
        }
    }
}
