using OpticalMappingParser.Core.Interfaces;
using OpticalMappingParser.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OpticalMappingParser.Core.Implementation
{
    public class DifficultAreaIdentifier : IOpticalMappingParser
    {
        private Dictionary<int, List<Mark>> _chromosomes;

        public DifficultAreaIdentifier(string path)
        {
            LoadFile(path);
        }

        public IEnumerable<int> Chromosomes { get; }

        public void LoadFile(string path)
        {
            _chromosomes = File.ReadAllLines(path)
                .Where(e => e[0] != '#')
                .Select(e => e.Split('\t'))
                .Select(e => new Mark
                {
                    Chromosome = int.Parse(e[0]),
                    Position = (int)float.Parse(e[5], CultureInfo.InvariantCulture),
                })
                .GroupBy(e => e.Chromosome)
                .ToDictionary(e => e.Key, e => e.ToList());
        }

        public void SaveToCsv(string path)
        {
            throw new NotImplementedException();
        }

        public IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxMarksDistance)
        {
            throw new NotImplementedException();
        }

        public IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxMarksDistance, int chromosome, int positionStart,
            int positionEnd)
        {
            throw new NotImplementedException();
        }
    }
}
