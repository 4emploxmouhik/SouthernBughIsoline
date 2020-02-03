using Isoline;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controllers;

namespace UI.Views.Forms
{
    public partial class SetNodesValuesForm : Form, IView
    {
        public SetNodesValuesForm()
        {
            InitializeComponent();
        }
        
        public SetNodesValuesForm(IView parentView) : this()
        {
            // TODO: Добавить проверку входных параметров.
            ParentView = parentView;
        }

        public IController Controller => ParentView.Controller;
        public IView ParentView { get; set; }

        private void SetLevelsBtn_Click(object sender, EventArgs e)
        {
            // TODO: Добавить проверку Controller-а на null.
            List<(float Level, int Id)> levelsChangesKit = new List<(float Level, int Id)>();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                float level = (float)dataGridView.Rows[i].Cells["Level"].Value;
                int id = (int)dataGridView.Rows[i].Cells["Number"].Value;

                levelsChangesKit.Add((level, id));
            }

            ((MainController)Controller).ChangeLevelsOfNodes(levelsChangesKit);
            Hide();
        }

        private void SetNodesValuesForm_Load(object sender, EventArgs e)
        {
            // TODO: Добавить проверку Grid-а на null.
            DataTable nodesTable = new DataTable();
            nodesTable.Columns.Add("Number", typeof(int));
            nodesTable.Columns.Add("Name", typeof(string));
            nodesTable.Columns.Add("Level", typeof(float));

            foreach (var node in ((MainController)Controller).Grid.Nodes)
                nodesTable.Rows.Add(node.Id, node.Name, node.Level);

            dataGridView.DataSource = nodesTable;
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.Columns[2].Width = 50;
        }
    }
}
