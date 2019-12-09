using OpticalMappingParser.Core.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;
using OpticalMappingParser.Core.Implementation;


namespace OpticalMappingParser.Gui
{
    public partial class Form1 : Form
    {
        private IOpticalMappingParser _parser;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "cmap files (*.cmap)|*.cmap";
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileName = openFileDialog1.FileName;
                    _parser = new DifficultAreaIdentifier(fileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"File load error. \n\n Error message: {exception.Message}");
                }
            }
        }
    }
}
