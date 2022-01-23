using System.Windows.Forms;

namespace Sudoku
{
    class Cell : Button
    {
        public int Value { get; set; }
        public bool IsLocked { get; set; }

        public void Clear()
        {
            this.Text = string.Empty;
            this.IsLocked = false;
        }
    }
}
