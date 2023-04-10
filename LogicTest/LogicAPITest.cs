using Logika;
using Moq;
using System.Diagnostics;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {

        [TestMethod]
        public void getBalls_shouldReturnList()
        {
            // Arrange
            Mock<LogicAbstractAPI> mockLogicAbstractAPI = new Mock<LogicAbstractAPI>();
            mockLogicAbstractAPI.Setup(p => p.addBall()).Returns(List<Ball>);
            // Act

            // Assert
        }
    }
}