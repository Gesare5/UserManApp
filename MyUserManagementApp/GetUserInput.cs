using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyUserManagementApp
{
    public class GetUserInput
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email {get; set;}
        public string Food { get; set; }

        // gets users name, email and favourite food
        public void GetInput()
        {
            Console.WriteLine("Enter User First Name:  ");
            this.FirstName = Console.ReadLine();
            Console.WriteLine("Enter User Second Name:  ");
            this.SecondName = Console.ReadLine();
            Console.WriteLine("Enter User Email:  ");
            string email = Console.ReadLine();
            
            // Checks if entered email is valid
             if (!GetUserInput.IsValidEmail(email))
            {
                throw new FormatException("Email is not valid");
            }
            this.Email = email;

            Console.WriteLine("Enter User Favourite Food:  ");
            string food = Console.ReadLine(); 
            
            //  checks if food entered is a number or contains a number
            bool isDigitPresent = food.Any(c => char.IsDigit(c));
            if (isDigitPresent == true)
            {
                throw new FormatException("Food cannot be or contain a number");
            }
            this.Food = food;
            // checks if food entered is a number
            // int check;
            // if (Int32.TryParse(this.Food, out check))
            // {
            //     throw new FormatException("Food cannot be or contain a number");
            // }  
        }

         static bool IsValidEmail(string email)
            {
                 // Return true if email is in valid e-mail format.
                return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
            }
        
    }
}