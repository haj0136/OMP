using OpticalMappingParser.Core.Models;
using System.Collections.Generic;

namespace OpticalMappingParser.Core.Interfaces
{
    public interface IDifficultAreaIdentifier
    {
        IEnumerable<int> Chromosomes { get; }

        void LoadFile(string path);
        void SaveToCsv(string path);

        IList<DifficultAreaResult> Process(int minLongDistance, int maxShortDistance, int minShortDistanceSequentMarksCount);
        IList<DifficultAreaResult> Process(int minLongDistance, int maxShortDistance, int minShortDistanceSequentMarksCount, int chromosomeId, int? fromPosition = null, int? toPosition = null);
    }
}
