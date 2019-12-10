using OpticalMappingParser.Core.Interfaces;
using OpticalMappingParser.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OpticalMappingParser.Core.Implementation
{
    public class DifficultAreaIdentifier : IDifficultAreaIdentifier
    {
        // (chromosomeId, [position])
        private Dictionary<int, List<int>> _chromosomes;

        public DifficultAreaIdentifier()
        {
        }

        public DifficultAreaIdentifier(string path)
        {
            LoadFile(path);
        }

        public IEnumerable<int> Chromosomes => _chromosomes.Keys;

        public void LoadFile(string path)
        {
            LoadFileFromMemory(File.ReadAllLines(path));
        }

        public void LoadFileFromMemory(string[] data)
        {
            _chromosomes = data
                .Where(e => e[0] != '#')
                .Select(e => e.Split('\t'))
                .Select(e => new
                {
                    Chromosome = int.Parse(e[0]),
                    Position = (int)float.Parse(e[5], CultureInfo.InvariantCulture),
                })
                .GroupBy(e => e.Chromosome)
                .ToDictionary(e => e.Key, e => e.Select(x => x.Position).ToList());
        }

        public void SaveToCsv(string path)
        {
            throw new NotImplementedException();
        }

        public IList<DifficultAreaResult> Process(int maxNoMarksDistance, int maxShortDistance, int maxShortDistanceSequentMarksCount)
        {
            if (_chromosomes == null)
                throw new InvalidOperationException("Data not initialized");

            var result = new List<DifficultAreaResult>();
            foreach (var chromosome in _chromosomes)
            {
                result.AddRange(ProcessChromosome(chromosome.Value, chromosome.Key, maxNoMarksDistance, maxShortDistanceSequentMarksCount, maxShortDistance));
            }

            return result;
        }

        public IList<DifficultAreaResult> Process(int maxNoMarksDistance, int maxShortDistance, int maxShortDistanceSequentMarksCount, int chromosomeId, int? fromPosition = null, int? toPosition = null)
        {
            if (_chromosomes == null)
                throw new InvalidOperationException("Data not initialized");

            if (!_chromosomes.ContainsKey(chromosomeId))
                throw new ArgumentOutOfRangeException($"Chromosome {chromosomeId} does not exist");

            return ProcessChromosome(_chromosomes[chromosomeId], chromosomeId, maxNoMarksDistance, maxShortDistanceSequentMarksCount, maxShortDistance, fromPosition, toPosition);
        }

        private IList<DifficultAreaResult> ProcessChromosome(List<int> chromosome, int chromosomeId, int maxNoMarksDistance, int sequentMarksCount, int maxShortDistance, int? fromPosition = null, int? toPosition = null)
        {
            var result = new List<DifficultAreaResult>();

            var positions = chromosome.ToList();
            if (fromPosition.HasValue)
                positions = positions.Where(e => e >= fromPosition).ToList();
            if (toPosition.HasValue)
                positions = positions.Where(e => e <= toPosition).ToList();

            int shortAreaStart = -1;
            int longAreaStart = -1;
            for (int i = 1; i < positions.Count; i++)
            {
                int distance = positions[i] - positions[i - 1];

                // handle short difficult area
                if (distance <= maxShortDistance)
                {
                    if (shortAreaStart == -1) // start new area
                        shortAreaStart = i - 1;
                }
                else
                {
                    if (shortAreaStart != -1) // end area
                    {
                        if ((i - 1) - shortAreaStart >= sequentMarksCount)
                        {
                            result.Add(new DifficultAreaResult
                            {
                                Chromosome = chromosomeId,
                                StartPosition = positions[shortAreaStart],
                                EndPosition = positions[i - 1],
                                SequenceLength = SequenceLength.Short,
                            });
                            shortAreaStart = -1;
                        }
                    }
                }

                // handle long difficult area
                if (distance > maxNoMarksDistance)
                {
                    if (longAreaStart == -1) // start new area
                        longAreaStart = i - 1;
                }
                else
                {
                    if (longAreaStart != -1) // end area
                    {
                        result.Add(new DifficultAreaResult
                        {
                            Chromosome = chromosomeId,
                            StartPosition = positions[longAreaStart],
                            EndPosition = positions[i - 1],
                            SequenceLength = SequenceLength.Long,
                        });
                        longAreaStart = -1;
                    }
                }
            }

            return result;
        }
    }
}
