using System.Collections.Generic;
using System.Net.Http;
using AspNetCore.Http.Extensions;
using AspNetCoreCqrsRedis.API.Command.Request;
using AspNetCoreCqrsRedis.Model.ReadModel.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace AspNetCoreCqrsRedis.Test.IntegrationTest
{
    [TestCaseOrderer("AspNetCoreCqrsRedis.Test.PriorityOrderer", "AspNetCoreCqrsRedis.Test")]
    public class EndToEndTest
    {
        private readonly TestServer _commandTestServer;
        private readonly TestServer _queryTestServer;
        private readonly HttpClient _commandServerClient;
        private readonly HttpClient _queryServerClient;
        
        public EndToEndTest()
        {
            // Arrange
            _commandTestServer = new TestServer(new WebHostBuilder()
                .UseStartup<API.Command.Startup>());
            _commandServerClient = _commandTestServer.CreateClient();

            _queryTestServer = new TestServer(new WebHostBuilder()
                .UseStartup<API.Query.Startup>());
            _queryServerClient = _queryTestServer.CreateClient();
        }


        [Fact, TestPriority(1)]
        public void TestCreateAnOrder()
        {
            var createOrderRequest = new CreateOrderRequest
            {
                 Description = "order_Description"
            };
            
            // Act
            var response = _commandServerClient.PostAsJsonAsync(
                "http://localhost:5000/order/create", createOrderRequest).Result;
            
            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        
        [Fact, TestPriority(2)]
        public void TestGetTheOrders()
        {
            
            // Act
            var response = _queryServerClient.GetAsync(
                "http://localhost:4999/order/getall").Result;
            
            // Assert
            Assert.True(response.IsSuccessStatusCode);
            
            using (var content = response.Content)
            {
                var resultString =  content.ReadAsStringAsync().Result;
                var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(resultString);
                Assert.NotEmpty(orders);
            }
        }
    }
}