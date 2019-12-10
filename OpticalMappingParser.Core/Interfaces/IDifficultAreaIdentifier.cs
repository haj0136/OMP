using OpticalMappingParser.Core.Models;
using System.Collections.Generic;

namespace OpticalMappingParser.Core.Interfaces
{
    public interface IDifficultAreaIdentifier
    {
        IEnumerable<int> Chromosomes { get; }

        void LoadFile(string path);
        void SaveToCsv(string path);

        IList<DifficultAreaResult> Process(int maxNoMarksDistance, int maxShortDistance, int maxShortDistanceSequentMarksCount);
        IList<DifficultAreaResult> Process(int maxNoMarksDistance, int maxShortDistance, int maxShortDistanceSequentMarksCount, int chromosomeId, int? fromPosition = null, int? toPosition = null);
    }
}
