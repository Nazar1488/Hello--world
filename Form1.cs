using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Завдання_4__String_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                MessageBox.Show("Field is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Binary.Checked && !IncDec.Checked)
            {
                MessageBox.Show("Choose one of the editing options!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string[] incDec = new string[] { "++", "--" };
            string[] bin_op = new string[] { "+", "-", "*", "/", "%", "&", ":", "^", "<", ">",  "=", "(", ")", "[", "]" };
            string[] arr = InputTextBox.Lines;
            if (Binary.Checked)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    for (int j = 0; j < arr[i].Length; ++j)
                    {
                        for (int k = 0; k < bin_op.Length; ++k)
                        {
                            if (arr[i][j].ToString() == bin_op[k])
                            {
                                if (j == 0)
                                {
                                    if (arr[i][j + 1] != ' ' && arr[i][j+1] != '+' && arr[i][j + 1] != '-')
                                    {
                                        arr[i] = arr[i].Insert(++j, " ");
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (j == arr[i].Length - 1) 
                                {
                                    if (arr[i][j - 1] != ' ')
                                    {
                                        arr[i] = arr[i].Insert(j++, " ");
                                    }
                                    if (arr[i][j - 1] != '+' && arr[i][j - 1] != '-')
                                    {
                                        continue;
                                    }
                                }
                                else if (arr[i][j + 1] != ' ' && arr[i][j - 1] != ' ' && arr[i][j + 1] != '+' && arr[i][j + 1] != '-' && arr[i][j - 1] != '+' && arr[i][j - 1] != '-')
                                {
                                    arr[i] = arr[i].Insert(j++, " ");
                                    arr[i] = arr[i].Insert(++j, " ");

                                }
                                else if (arr[i][j + 1] != ' ' && arr[i][j + 1] != '+' && arr[i][j + 1] != '-')
                                {
                                    arr[i] = arr[i].Insert(++j, " ");
                                }
                                else if (arr[i][j - 1] != ' ' && arr[i][j - 1] != '+' && arr[i][j - 1] != '-')
                                {
                                    arr[i] = arr[i].Insert(j++, " ");
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            if (IncDec.Checked)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    for (int j = 0; j < arr[i].Length; ++j)
                    {
                        if (arr[i].Contains(" ++"))
                        {
                            arr[i] = arr[i].Replace(" ++", "++");
                        }
                        if (arr[i].Contains("++ "))
                        {
                            arr[i] = arr[i].Replace("++ ", "++");
                        }
                        if (arr[i].Contains(" --"))
                        {
                            arr[i] = arr[i].Replace(" --", "--");
                        }
                        if (arr[i].Contains("-- "))
                        {
                            arr[i] = arr[i].Replace("-- ", "--");
                        }
                    }
                }
            }
            InputTextBox.Lines = arr;
            MessageBox.Show("Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InputTextBox.Lines = File.ReadAllLines("Code.txt");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IOException i)
            {
                MessageBox.Show(i.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Loaded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void writeToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                MessageBox.Show("Field is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                File.WriteAllLines("Code.txt", InputTextBox.Lines);
                Process.Start("Code.txt");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException i)
            {
                MessageBox.Show(i.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadFromFileAnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                InputTextBox.Lines = File.ReadAllLines(ofd.FileName);
                MessageBox.Show("Loaded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                MessageBox.Show("Field is empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "ResultCode.txt";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(savefile.FileName, InputTextBox.Lines);
                MessageBox.Show("Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(savefile.FileName);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("©Created by Nazar Homeniuk, AMI-25", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
