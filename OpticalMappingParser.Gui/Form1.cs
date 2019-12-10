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
        private IDifficultAreaIdentifier _identifier;
        private IList<DifficultAreaResult> data;
        private IList<DifficultAreaResult> filteredResult;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "cmap files (*.cmap)|*.cmap";
            numericUpDownMaxSeqNoMarks.Maximum = decimal.MaxValue;
            numericUpDownStartPos.Maximum = decimal.MaxValue;
            numericUpDownEndPos.Maximum = decimal.MaxValue;

            filterGroupBox.Visible = false;
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _identifier = new DifficultAreaIdentifier("../../../TestFiles/hg19_DLE1_0kb_0labels.cmap");

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileName = openFileDialog1.FileName;
                    _identifier = new DifficultAreaIdentifier(fileName);
                    generateButton.Enabled = true;

                    chromosomeComboBox.Items.AddRange(_identifier.Chromosomes.Cast<object>().ToArray());
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"File load error. \n\n Error message: {exception.Message}");
                }
            }
        }

        private void saveFileToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var maxLength = numericUpDownMaxSeqNoMarks.Value;
            var marksCount = numericUpDownConsecutiveMarks.Value;
            var minLength = numericUpDownMaxSeqBetweenMarks.Value;
            data = _identifier.Process((int)maxLength, (int)minLength, (int)marksCount);
            //List<DifficultAreaResult> resultList = null;

            if (data?.Any() != true)
            {
                //TODO: Handle null or empty list
                MessageBox.Show("Not found any difficult areas.");
                return;
            }


            ShowStatistics();


            saveFileToCSVToolStripMenuItem.Enabled = true;
            saveCompleteResultMenuItem.Enabled = true;
            filterGroupBox.Visible = true;
            parametrsGroupBox.Visible = false;
            chromosomeComboBox.SelectedIndex = 0;
        }


        private void NewProcessButton_Click(object sender, EventArgs e)
        {
            saveFileToCSVToolStripMenuItem.Enabled = false;
            saveCompleteResultMenuItem.Enabled = false;
            saveFilteredResultMenuItem.Enabled = false;
            filterGroupBox.Visible = false;
            parametrsGroupBox.Visible = true;
            dataGridView1.Rows.Clear();
        }

        private void numericUpDownMaxSeqNoMarks_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownMaxSeqBetweenMarks.Maximum = numericUpDownMaxSeqNoMarks.Value - 1;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {

            var maxLength = (int)numericUpDownMaxSeqNoMarks.Value;
            var marksCount = (int)numericUpDownConsecutiveMarks.Value;
            var minLength = (int)numericUpDownMaxSeqBetweenMarks.Value;
            var chromosome = _identifier.Chromosomes.ToList()[chromosomeComboBox.SelectedIndex];
            int? startPos = (int)numericUpDownStartPos.Value;
            int? endPos = (int)numericUpDownEndPos.Value;

            if (startPos >= endPos && endPos != 0)
            {
                MessageBox.Show("Start position must be smaller than end position!");
                return;
            }

            if (startPos == -1)
                startPos = null;
            if (endPos == 0)
                endPos = null;

            filteredResult = _identifier.Process(maxLength, minLength, marksCount, chromosome, startPos, endPos);


            if (filteredResult?.Any() != true)
            {
                //TODO: Handle null or empty list
                MessageBox.Show("Not found any difficult areas with selected filters.");
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Chromosome";
            dataGridView1.Columns[1].Name = "Start position";
            dataGridView1.Columns[2].Name = "End position";
            dataGridView1.Columns[3].Name = "Type";

            foreach (DifficultAreaResult result in filteredResult)
            {
                dataGridView1.Rows.Add(result.Chromosome, result.StartPosition, result.EndPosition,
                    Enum.GetName(typeof(SequenceLength), result.SequenceLength));
            }

            saveFilteredResultMenuItem.Enabled = true;
        }

        private void ShowStatistics()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Chromosome";
            dataGridView1.Columns[1].Name = "First start position";
            dataGridView1.Columns[2].Name = "Last end position";
            dataGridView1.Columns[3].Name = "Long difficult areas count";
            dataGridView1.Columns[4].Name = "Short difficult areas count";

            var chromosomesGroups = data.GroupBy(x => x.Chromosome).ToList();

            foreach (var chromosomeGroup in chromosomesGroups)
            {
                var distanceTypes = chromosomeGroup.GroupBy(x => x.SequenceLength).ToList();
                var shortAreas = distanceTypes.Find(x => x.Key.Equals(SequenceLength.Short));
                var longAreas = distanceTypes.Find(x => x.Key.Equals(SequenceLength.Long));
                var firstPos = chromosomeGroup.OrderBy(x => x.StartPosition).ElementAt(0).StartPosition;
                var lastPos = chromosomeGroup.OrderByDescending(x => x.EndPosition).ElementAt(0).EndPosition;
                dataGridView1.Rows.Add(chromosomeGroup.Key, firstPos.ToString("n0"), lastPos.ToString("n0"), longAreas.Count(),
                    shortAreas.Count());

            }

        }

        private void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ShowStatistics();
        }

        private void saveCompleteResultMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "csv file (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _identifier.SaveToCsv(saveFileDialog.FileName, data);
            }
        }

        private void saveFilteredResultMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "csv file (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _identifier.SaveToCsv(saveFileDialog.FileName, filteredResult);
            }
        }
    }
}
