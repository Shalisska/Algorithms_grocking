using Algorithms.Code;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.Tests.Code
{
    public class HashTablesTests
    {
        HashTables _hashTables = new HashTables();

        [Fact]
        public void CheckVoterTest()
        {
            var voter1 = "Tom";
            var voter2 = "Mike";

            var resultActual = _hashTables.CheckVoter(voter1);
            Assert.True(resultActual);

            resultActual = _hashTables.CheckVoter(voter2);
            Assert.True(resultActual);

            resultActual = _hashTables.CheckVoter(voter1);
            Assert.False(resultActual);
        }
    }
}
