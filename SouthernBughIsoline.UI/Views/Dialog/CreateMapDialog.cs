using Isoline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views.Dialog
{
    public partial class CreateMapDialog : Form
    {
        List<Node> nodes = new List<Node>();
        List<Segment> segments = new List<Segment>();
        List<Cell> cells = new List<Cell>();

        CreateStep currentCreateStep;

        public CreateMapDialog()
        {
            InitializeComponent();

            firstStepPnl.Visible = true;
            currentCreateStep = CreateStep.ChoosePaths;

            SetDataGridViewColumns(currentCreateStep);
        }

        enum CreateStep
        {
            ChoosePaths, NodesCheck, SegmentsCreate, CellsCreate, None
        }

        public string MapSettingsPath { get => mapSettingsPathBox.Text; private set => mapSettingsPathBox.Text = value; }
        public string MapImagePath { get => imagePathBox.Text; private set => imagePathBox.Text = value; }
        public Grid Grid { get; private set; }


        public void SetNodes(List<Point> points)
        {
            if (points == null || points.Count == 0)
            {
                throw new ArgumentNullException("Points list is null or empty.");
            }

            firstStepPnl.Visible = false;
            SetDataGridViewColumns(CreateStep.NodesCheck);

            int id = 0;

            foreach (var point in points)
            {
                nodes.Add(new Node(point, id, 0) { Name = $"Node_{id}" });
                dataGridView.Rows.Add(nodes[id].Id, nodes[id].Name, nodes[id].Location.X, nodes[id].Location.Y);

                id++;
            }
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            switch (currentCreateStep)
            {
                case CreateStep.ChoosePaths:
                    DialogResult = DialogResult.Cancel;
                    Close();

                    break;
                case CreateStep.NodesCheck:
                    currentCreateStep = CreateStep.ChoosePaths;
                    firstStepPnl.Visible = true;

                    break;
                case CreateStep.SegmentsCreate:
                    currentCreateStep = CreateStep.NodesCheck;

                    SetDataGridViewColumns(currentCreateStep);

                    if (nodes.Count > 0)
                    {
                        foreach (var node in nodes)
                            dataGridView.Rows.Add(node.Id, node.Name, node.Location.X, node.Location.Y);
                    }

                    break;
                case CreateStep.CellsCreate:
                    currentCreateStep = CreateStep.SegmentsCreate;

                    SetDataGridViewColumns(currentCreateStep);

                    if (segments.Count > 0)
                    {
                        foreach (var segment in segments)
                            dataGridView.Rows.Add(segment.Id, segment.Name, segment.Nodes[0].Id, segment.Nodes[1].Id);
                    }

                    break;
            }
        }

        private void ChoosePathBtn(object sender, EventArgs e)
        {
            switch (((Button)sender).Tag)
            {
                case "openFile":
                    OpenFileDialog openFileDialog = new OpenFileDialog()
                    {
                        Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        MapImagePath = openFileDialog.FileName;

                    break;
                case "saveFile":
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "Xml files (*.xml)|*.xml"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        MapSettingsPath = saveFileDialog.FileName;

                    break;
            }
        }

        private DataGridViewComboBoxColumn CreateDataGridViewComboBoxColumn<T>(List<T> list, string headerText)
        {
            DataGridViewComboBoxColumn comboBoxColummn = new DataGridViewComboBoxColumn();

            foreach (var item in list) comboBoxColummn.Items.Add(item);

            comboBoxColummn.HeaderText = headerText;
            comboBoxColummn.Name = headerText;
            comboBoxColummn.DisplayMember = "Name";
            comboBoxColummn.ValueMember = "Id";

            return comboBoxColummn;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            switch (currentCreateStep)
            {
                case CreateStep.ChoosePaths:
                    currentCreateStep = CreateStep.NodesCheck;
                    DialogResult = DialogResult.OK;
                    Hide();

                    break;
                case CreateStep.NodesCheck:
                    currentCreateStep = CreateStep.SegmentsCreate;

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                        nodes[i].Name = (string)dataGridView.Rows[i].Cells["Name"].Value;

                    SetDataGridViewColumns(currentCreateStep);

                    break;
                case CreateStep.SegmentsCreate:
                    currentCreateStep = CreateStep.CellsCreate;
                    segments.Clear();

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        Node start = nodes.Find(n => n.Id == Convert.ToInt32(row.Cells["Start"].Value));
                        Node end = nodes.Find(n => n.Id == Convert.ToInt32(row.Cells["End"].Value));
                        int id = Convert.ToInt32(row.Cells["Id"].Value);
                        string name = (string)row.Cells["Name"].Value;
                        bool isEdge = Convert.ToBoolean(row.Cells["IsEdge"].Value);

                        segments.Add(new Segment(start, end, id) { Name = name, IsEdge = isEdge });
                    }

                    SetDataGridViewColumns(currentCreateStep);

                    break;
                case CreateStep.CellsCreate:
                    cells.Clear();

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        Segment top = segments.Find(s => s.Id == Convert.ToInt32(row.Cells["Top"].Value));
                        Segment left = segments.Find(s => s.Id == Convert.ToInt32(row.Cells["Left"].Value));
                        Segment right = segments.Find(s => s.Id == Convert.ToInt32(row.Cells["Right"].Value));
                        Segment bottom = segments.Find(s => s.Id == Convert.ToInt32(row.Cells["Bottom"].Value));
                        int id = Convert.ToInt32(row.Cells["Id"].Value);
                        string name = (string)row.Cells["Name"].Value;

                        cells.Add(new Cell(top, left, right, bottom, id) { Name = name });
                    }

                    Hide();
                    Grid = new Grid(cells);
                    DialogResult = DialogResult.OK;

                    break;
            }
        }

        private void SetDataGridViewColumns(CreateStep step)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Id", Name = "Id" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", Name = "Name" });

            switch (step)
            {
                case CreateStep.NodesCheck:
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "X", Name = "X" });
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Y", Name = "Y" });

                    break;
                case CreateStep.SegmentsCreate:
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(nodes, "Start"));
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(nodes, "End"));
                    dataGridView.Columns.Add(new DataGridViewCheckBoxColumn
                    {
                        HeaderText = "Is edge",
                        Name = "IsEdge",
                        ThreeState = false
                    });

                    break;
                case CreateStep.CellsCreate:
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(segments, "Top"));
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(segments, "Left"));
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(segments, "Right"));
                    dataGridView.Columns.Add(CreateDataGridViewComboBoxColumn(segments, "Bottom"));

                    break;
            }
        }

        private void RemoveRowBtn_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Remove(dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex]);
        }


    }
}
