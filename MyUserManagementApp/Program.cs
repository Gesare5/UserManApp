using System;
using System.IO;

namespace MyUserManagementApp
{
    class Program
    {
        static void Main(string[] args)
        { 
        // creates an instance of the UserQueue class
        UserQueue<GetUserInput> userQueue1 = new UserQueue<GetUserInput>();

        bool toContinue = true;  // used to break the loop

        // path to file created to store changes
        string path = @"/home/gesare/Documents/womentechsters/C#/week 10/project/User App/MyUserManagementApp/UserInfo.txt";
        if(!File.Exists(path))
            {
                var file = File.CreateText(path);
                file.Dispose();
            }

        //  loop starts here
        while(toContinue == true)
            {
            // instantiates the GetUserInput class
            GetUserInput newUser = new GetUserInput();
            // instantiates the OptionsMenu class inorder to display options
            OptionsMenu newOptionsMenuInstance = new OptionsMenu();
            newOptionsMenuInstance.NewOptionsMenu();

            Console.Write("Pick a number: ");
            int selectedNumber = Convert.ToInt32(Console.ReadLine());  //user enters value
            Console.WriteLine();

            // this switch statement works with the value entered by user
            switch (selectedNumber)
            {
                case 1:
                {
                    Console.Clear();
                    // gets the new user's details and adds them to the queue
                    newUser.GetInput();
                    userQueue1.Enqueue(newUser);

                    // adds user details to created file as well
                    using(StreamWriter streamWriter = File.AppendText(path))
                    { 
                      streamWriter.WriteLine("{0} | {1} | {2} | {3}", 
                      newUser.FirstName, 
                      newUser.SecondName,
                      newUser.Email,
                      newUser.Food);
                    // streamWriter.Dispose();
                    }
                    System.Console.WriteLine("New User added successfully!");
                    System.Console.WriteLine();
                    toContinue = true;
                    break;
                }
                case 2:
                {
                    // removes top user from the queue
                    userQueue1.Dequeue();
                    System.Console.WriteLine("Top user removed!");
                    toContinue = true;
                    break;
                }
                case 3:
                {
                    System.Console.WriteLine("Changes saved.");
                    toContinue = true;
                    break;
                }
                case 4:
                { 
                    Console.Clear();
                    System.Console.WriteLine("FirstName | SecondName | Email | FavoriteFood");
                    System.Console.WriteLine("----------------------------------------------");

                    // prints out all current users from file
                    using (StreamReader streamReader = File.OpenText(path))
                    {
                        System.Console.WriteLine(streamReader.ReadToEnd());
                    }
                    toContinue = true;
                    break;
                }
                case 5:
                {
                    System.Console.WriteLine("Exiting.");
                    toContinue = false;
                    break;
                }
                default:
                {
                    System.Console.WriteLine("INVALID CHOICE!!");
                    toContinue = false;
                    break;
                }
            }
        } 

        }
    }
}
