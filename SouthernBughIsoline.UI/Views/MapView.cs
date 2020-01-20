using SouthernBughIsoline.UI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views
{
    public partial class MapView : Form
    {
        MapController mapController = new MapController();

        public MapView()
        {
            InitializeComponent();

            ClientSize = new Size(1245, 715);

            mapImagePanel.BackgroundImageLayout = ImageLayout.Zoom;

            loadMapBtn.Click += LoadMapBtn_Click;
            saveMapBtn.Click += SaveMapBtn_Click;
            buildLevelLinesBtn.Click += BuildLevelLinesBtn_Click;
        }

        private void BuildLevelLinesBtn_Click(object sender, EventArgs e)
        {
            float[] levels = { 25, 30, 35, 40, 45, 50, 55, 60 };
            float[] values = { 47, 46, 63, 46, 49, 41, 44, 37, 33, 22, 29, 32, 47, 53, 43, 43, 50, 45, 41, 39, 38, 28 };
            

            mapController.BulidLevelLines(mapImagePanel.CreateGraphics(), Color.Red, values, levels);
        }

        private void LoadMapBtn_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Xml files (*.xml)|*.xml"
            };

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    mapImagePanel.BackgroundImage = mapController.LoadMap(fileDialog.FileName);
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

        private void SaveMapBtn_Click(object sender, EventArgs e)
        {
            FileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Xml files (*.xml)|*.xml*"
            };
            FileDialog openFileDialog = new OpenFileDialog() 
            {
                Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        mapController.SaveMap(saveFileDialog.FileName
                            + (!saveFileDialog.FileName.EndsWith(".xml") ? ".xml" : ""),
                            openFileDialog.FileName);

                        MessageBox.Show("File successfully saved.");
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                saveFileDialog.Dispose();
            }
        }

        



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //MainForm mainForm = new MainForm();
            //mainForm.ShowDialog();

            //mapController.Grid = mainForm.grid;
            //mainForm.grid = null;

        }
    }
}
