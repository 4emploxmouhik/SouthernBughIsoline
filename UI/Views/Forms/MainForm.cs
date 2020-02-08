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
using UI.Views.Forms.Dialogs;
using UI.Views.UC;

namespace UI.Views.Forms
{
    public partial class MainForm : Form, IView
    {
        private MainController mainController;

        private CreateMapDialog createMapDialog;
        private LevelLinesViewUC levelLinesViewUC;
        private SetNodesValuesForm setNodesValuesForm;

        private bool isLevelLinesBuilded;
        
        public MainForm()
        {
            InitializeComponent();

            mainController = new MainController();

            createMapDialog = new CreateMapDialog();
            setNodesValuesForm = new SetNodesValuesForm(this);
            levelLinesViewUC = new LevelLinesViewUC() { Dock = DockStyle.Fill, Parent = this };

            Controls.Add(levelLinesViewUC);
            levelLinesViewUC.BringToFront();

            editLevelLineBtn.Checked = false;
            isLevelLinesBuilded = false;
        }

        public IController Controller => mainController;

        private bool IsLevelLinesBuilded
        {
            get => isLevelLinesBuilded;
            set
            {
                isLevelLinesBuilded = value;

                editLevelLineBtn.Enabled = isLevelLinesBuilded;
                editLevelBtn.Enabled = isLevelLinesBuilded;
            }
        }
        public bool IsNodeSetModeOn { get; private set; }
        public List<Point> Nodes { get; private set; }


        private void BuildLevelLinesBtn_Click(object sender, EventArgs e)
        {
            using (ChooseLevelsDialog cld = new ChooseLevelsDialog())
            {
                if (cld.ShowDialog() == DialogResult.OK)
                {
                    mainController.BuildLevelLines(cld.Levels.ToArray(), false, false);

                    levelLinesViewUC.LevelLines = mainController.GetLevelLines();
                    levelLinesViewUC.Segments = mainController.Grid.Segments;
                    levelLinesViewUC.Nodes = mainController.Grid.Nodes;

                    levelLinesViewUC.DrawLevelLines();

                    levelLinesViewUC.IsLevelLinesBuilded = true;
                    IsLevelLinesBuilded = true;
                }
            }
        }

        private void EditNodesLevelsBtn_Click(object sender, EventArgs e)
        {
            // TODO: Добавить проверку на наличие узлов.
            setNodesValuesForm.Show();
        }

        private void OpenMapBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Xml files (*.xml)|*.xml" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    mainController.LoadMapFromXmlFile(ofd.FileName);

                    levelLinesViewUC.SetMapImage(mainController.MapImage);
                }
            }
        }

        private void EditLevelLineBtn_Click(object sender, EventArgs e)
        {
            editLevelLineBtn.Checked = !editLevelLineBtn.Checked;

            levelLinesViewUC.EditLines(editLevelLineBtn.Checked);
        }

        private void EditLevelBtn_Click(object sender, EventArgs e)
        {
            editLevelBtn.Checked = !editLevelBtn.Checked;

            levelLinesViewUC.IsEditLevelModeOn = editLevelBtn.Checked;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveImageBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG file (*.png)|*.png" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    levelLinesViewUC.SaveImage(sfd.FileName);
                }
            }
        }

        /* Обработчики создания новой карты */
        private void CreateMapBtn_Click(object sender, EventArgs e)
        {
            if (createMapDialog.ShowDialog() == DialogResult.OK)
            {
                Nodes = new List<Point>();
                NodeSetMode(true);
            }
        }

        private void NodeSetMode(bool isOn)
        {
            IsNodeSetModeOn = isOn;
            goNextBtn.Visible = isOn;

            if (isOn)
            {
                goNextBtn.Click += GoNextBtnCreateMap_Click;
            }
            else
            {
                goNextBtn.Click -= GoNextBtnCreateMap_Click;
            }

            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.Enabled = !isOn;
            }

            levelLinesViewUC.SetMapImage(Image.FromFile(createMapDialog.MapImagePath));
        }

        private void GoNextBtnCreateMap_Click(object sender, EventArgs e)
        {
            createMapDialog.SetNodes(Nodes);

            if (createMapDialog.ShowDialog() == DialogResult.OK)
            {
                mainController.SaveMapToXmlFile(createMapDialog.MapSettingsPath, createMapDialog.MapImagePath, createMapDialog.Grid);
                MessageBox.Show("Map save sucssessfully");
            }

            NodeSetMode(false);
        }
    }
}
