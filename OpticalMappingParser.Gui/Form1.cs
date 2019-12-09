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
            numericUpDownMaxSeqNoMarks.Maximum = decimal.MaxValue;
            numericUpDownMaxSeqBetweenMarks.Maximum = decimal.MaxValue;
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileName = openFileDialog1.FileName;
                    _parser = new DifficultAreaIdentifier(fileName);
                    generateButton.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"File load error. \n\n Error message: {exception.Message}");
                }
            }
        }

        private void saveFileToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _parser.SaveToCsv(saveFileDialog.FileName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var maxLenght = numericUpDownMaxSeqNoMarks.Value;
            var marksCount = numericUpDownConsecutiveMarks.Value;
            var minLenght = numericUpDownMaxSeqBetweenMarks.Value;
            var resultList = _parser.Process((int)maxLenght, (int)marksCount, (int)minLenght);
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Chromosome";
            dataGridView1.Columns[1].Name = "Start position";
            dataGridView1.Columns[2].Name = "End position";
            dataGridView1.Columns[3].Name = "Type";

        }
    }
}
