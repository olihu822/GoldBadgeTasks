using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Classes
{
    public enum ClaimType
    {
        Auto = 1,
        Home = 2,
        Theft = 3
    }
    public class Claim
    {
        public string ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan validClaim = DateOfClaim - DateOfIncident;
                if (validClaim.Days < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim() { }

        public Claim(string claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
    public class ClaimsRepo
    {
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            return _claimsQueue;
        }

        //helper method for boolean?
        public Claim GetFirstClaimOnQueue()
        {
            return _claimsQueue.Peek();
        }

        public Claim SolveNextClaimOnQueue()
        {
            return _claimsQueue.Dequeue();
        }

        public void NewClaim(Claim item)
        {
            _claimsQueue.Enqueue(item);
        }
        public void SeedMenu()
        {
            Claim item = new Claim("12", ClaimType.Theft, "Television", 120.65m, DateTime.Today, DateTime.Today);
            _claimsQueue.Enqueue(item);

            Claim item2 = new Claim("16", ClaimType.Auto, "Car crash", 135.76m, DateTime.Today, DateTime.Today);
            _claimsQueue.Enqueue(item2);

        }
    }
}
