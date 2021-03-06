using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        Cell[,] cells = new Cell[9, 9];
        readonly Random random = new Random();
        int showSolutionCount = 0;
        public Form1()
        {
            InitializeComponent();
            CreateCells();
            NewGame();
        }

        private void CreateCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].ForeColor = Color.DarkMagenta;

                    if (((i / 3) + (j / 3)) % 2 == 0)
                    {
                        cells[i, j].BackColor = Color.RosyBrown;
                    }
                    else
                    {
                        cells[i, j].BackColor = Color.LightSteelBlue;
                    }

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
            FindValueForNextCell(0, -1);
            var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            if (radioButton1.Checked)
            {
                for (int n = 0; n < 20; n++)
                {
                    int r = numbers[random.Next(0, numbers.Count)];
                    int p = numbers[random.Next(0, numbers.Count)];
                    
                    if (SingleSolutionForCell(r, p))
                    {
                        cells[r, p].Text = String.Empty;
                        cells[r, p].KeyPress += KeyPressed;
                        cells[r, p].IsLocked = false;
                    }
                }
            }

            if (radioButton2.Checked)
            {
                for (int n = 0; n < 10000; n++)
                {
                    int r = numbers[random.Next(0, numbers.Count)];
                    int p = numbers[random.Next(0, numbers.Count)];
                    
                    if (SingleSolutionForCell(r, p))
                    {
                        cells[r, p].KeyPress += KeyPressed;
                        cells[r, p].IsLocked = false;
                        cells[r, p].Text = String.Empty;
                    }
                }
            }
        }

        private bool SingleSolutionForCell(int i, int j)
        {
            int count = 0;
            for (int m = 1; m <= 9; m++)
            {
                if (IsValidSolution(m, i, j))
                {
                    count++;
                }
            }
            if (count == 1)
                return true;
            else
                return false;
        }

        private bool IsValidSolution(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != y && cells[x, i].Text == value.ToString())
                    return false;

                if (i != x && cells[i, y].Text == value.ToString())
                    return false;
            }

            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Text == value.ToString())
                        return false;
                }
            }
            return true;
        }
        private bool FindValueForNextCell(int i, int j)
        {
            if (++j > 8)
            {
                j = 0;

                if (++i > 8)
                    return true;
            }

            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int value;

            do
            {
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                value = numsLeft[random.Next(0, numsLeft.Count)];

                cells[i, j].Value = value;
                cells[i, j].Text = value.ToString();
                cells[i, j].IsLocked = true;

                numsLeft.Remove(value);
            }
            while (!IsValidNumber(value, i, j) || !FindValueForNextCell(i, j));

            return true;
        }

        private bool IsValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != y && cells[x, i].Value == value)
                    return false;

                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
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

            if(showSolutionCount > 0)
            {
                MessageBox.Show("You already checked the solution. Try a new game!");
            }
            else if (wrongCells.Any())
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
                {
                    cell.Clear();
                }
            }
        }

        private void ShowSolution_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if (!cell.IsLocked)
                {
                    cell.Text = cell.Value.ToString();
                    cell.ForeColor = Color.Blue;
                }
            }
            showSolutionCount++;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                cell.Clear();
            }
            showSolutionCount = 0;
            NewGame();
        }
    }
}
