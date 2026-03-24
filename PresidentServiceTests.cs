using System;
using System.Collections.Generic;
using Xunit;
using PresidentsApp.Models;
using PresidentsApp.Services;
using PresidentsApp.Interfaces;

namespace PresidentsApp.Tests
{
    public class MockRepository : IPresidentRepository
    {
        public List<President> LoadPresidents()
        {
            return new List<President>
            {
                new President { Number = 1, Name = "George Washington", State = "VA", Years = "1789-1797", Hobby = "Horse" },
                new President { Number = 2, Name = "John Adams", State = "MA", Years = "1797-1801", Hobby = "Writing" },
                new President { Number = 16, Name = "Abraham Lincoln", State = "KY", Years = "1861-1865", Hobby = "Reading" }
            };
        }
    }

    public class PresidentServiceTests
    {
        private readonly PresidentService _service;

        public PresidentServiceTests()
        {
            _service = new PresidentService(new MockRepository());
        }

        [Fact]
        public void Test_ListByNumber()
        {
            var result = _service.ListByNumber();
            Assert.Equal(1, result[0].Number);
        }

        [Fact]
        public void Test_ListByLastName()
        {
            var result = _service.ListByLastName();
            Assert.Equal("John Adams", result[0].Name);
        }

        [Fact]
        public void Test_SearchByName_Valid()
        {
            var result = _service.SearchByName("John");
            Assert.Single(result);
        }

        [Fact]
        public void Test_SearchByName_Invalid()
        {
            Assert.Throws<Exception>(() => _service.SearchByName("XYZ"));
        }

        [Fact]
        public void Test_GetByNumber_Valid()
        {
            var result = _service.GetByNumber(16);
            Assert.Equal("Abraham Lincoln", result.Name);
        }

        [Fact]
        public void Test_GetByNumber_Invalid()
        {
            Assert.Throws<Exception>(() => _service.GetByNumber(999));
        }
    }
}
