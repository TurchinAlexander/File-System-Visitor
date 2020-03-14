﻿using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;

namespace DataAccessLayer.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private static DbProviderFactory factory = SqlClientFactory.Instance;
        private static string connectionString = @"Server=DESKTOP-J66IAL7\SQLEXPRESS;Database=Northwind;Trusted_Connection = true";
        private static OrderRepository orderRepository;


        [SetUp]
        public void SetUp()
        {
            orderRepository = new OrderRepository(factory, connectionString);
        }

        [Test]
        public void GetOrders_Nothing_EnumerableListOfOrders()
        {
            var result = orderRepository.GetOrders()
                .ToList();

            Assert.True(result.Count > 0);
        }

        [Test]
        public void GetDetailedOrder_Nothing_OrderWithProducts()
        {
            var result = orderRepository.GetDetailedOrder(10248);

            Assert.True(result != null);
            Assert.True(result.Products.Count > 0);
        }
    }
}