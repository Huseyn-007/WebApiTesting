using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Entities;

namespace WebApiTesting.Tests
{
    [TestFixture]
    public class UserTesting
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services => { });
            });

            _client = _factory.CreateClient();
        }
        public async Task GetProduct_ReturnsCorrectProduct()
        {

            var response = await _client.GetAsync("/api/user");

            var users = await response.Content.ReadFromJsonAsync<List<User>>();
            var user = users?.FirstOrDefault();


            if (user != null)
            {
                var responseProduct = await _client.GetAsync($"/api/User/{user.Id}");
                Assert.That(responseProduct != null);
                var p = await responseProduct.Content.ReadFromJsonAsync<User>();
                Assert.That(p != null);
                Assert.That(p.Id, Is.EqualTo(user.Id));
            }
        }

        [Test]
        public async Task PostProduct_AddsNewProduct()
        {
            var newProduct = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Age = 1,
                Email = "asdfasf@gmail.com"
            };


            var response = await _client.PostAsJsonAsync("/api/user", newProduct);

            //Assert
            response.EnsureSuccessStatusCode();
            var createdUser = await response.Content.ReadFromJsonAsync<User>();
            Assert.That(createdUser != null);
            Assert.That(newProduct.FirstName, Is.EqualTo(createdUser?.FirstName));


        }

    }
}
