using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TFL.WebClientConsole.Test
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void When_Run_GivenValidRoadId_ShouldContainDisplayName()
        {
            HttpResponseMessage validResponse = CreateValidResponse();

            Mock<IClient> clientWrapper = new Mock<IClient>();
            clientWrapper.Setup(x => x.GetAsync("validid", "id", "key"))
                .Returns(Task.FromResult(validResponse));
            Client client = new Client(clientWrapper.Object);

            RoadCorridor roadInfo = client.Run("validid", "id", "key").GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(roadInfo.DisplayName));
        }
    
        

        [TestMethod]
        public void When_Run_GivenValidRoadId_ShouldContainStatusSeverity()
        {
            HttpResponseMessage validResponse = CreateValidResponse();

            Mock<IClient> clientWrapper = new Mock<IClient>();
            clientWrapper.Setup(x => x.GetAsync("validid", "id", "key"))
                .Returns(Task.FromResult(validResponse));
            Client client = new Client(clientWrapper.Object);

            RoadCorridor roadInfo = client.Run("validid", "id", "key").GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(roadInfo.StatusSeverity));
        }

        [TestMethod]
        public void When_Run_GivenValidRoadId_ShouldContainStatusSeverityDesc()
        {
            HttpResponseMessage validResponse = CreateValidResponse();

            Mock<IClient> clientWrapper = new Mock<IClient>();
            clientWrapper.Setup(x => x.GetAsync("validid", "id", "key"))
                .Returns(Task.FromResult(validResponse));
            Client client = new Client(clientWrapper.Object);

            RoadCorridor roadInfo = client.Run("validid", "id", "key").GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(roadInfo.StatusSeverityDescription));
        }

        [TestMethod]
        public void When_Run_GivenInvalidRoadId_ShouldThrowException()
        {
            HttpResponseMessage validResponse = CreateInvalidResponse();

            Mock<IClient> clientWrapper = new Mock<IClient>();
            clientWrapper.Setup(x => x.GetAsync("validid", "id", "key"))
                .Returns(Task.FromResult(validResponse));
            Client client = new Client(clientWrapper.Object);

            try
            {
                RoadCorridor roadInfo = client.Run("validid", "id", "key").GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ApiException);
                Assert.IsTrue(((ApiException)ex).ApiError.ExceptionType == "EntityNotFoundException");
            }
            
        }

        private HttpResponseMessage CreateValidResponse()
        {
            Assembly asm = this.GetType().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("TFL.WebClientConsole.Test.ValidResponse.Json"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    HttpResponseMessage validResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    validResponse.Content = new StringContent(reader.ReadToEnd(), Encoding.UTF8, "application/json");
                    return validResponse;
                }
            }
        }

        private HttpResponseMessage CreateInvalidResponse()
        {
            Assembly asm = this.GetType().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("TFL.WebClientConsole.Test.ValidResponse.Json"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    HttpResponseMessage invalidResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    invalidResponse.Content = new StringContent(reader.ReadToEnd(), Encoding.UTF8, "application/json");
                    return invalidResponse;
                }
            }
        }
    }
}
