using OpticalMappingParser.Core.Implementation;
using OpticalMappingParser.Core.Interfaces;
using OpticalMappingParser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


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
            numericUpDownStartPos.Maximum = decimal.MaxValue;
            numericUpDownEndPos.Maximum = decimal.MaxValue;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Chromosome";
            dataGridView1.Columns[1].Name = "Start position";
            dataGridView1.Columns[2].Name = "End position";
            dataGridView1.Columns[3].Name = "Type";
            filterGroupBox.Visible = false;
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _parser = new DifficultAreaIdentifier("../../../TestFiles/hg19_DLE1_0kb_0labels.cmap");

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
            saveFileDialog.Filter = "csv file (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _parser.SaveToCsv(saveFileDialog.FileName);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var maxLenght = numericUpDownMaxSeqNoMarks.Value;
            var marksCount = numericUpDownConsecutiveMarks.Value;
            var minLenght = numericUpDownMaxSeqBetweenMarks.Value;
            var resultList = _parser.Process((int)maxLenght, (int)marksCount, (int)minLenght);
            //List<DifficultAreaResult> resultList = null;

            if (resultList?.Any() != true)
            {
                //TODO: Handle null or empty list
                MessageBox.Show("Not found any difficult areas.");
                return;
            } 

            foreach (DifficultAreaResult result in resultList)
            {
                dataGridView1.Rows.Add(result.Chromosome, result.StartPosition, result.EndPosition,
                    Enum.GetName(typeof(SequenceLength), result.SequenceLength));
            }

            saveFileToCSVToolStripMenuItem.Enabled = true;
            filterGroupBox.Visible = true;
            parametrsGroupBox.Visible = false;
        }

        private void numericUpDownStartPos_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownEndPos.Minimum = numericUpDownStartPos.Value + 1;
        }

        private void NewProcessButton_Click(object sender, EventArgs e)
        {
            saveFileToCSVToolStripMenuItem.Enabled = false;
            filterGroupBox.Visible = false;
            parametrsGroupBox.Visible = true;
            dataGridView1.Rows.Clear();
        }

        private void numericUpDownMaxSeqNoMarks_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownMaxSeqBetweenMarks.Maximum = numericUpDownMaxSeqNoMarks.Value - 1;
        }
    }
}
