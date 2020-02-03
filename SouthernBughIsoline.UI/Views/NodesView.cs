using SouthernBughIsoline.UI.Controllers;
using System;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views
{
    public partial class NodesView : Form, IView
    {
        private readonly NodesController nodeController;

        public NodesView()
        {
            InitializeComponent();
        }

        public NodesView(IView parentView) : this()
        {
            ParentView = parentView;

            nodeController = new NodesController((MapController)ParentView.Controller);
        }

        public IController Controller => nodeController;
        public IView ParentView { get; set; }

        private void NodesView_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = nodeController.LoadNodes();
        }

        private void SaveNodesValuesBtn_Click(object sender, EventArgs e)
        {
            nodeController.SaveNodesValues(dataGridView);

            Close();
        }

    }
}
