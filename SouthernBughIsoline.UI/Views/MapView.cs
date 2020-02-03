using Isoline;
using SouthernBughIsoline.UI.Controllers;
using SouthernBughIsoline.UI.Views.Dialog;
using SouthernBughIsoline.UI.Views.UC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views
{
    public partial class MapView : Form, IView
    {
        private readonly MapController mapController = new MapController();

        private ChooseLevelsDialog chooseLevelsDialog;
        private CreateMapDialog createMapDialog;
        private NodesView nodesView;

        private bool isNodeSetModeOn = false;
        private List<Point> nodes;

        private int indx;

        private List<LevelLineView> levelLineViews;
        private bool isDrawLines = false;

        public MapView()
        {
            InitializeComponent();
        }

        public IController Controller => mapController;

        private void createMapBtn_Click(object sender, EventArgs e)
        {
            createMapDialog = new CreateMapDialog();

            if (createMapDialog.ShowDialog() == DialogResult.OK)
            {
                nodes = new List<Point>();
                NodeSetMode(true);
            }
        }

        private void openMapBtn_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Xml files (*.xml)|*.xml"
            };

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    mapImagePnl.BackgroundImage = mapController.LoadMap(fileDialog.FileName);
            }
            catch (ArgumentException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (FileNotFoundException ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                fileDialog.Dispose();
            }
        }

        private void editMapBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveImageBtn_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setValuesByYourselfBtn_Click(object sender, EventArgs e)
        {
            nodesView = new NodesView(this);
            nodesView.Show();
        }

        private void buildAllBtn_Click(object sender, EventArgs e)
        {
            chooseLevelsDialog = new ChooseLevelsDialog();
            
            if (chooseLevelsDialog.ShowDialog() == DialogResult.OK)
            {
                mapController.BulidLevelLines(chooseLevelsDialog.Colors.ToArray(), chooseLevelsDialog.Levels.ToArray(), false);
            }
        }

        private void buildByLevelsBtn_Click(object sender, EventArgs e)
        {
            chooseLevelsDialog = new ChooseLevelsDialog();

            if (chooseLevelsDialog.ShowDialog() == DialogResult.OK)
            {
                BuildLevelLinesMode(true);
            }
        }

        private void editLevelLinesBtn_Click(object sender, EventArgs e)
        {
            if (mapController.Grid.LevelLinesKits.Count > 0)
            {
                levelLineViews = new List<LevelLineView>();

                foreach (var level in mapController.Grid.LevelLinesKits)
                {
                    foreach (var line in level.Lines)
                    {
                        levelLineViews.Add(new LevelLineView(line));
                    }
                }

                foreach (var lineView in levelLineViews)
                {
                    lineView.LevelLineViewPointMouseDown += LineView_LevelLineViewPointMouseDown;
                    lineView.LevelLineViewPointMouseMove += LineView_LevelLineViewPointMouseMove;
                    lineView.LevelLineViewPointMouseUp += LineView_LevelLineViewPointMouseUp;

                    foreach (var pointUC in lineView.PointUCs)
                    {
                        mapImagePnl.Controls.Add(pointUC);
                    }    
                }
            }
        }

        private void LineView_LevelLineViewPointMouseUp(object sender, EventArgs e)
        {
            ((PointUC)sender).IsMove = false;
        }

        private void LineView_LevelLineViewPointMouseMove(object sender, EventArgs e)
        {
            PointUC pointUC = (PointUC)sender;

            if (pointUC.IsMove)
            {
                pointUC.SetLocation(PointToClient(MousePosition));

                mapImagePnl.Refresh();
            }
        }

        private void LineView_LevelLineViewPointMouseDown(object sender, EventArgs e)
        {
            ((PointUC)sender).IsMove = true;
        }

        private void goNextBtnCreateMap_Click(object sender, EventArgs e)
        {
            if (createMapDialog.ShowDialog() == DialogResult.OK)
            {
                mapController.SaveMap(createMapDialog.MapSettingsPath, createMapDialog.MapImagePath, createMapDialog.Grid);
                MessageBox.Show("Map save sucssessfully");
            }

            NodeSetMode(false);
        }

        private void goNextBtnBuildLines_Click(object sender, EventArgs e)
        {
            var levels = chooseLevelsDialog.Levels;
            var lines = mapController.BuildLevelLine(levels[indx], false);

            mapController.Grid.LevelLinesKits.Add(new LevelLinesKit() { Level = levels[indx], Lines = lines });

            indx++;
        }

        private void rebuildBtn_Click(object sender, EventArgs e)
        {
            indx--;

            var level = chooseLevelsDialog.Levels[indx];
            var lines = mapController.BuildLevelLine(level, false);
            var levelLines = mapController.Grid.LevelLinesKits;

            levelLines.RemoveAt(levelLines.Count - 1);
            levelLines.Add(new LevelLinesKit() { Level = level, Lines = lines });

            indx++;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            BuildLevelLinesMode(false);
        }


        private void mapImagePnl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (isDrawLines)
            {
                foreach (var lineView in levelLineViews)
                {
                    g.DrawCurve(Pens.Black, lineView.Points.ToArray());
                }

            }
        }

        private void NodeSetMode(bool isOn)
        {
            isNodeSetModeOn = isOn;
            goNextBtn.Visible = isOn;

            if (isOn)
            {
                goNextBtn.Click += goNextBtnCreateMap_Click;
            }
            else
            {
                goNextBtn.Click -= goNextBtnCreateMap_Click;
            }

            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.Enabled = !isOn;
            }
        }

        private void mapImagePnl_MouseClick(object sender, MouseEventArgs e)
        {
            if (isNodeSetModeOn)
            {
                mapImagePnl.CreateGraphics().FillRectangle(Brushes.Red, e.X - 1, e.Y - 1, 3, 3);
                nodes.Add(e.Location);
            }
        }
    
        private void BuildLevelLinesMode(bool isOn)
        {
            goNextBtn.Visible = isOn;
            rebuildBtn.Visible = isOn;
            cancelBtn.Visible = isOn;

            indx = 0;

            if (isOn)
            {
                goNextBtn.Click += goNextBtnBuildLines_Click;
                rebuildBtn.Click += rebuildBtn_Click;
                cancelBtn.Click += cancelBtn_Click;
            }
            else
            {
                goNextBtn.Click -= goNextBtnBuildLines_Click;
                rebuildBtn.Click -= rebuildBtn_Click;
                cancelBtn.Click -= cancelBtn_Click;
            }
            
            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.Enabled = !isOn;
            }
        }
    }


}
