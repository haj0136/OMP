﻿using OpticalMappingParser.Core.Interfaces;
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

        public IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxShortDistance)
        {
            if (_chromosomes == null)
                throw new InvalidOperationException("Data not initialized");

            var result = new List<DifficultAreaResult>();
            foreach (var chromosomeId in Chromosomes)
            {
                result.AddRange(ProcessChromosome(chromosomeId, maxNoMarksLength, sequentMarksCount, maxShortDistance));
            }

            return result;
        }


        public IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxMarksDistance, int chromosome, int positionStart, int positionEnd)
        {
            if (_chromosomes == null)
                throw new InvalidOperationException("Data not initialized");

            throw new NotImplementedException();
        }

        private IList<DifficultAreaResult> ProcessChromosome(int chromosomeId, int maxNoMarksLength, int sequentMarksCount, int maxShortDistance)
        {
            var chromosome = _chromosomes[chromosomeId];
            var result = new List<DifficultAreaResult>();

            int shortAreaStart = -1;
            int longAreaStart = -1;
            for (int i = 1; i < chromosome.Count; i++)
            {
                int distance = chromosome[i] - chromosome[i - 1];

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
                                StartPosition = chromosome[shortAreaStart],
                                EndPosition = chromosome[i - 1],
                                SequenceLength = SequenceLength.Short,
                            });
                            shortAreaStart = -1;
                        }
                    }
                }

                // handle long difficult area
                if (distance > maxNoMarksLength)
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
                            StartPosition = chromosome[longAreaStart],
                            EndPosition = chromosome[i - 1],
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