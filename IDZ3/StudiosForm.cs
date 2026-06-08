using IDZ3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IDZ3
{
    public partial class StudiosForm : Form
    {
        public StudiosForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new AppDbContext())
            {
                var studios = context.Studios.OrderBy(s => s.Id).ToList();
                dgvStudios.DataSource = studios;

                if (dgvStudios.Columns.Contains("Id"))
                    dgvStudios.Columns["Id"].HeaderText = "№";
                if (dgvStudios.Columns.Contains("Name"))
                    dgvStudios.Columns["Name"].HeaderText = "Название студии";
                if (dgvStudios.Columns.Contains("Films"))
                    dgvStudios.Columns["Films"].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new StudioEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var context = new AppDbContext())
                {
                    var studio = new Studio { Name = form.StudioName };
                    context.Studios.Add(studio);
                    context.SaveChanges();
                }
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;

            var form = new StudioEditForm(studio.Name);
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var context = new AppDbContext())
                {
                    var studioToEdit = context.Studios.Find(studio.Id);
                    if (studioToEdit != null)
                    {
                        studioToEdit.Name = form.StudioName;
                        context.SaveChanges();
                    }
                }
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;

            using (var context = new AppDbContext())
            {
                var studioToDelete = context.Studios
                    .Include(s => s.Films)
                    .FirstOrDefault(s => s.Id == studio.Id);

                if (studioToDelete == null) return;

                if (studioToDelete.Films.Any())
                {
                    MessageBox.Show("Нельзя удалить студию, у которой есть фильмы!\n" +
                        "Сначала удалите все фильмы этой студии.", "Ошибка удаления",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Удалить студию \"{studio.Name}\"?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    context.Studios.Remove(studioToDelete);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}