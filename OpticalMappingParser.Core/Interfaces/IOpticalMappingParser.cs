using OpticalMappingParser.Core.Models;
using System.Collections.Generic;

namespace OpticalMappingParser.Core.Interfaces
{
    public interface IOpticalMappingParser
    {
        IEnumerable<int> Chromosomes { get; }

        void LoadFile(string path);
        void SaveToCsv(string path);

        IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxMarksDistance);
        IList<DifficultAreaResult> Process(int maxNoMarksLength, int sequentMarksCount, int maxMarksDistance, int chromosome, int positionStart, int positionEnd);
    }
}
