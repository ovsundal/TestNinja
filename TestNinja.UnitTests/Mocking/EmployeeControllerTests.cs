using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }
        
        [Test]
        public void DeleteEmployee_WhenCalled_DeletesEmployeeFromDatabase()
        {
            _employeeStorage.Setup(es => es.DeleteEmployee(1));

            //don't care about the result, this is an interaction test
            _employeeController.DeleteEmployee(1);
            
            //verifies that the method was called and parameter 1 was passed
            _employeeStorage.Verify(es => es.DeleteEmployee(1));
        }
    }
}