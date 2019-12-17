using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpticalMappingParser.Core.Implementation;
using OpticalMappingParser.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpticalMappingParser.Tests
{
    [TestClass]
    public class ProcessTests
    {
        private DifficultAreaIdentifier _identifier = new DifficultAreaIdentifier();

        [TestMethod]
        public void CanDetectLongDifficultArea()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t50.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t200.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t230.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 0, 0);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Chromosome);
            Assert.AreEqual(100, result[0].StartPosition);
            Assert.AreEqual(200, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Long, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanDetectShortDifficultArea()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t110.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t120.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t150.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 10, 2);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Chromosome);
            Assert.AreEqual(100, result[0].StartPosition);
            Assert.AreEqual(120, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Short, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CannotDetectVeryShortDifficultArea()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t110.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t120.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t150.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 10, 3, 1);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CanDetectShortAndLongDifficultAreas()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t50.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t110.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t120.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t150.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t1500.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2000.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2010.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 30, 2);

            Assert.AreEqual(2, result.Count);

            var shortArea = result.SingleOrDefault(e => e.DifficultAreaType == DifficultAreaType.Short);
            Assert.IsNotNull(shortArea);
            Assert.AreEqual(1, shortArea.Chromosome);
            Assert.AreEqual(100, shortArea.StartPosition);
            Assert.AreEqual(150, shortArea.EndPosition);

            var longArea = result.SingleOrDefault(e => e.DifficultAreaType == DifficultAreaType.Long);
            Assert.IsNotNull(longArea);
            Assert.AreEqual(1, longArea.Chromosome);
            Assert.AreEqual(150, longArea.StartPosition);
            Assert.AreEqual(2000, longArea.EndPosition);
        }

        [TestMethod]
        public void CanDetectDifficultAreaWithFromFilter()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t50.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t1500.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2000.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2110.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 30, 2, 1, fromPosition: 1700);

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(2000, result[0].StartPosition);
            Assert.AreEqual(2100, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Long, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanDetectDifficultAreaWithToFilter()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t50.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t1500.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2000.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2110.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 30, 2, 1, toPosition: 2050);

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(50, result[0].StartPosition);
            Assert.AreEqual(2000, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Long, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanDetectDifficultAreaWithFromAndToFilters()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t50.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t1500.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t1700.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t2110.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 30, 2, 1, fromPosition: 1000, toPosition: 2000);

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(1500, result[0].StartPosition);
            Assert.AreEqual(1700, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Long, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanDetectShortDifficultAreaEndingOnLastMark()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t10.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t20.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t30.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 50, 2, 1);

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(10, result[0].StartPosition);
            Assert.AreEqual(30, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Short, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanDetectLongDifficultAreaEndingOnLastMark()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t200.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t300.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);
            var result = _identifier.Process(50, 50, 2, 1);

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(100, result[0].StartPosition);
            Assert.AreEqual(300, result[0].EndPosition);
            Assert.AreEqual(DifficultAreaType.Long, result[0].DifficultAreaType);
        }

        [TestMethod]
        public void CanFindAllChromosomes()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "2\t249250621.0\t50087\t1\t1\t110.0\t1.0\t1\t1",
                "3\t249250621.0\t50087\t1\t1\t120.0\t1.0\t1\t1",
                "4\t249250621.0\t50087\t1\t1\t150.0\t1.0\t1\t1",
            };

            _identifier.LoadFileFromMemory(data);

            Assert.IsTrue(_identifier.Chromosomes.Contains(1));
            Assert.IsTrue(_identifier.Chromosomes.Contains(2));
            Assert.IsTrue(_identifier.Chromosomes.Contains(3));
            Assert.IsTrue(_identifier.Chromosomes.Contains(4));
        }

        [TestMethod]
        public void CanProcessTestFile()
        {
            _identifier.LoadFile("../../../TestFiles/hg19_DLE1_0kb_0labels.cmap");
            var result = _identifier.Process(1000, 100, 10);
        }

        [TestMethod]
        public void CanSaveToCsv()
        {
            string expectedCsv = "chromosome,start,end,area_type\r\n1,10,30,L\r\n2,50,60,S\r\n";
            string path = Path.GetTempFileName();

            var results = new List<DifficultAreaResult>
            {
                new DifficultAreaResult{Chromosome = 1, StartPosition = 10, EndPosition = 30, DifficultAreaType = DifficultAreaType.Long},
                new DifficultAreaResult{Chromosome = 2, StartPosition = 50, EndPosition = 60, DifficultAreaType = DifficultAreaType.Short},
            };

            try
            {
                _identifier.SaveToCsv(path, results);
                string actualCsv = File.ReadAllText(path);

                Assert.AreEqual(expectedCsv, actualCsv);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
