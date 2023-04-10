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
            mockLogicApi = Mock.Create<LogicAbstractAPI>();
            // Act

            // Assert
        }
    }
}