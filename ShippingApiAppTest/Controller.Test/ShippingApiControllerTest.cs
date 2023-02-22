
namespace ShippingApiApp.Test.Controller.Test
{
    public class ShippingApiControllerTest
    {
        [Fact]
        public void AddShipTest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.AddShip(new AddShipRequestModel() { ShipName = "testShip", Latitude = 80, Longitude = 80, Velocity = 60 })).Returns(new AddShipResponseModel(){ShipId= 1});

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.AddShip(new AddShipRequestModel() { ShipName = "testShip", Latitude = 80, Longitude = 80, Velocity = 60 });

            // Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }

        [Fact]
        public void AddShipFailedTest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.AddShip(null)).Returns(new AddShipResponseModel() { ErrorMessage = "Error Test" });

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.AddShip(null);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }


        [Fact]
        public void GetAllShipListTest()
        {

            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.GetAllShipList()).Returns(new List<ShipModel>());

            var controller = new ShippingApiController(mockRepo.Object);

            var result = controller.GetAllShipList();
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }


        [Fact]
        public void UpdateVelocityOfShipTest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.UpdateVelocityOfShip(new UpdateVelocityRequestModel() { ShipId=1, Velocity = 60 })).Returns("");

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.UpdateVelocityOfShip(new UpdateVelocityRequestModel() { ShipId = 1, Velocity = 60 });

            // Assert
            var actionresult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(204, actionresult.StatusCode);
        }


        [Fact]
        public void UpdateVelocityOfShipFaliedTest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.UpdateVelocityOfShip(null)).Returns("Error from DB");

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.UpdateVelocityOfShip(null);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }


        [Fact]
        public void GetClosestPortToShipWithETATest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.GetClosestPortToShipWithETA(1)).Returns(new ShipETAResponseModel() { Velocity = 1 });

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.GetClosestPortToShipWithETA(1);

            // Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }

        [Fact]
        public void GetClosestPortToShipWithETAFaliedTest()
        {
            // Arrange
            var mockRepo = new Mock<IShipRepository>();
            mockRepo.Setup(repo => repo.GetClosestPortToShipWithETA(0)).Returns(new ShipETAResponseModel());

            var controller = new ShippingApiController(mockRepo.Object);

            // Act
            var result = controller.GetClosestPortToShipWithETA(0);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }

    }
}
