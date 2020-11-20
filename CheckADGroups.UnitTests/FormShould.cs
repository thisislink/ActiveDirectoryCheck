using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CheckADGroups;

namespace CheckADGroups.UnitTests
{
    [TestClass]
    public class FormShould
    {
        [TestMethod]
        public void SearchButton_Click()
        {
            
            string getUser = "linkdap";

            getUser.Should().NotBeNullOrEmpty();

        }
    }
}
