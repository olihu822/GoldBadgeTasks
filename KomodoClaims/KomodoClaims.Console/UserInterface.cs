using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoClaims.Classes;

namespace KomodoClaims.UI
{
    class UserInterface
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            _claimsRepo.SeedMenu();
            Menu();
            Console.ReadLine();
        }

        public void Menu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("You've accessed the Claims Menu. Would you like to\n" +
                    "1. View all claims?\n" +
                    "2. Take care of the next claim enqueue?\n" +
                    "3. Enter a new claim?\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        SolveClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        public void ViewAllClaims()
        {
            Queue<Claim> _claimsQueue = _claimsRepo.GetAllClaims();

            foreach (Claim item in _claimsQueue)
            {
                Console.WriteLine($"ClaimId: { item.ClaimID}\n" +
                $"Claim : {item.ClaimType}\n" +
                $"Description : {item.Description}\n" +
                $"Amount : {item.ClaimAmount}\n" +
                $"Date of Incident : {item.DateOfIncident}\n" +
                $"Date of Claim : {item.DateOfClaim}\n" +
                $"Is claim valid : {item.IsValid}\n" +
                $"");
            }

            Console.ReadLine();
        }

        public void SolveClaim()
        {
            Console.Clear();

            Claim nextClaim = _claimsRepo.GetFirstClaimOnQueue();

            Console.WriteLine($"ClaimId : {nextClaim.ClaimID}\n" +
                $"Claim : {nextClaim.ClaimType}\n" +
                $"Description : {nextClaim.Description}\n" +
                $"Amount : {nextClaim.ClaimAmount}\n" +
                $"Date of Incident : {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim : {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Is claim valid : {nextClaim.IsValid}");

            Console.WriteLine("Do you want to close this claim? Type y for Yes or n for No.");

            string inputYN = Console.ReadLine();

            if (inputYN == "y")
            {
                _claimsRepo.SolveNextClaimOnQueue();
                Console.WriteLine("You have delt with this claim.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Claim has been returned to queue.");
                Console.ReadLine();
            }
        }

        public void NewClaim()
        {
            Console.Clear();

            Console.WriteLine("Please input the new Claim ID.");
            string claimID = Console.ReadLine();

            Console.WriteLine("Please input the Claim Type. Type 1 for Auto, 2 for Home, or 3 for Theft.");
            string type = Console.ReadLine();

            ClaimType typeOfClaim = ClaimType.Auto;
            switch (type)
            {
                case "1":
                    typeOfClaim = ClaimType.Auto;
                    break;
                case "2":
                    typeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    typeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine($"Invalid Number");
                    break;
            }

            Console.WriteLine("Please input the description.");
            string description = Console.ReadLine();

            Console.WriteLine("Please input the amount of the claim.");
            string inputAmt = Console.ReadLine();
            decimal claimAmount = decimal.Parse(inputAmt);

            Console.WriteLine("Please input the date of the incident as (mm/dd/yyyy).");
            string inputDOI = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(inputDOI);

            Console.WriteLine("Please input the date the claim was made as (mm/dd/yyyy).");
            string inputDOC = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(inputDOC);

            Claim newClaim = new Claim(claimID, typeOfClaim , description, claimAmount, dateOfIncident, dateOfClaim);
            _claimsRepo.NewClaim(newClaim);

            Console.WriteLine($"Claim {claimID} has been added.");
            Console.ReadLine();
        }
    }
}
