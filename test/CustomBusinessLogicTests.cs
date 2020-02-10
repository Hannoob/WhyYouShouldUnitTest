using BeautifulRestApi.BusinessLogic;
using BeautifulRestApi.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautifulRestApi.Unit.Test
{
    [TestFixture]
    public class Given_the_time_is_after_12_When_a_user_calls_the_greeting_method_Then
    {
        private string greeting;

        [OneTimeSetUp]
        public void Setup()
        {
            Mock<ITimeProvider> mockTimeProvider = new Mock<ITimeProvider>();
            mockTimeProvider.Setup(p => p.getCurrentTime()).Returns(new DateTime(2020, 01, 01, 15, 0, 0));

            var service = new CustomBusinessLogic(mockTimeProvider.Object);

            greeting = service.GreetBasedOnTime("test");
        }
        
        [Test]
        public void The_result_should_contain_the_word_afternoon()
        {
            Assert.That(greeting, Does.Contain("afternoon"));
        }

        [Test]
        public void The_result_should_contain_the_username()
        {
            Assert.That(greeting, Does.Contain("test"));
        }
    }

    [TestFixture]
    public class Given_the_time_is_before_12_When_a_user_calls_the_greeting_method_Then
    {
        private string greeting;

        [OneTimeSetUp]
        public void Setup()
        {
            Mock<ITimeProvider> mockTimeProvider = new Mock<ITimeProvider>();
            mockTimeProvider.Setup(p => p.getCurrentTime()).Returns(new DateTime(2020, 01, 01, 5, 0, 0));
            
            var service = new CustomBusinessLogic(mockTimeProvider.Object);
            
            greeting = service.GreetBasedOnTime("test");
        }

        [Test]
        public void The_result_should_contain_the_word_morning()
        {
            Assert.That(greeting, Does.Contain("morning"));
        }

        [Test]
        public void The_result_should_contain_the_username()
        {
            Assert.That(greeting, Does.Contain("test"));
        }
    }
}
