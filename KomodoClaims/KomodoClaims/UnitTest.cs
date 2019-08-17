using System;
using System.Collections.Generic;
using KomodoClaims.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims
{
    [TestClass]
    public class UnitTest
    {
        ClaimsRepo _claimsRepo = new ClaimsRepo();
        Queue<Claim> _claimsQueue = new Queue<Claim>();

        [TestMethod]
        public void TestShouldAddNewClaim()
        {
            Claim item = new Claim();

            _claimsRepo.NewClaim(item);

            var expected = 3;
            var actual = _claimsRepo.GetAllClaims().Count;

            Assert.AreEqual(expected, actual);
        }

        public void ShouldDeleteFromQueue()
        {
            Claim itemToRemove = _claimsRepo.GetFirstClaimOnQueue();

            _claimsRepo.GetAllClaims(itemToRemove).Dequeue();

            var expected = 1;
            var actual = _claimsRepo.GetAllClaims().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
