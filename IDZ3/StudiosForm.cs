using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;

namespace IDZ3
{
    public partial class StudiosForm : Form
    {
        private AppDbContext _context;

        public StudiosForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadData();
        }

        private void LoadData()
        {
            var studios = _context.Studios.OrderBy(s => s.Id).ToList();
            dgvStudios.DataSource = studios;

            if (dgvStudios.Columns.Contains("Id"))
                dgvStudios.Columns["Id"].HeaderText = "№";
            if (dgvStudios.Columns.Contains("Name"))
                dgvStudios.Columns["Name"].HeaderText = "Название студии";
            if (dgvStudios.Columns.Contains("Films"))
                dgvStudios.Columns["Films"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new StudioEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var studio = new Studio { Name = form.StudioName };
                _context.Studios.Add(studio);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для редактирования");
                return;
            }

            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;
            var form = new StudioEditForm(studio.Name);

            if (form.ShowDialog() == DialogResult.OK)
            {
                studio.Name = form.StudioName;
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для удаления");
                return;
            }

            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;
            _context.Entry(studio).Collection(s => s.Films).Load();

            if (studio.Films.Any())
            {
                MessageBox.Show("Нельзя удалить студию, у которой есть фильмы");
                return;
            }

            if (MessageBox.Show($"Удалить студию \"{studio.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _context.Studios.Remove(studio);
                _context.SaveChanges();
                LoadData();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}