using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private int c = 4;
        private Cell[,] cells;
        public Form1()
        {
            InitializeComponent();
            CreateCells();
            NewGame();
        }

        private void CreateCells()
        {
            cells = new Cell[c, c];
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;
                    cells[i, j].KeyPress += KeyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            int value;
            var cell = sender as Cell;

            if (cell.IsLocked)
            {
                return;
            }
            else 
            {
                int.TryParse(e.KeyChar.ToString(), out value);
                cell.Text = value.ToString();
                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void NewGame()
        {
            foreach (var cell in cells)
            {
                cell.Clear();
            }

            do
            { 
                findValueForNextCell(0, 0);
            }
            while (false);

        }

        Random random = new Random();

        private bool findValueForNextCell(int i, int j)
        {
            var numsLeft = new List<int>();

            for (i = 0; i < c; i++)
            { 
                for (int n = 1; n <= c; n++)
                {
                    numsLeft.Add(n);
                }

                for (j = 0; j < c; j++)
                {
                    int value;
                    do
                    {
                        value = numsLeft[random.Next(0, numsLeft.Count)];
                        if (IsValidNumber(value, i, j))
                        {
                            cells[i, j].Value = value;
                            cells[i, j].Text = value.ToString();
                        }
                    } while (!IsValidNumber(value, i, j));


                    numsLeft.Remove(value);
                }
            }
            return true;
            }

        private bool IsValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < c; i++)
            {
                if (i != y && cells[x, i].Value == value)
                    return false;

                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            for (int i = x - (x % (int)Math.Sqrt(c)); i < x - (x % (int)Math.Sqrt(c)) + (int)Math.Sqrt(c); i++)
            {
                for (int j = y - (y % (int)Math.Sqrt(c)); j < y - (y % (int)Math.Sqrt(c)) + (int)Math.Sqrt(c); j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var wrongCells = new List<Cell>();

            foreach (var cell in cells)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text))
                {
                    wrongCells.Add(cell);
                }
            }

            if (wrongCells.Any())
            {

                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show("Wrong inputs are marked in red");
            }
            else
            {
                MessageBox.Show("You Win");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if (cell.IsLocked == false)
                    cell.Clear();
            }
        }

        private void ShowSolution_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if (cell.IsLocked)
                {
                    cell.IsLocked = false;
                    cell.ForeColor = Color.Blue;
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            if (radioButton1.Checked)
            {
                c = 4;
            }
            else if (radioButton2.Checked)
            {
                c = 9;
            }

            CreateCells();
            NewGame();
        }
        }
}
