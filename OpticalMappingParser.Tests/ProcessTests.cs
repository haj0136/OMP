using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpticalMappingParser.Core.Implementation;
using OpticalMappingParser.Core.Models;

namespace OpticalMappingParser.Tests
{
    [TestClass]
    public class ProcessTests
    {
        private DifficultAreaIdentifier parser = new DifficultAreaIdentifier();

        [TestMethod]
        public void CanDetectLongDifficultArea()
        {
            var data = new[]
            {
                "1\t249250621.0\t50087\t1\t1\t100.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t200.0\t1.0\t1\t1",
                "1\t249250621.0\t50087\t1\t1\t230.0\t1.0\t1\t1",
            };

            parser.LoadFileFromMemory(data);
            var result = parser.Process(50, 0, 0);

            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(1, result[0].Chromosome);
            Assert.AreEqual(100, result[0].StartPosition);
            Assert.AreEqual(200, result[0].EndPosition);
            Assert.AreEqual(SequenceLength.Long, result[0].SequenceLength);
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

            parser.LoadFileFromMemory(data);
            var result = parser.Process(50, 2, 10);

            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(1, result[0].Chromosome);
            Assert.AreEqual(100, result[0].StartPosition);
            Assert.AreEqual(120, result[0].EndPosition);
            Assert.AreEqual(SequenceLength.Short, result[0].SequenceLength);
        }

        [TestMethod]
        public void CanProcessTestFile()
        {
            parser.LoadFile("../../../TestFiles/hg19_DLE1_0kb_0labels.cmap");
            var result = parser.Process(1000, 10, 100);
        }
    }
}
