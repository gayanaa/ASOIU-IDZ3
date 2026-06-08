using System;
using System.Windows.Forms;

namespace IDZ3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStudios_Click(object sender, EventArgs e)
        {
            var form = new StudiosForm();
            form.ShowDialog();
        }

        private void btnFilms_Click(object sender, EventArgs e)
        {
            var form = new FilmsForm();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm();
            form.ShowDialog();
        }
    }
}