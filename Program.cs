using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Transactions;

namespace nonlinearSearch
{
    class teamDatabase
    {
        // Host team arrays
        static string[,] hostTeam = new string[,]
        {
            { "Abdul Ahad", "M", "Purple", "IT", "Member" },
            { "Abdul Hadi", "M", "White", "Security", "Member" },
            { "Abdul Mateen", "M", "Purple", "Outreach", "Member" },
            { "Abdul Qadir", "M", "Orange", "Marketing", "Co-director" },
            { "Abdul Rehman", "M", "White", "Media", "Member" },
            { "Abdullah Irfan", "M", "White", "Security", "Member" },
            { "Abdul Wasae", "M", "White", "Security", "Member" },
            { "Adeel Anjum", "M", "Orange", "Liaison", "Director" },
            { "Ahad Shehzad", "M", "Green", "Registration", "Director" },
            { "Ahmed Hasen Khan", "M", "Blue", "Security", "Member" },
            { "Ahmed Salauddin", "M", "Green", "Security", "Member" },
            { "Ahmed Salar", "M", "Mauve", "Publications", "Member" },
            { "Aimal Khakan", "G", "", "Registration", "Member" },
            { "Aimel Khan", "M", "White", "Security", "Director" },
            { "Alia Zahoor", "G", "", "EC", "Head of Host Team" },
            { "Alizaad", "M", "Green", "Finance", "Member" },
            { "Alveena Zahoor", "G", "", "EC", "Under Secretary General" },
            { "Anas Khalid", "M", "Silver", "Logistics", "Member" },
            { "Anaya Hayat", "G", "", "Logistics", "Co-director" },
            { "Anoshka John", "G", "", "Security", "Co-director" },
            { "Anum Khurram", "G", "", "Logistics", "Member" },
            { "Arfa Tanveer", "G", "", "Committee Affairs", "Member" },
            { "Arham", "M", "Orange", "Liaison", "Member" },
            { "Arham Shafi", "M", "Mauve", "Logistics", "Co-director" },
            { "Arnawa", "G", "", "IT", "Member" },
            { "Aryam Fatima", "G", "", "Logistics", "Member" },
            { "Asbah Iqbal", "G", "", "Security", "Member" },
            { "Ayan Bin Amir", "M", "Purple", "Socials", "Member" },
            { "Ayeza Fatima", "G", "", "Socials", "Member" },
            { "Azain Atif", "M", "Mauve", "Liaison", "Co-director" },
            { "Azlan Faisal", "M", "Orange", "Finance", "Member" },
            { "Azlan Khan", "M", "Green", "Security", "Member" },
            { "Balaj Ali", "M", "Yellow", "Logistics", "Member" },
            { "Dania Faisal", "G", "", "Logistics", "Member" },
            { "Dawood Ul Hasen", "M", "Purple", "Registration", "Member" },
            { "Dayyan Ahmed Panezai", "M", "Blue", "EC", "Head of Host Team" },
            { "Dilskash Rehamn", "G", "", "Media", "Member" },
            { "Eitezaz Ali", "M", "White", "Security", "Member" },
            { "Eman Ali", "G", "", "Security", "Member" },
            { "Eman Zeenat", "G", "", "Publications", "Director" },
            { "Eshal Ashfaq", "G", "", "Media", "Member" },
            { "Eshal Nouman", "G", "", "Committee Affairs", "Member" },
            { "Eshal Oman", "G", "", "Registration", "Member" },
            { "Eshal Yasir", "G", "", "Publications", "Member" },
            { "Ezaan Shahid", "M", "Orange", "Outreach", "Member" },
            { "Faiza Dawood", "G", "", "Security", "Member" },
            { "Faiza Qazi", "G", "", "Marketing", "Member" },
            { "Farrukh Nihad", "M", "Red", "Outreach", "Member" },
            { "Fatima Alvi", "G", "", "Socials", "Member" },
            { "Fatima Ali Syed", "G", "", "Media", "Co-director" },
            { "Fatima Iqbal", "G", "", "Committee Affairs", "Co-director" },
            { "Fatima Khan", "G", "", "IT", "Member" },
            { "Fatima Nadeem", "G", "", "Marketing", "Member" },
            { "Fatima Shaukat", "G", "", "Finance", "Member" },
            { "Fatima Tuz Zehra", "G", "", "Socials", "Co-director" },
            { "Hadia Ahmed", "G", "", "Logistics", "Member" },
            { "Hafsa Ali", "G", "", "Publications", "Member" },
            { "Haiqa Rizwan", "G", "", "Liaison", "Director" },
            { "Hamdan Ishaq", "M", "Blue", "Logistics", "Member" },
            { "Hamza Ali", "M", "Orange", "Registration", "Co-director" },
            { "Hania Hawwa", "G", "", "Security", "Member" },
            { "Hasan Yasir Abbasi", "M", "White", "Security", "Member" },
            { "Hayyan Rasheed", "M", "Yellow", "Outreach", "Member" },
            { "Hooriya Javed", "G", "", "Socials", "Director" },
            { "Ibrahim Imtiaz", "M", "Green", "Security", "Co-director" },
            { "Inaya Binte Kshif", "G", "", "Security", "Member" },
            { "Izan Ishtiaq", "M", "Green", "Publications", "Director" },
            { "Izaan Qamar", "M", "Blue", "Finance", "Director" },
            { "Izhan Shoukat", "M", "White", "Finance", "Member" },
            { "Jannat Ahmad", "G", "", "Outreach", "Member" },
            { "Jannat Haroon", "G", "", "Outreach", "Co-director" },
            { "Jannat Nasir", "G", "", "Registration", "Director" },
            { "Javeria Naveed", "G", "", "Liaison", "Member" },
            { "Khadija Noor", "G", "", "Registration", "Member" },
            { "Khadijah farrukh", "G", "", "Marketing", "Member" },
            { "Khajista Zainab", "G", "", "Finance", "Director" },
            { "Khawaja Haris", "M", "Green", "Socials", "Director" },
            { "Layma Shah", "G", "", "Security", "Member" },
            { "M. Arham", "M", "Mauve", "Publications", "Member" },
            { "M. Ayan", "M", "Silver", "Liaison", "Member" },
            { "M. Ayan", "M", "White", "Outreach", "Member" },
            { "M. Ayan Khan", "M", "Red", "Marketing", "Director" },
            { "M Hasen Waqar", "M", "Yellow", "Logistics", "Member" },
            { "M. Mohib", "M", "Green", "IT", "Co-director" },
            { "M. Rafay Abbasi", "M", "Purple", "Registration", "Member" },
            { "M Zayyan Zohaib", "M", "Silver", "IT", "Member" },
            { "Maaz Affan", "M", "Silver", "Security", "Member" },
            { "Maha Zulfiqar", "G", "", "Publications", "Member" },
            { "Mahad Ehtesham", "M", "Blue", "Outreach", "Director" },
            { "Mahad Zeeshan", "M", "Orange", "Marketing", "Member" },
            { "Maham Ahmad", "G", "", "Marketing", "Director" },
            { "Mahin Ayaz", "G", "", "Finance", "Member" },
            { "Maryam Rehan", "G", "", "Committee Affairs", "Member" },
            { "Maryam Tariq", "G", "", "Outreach", "Member" },
            { "Mazen Touqeer", "M", "Orange", "Marketing", "Member" },
            { "Meerub fatima", "G", "", "IT", "Director" },
            { "Mohammed Abdullah Malhi", "M", "Mauve", "EC", "Under Secretary General" },
            { "Momina Rehab", "G", "", "Registration", "Member" },
            { "Moosa Obaid", "M", "Purple", "Committee Affairs", "Member" },
            { "Muhammad Essa Hashmi", "M", "Silver", "Media", "Member" },
            { "Muhammad Haris", "M", "Silver", "IT", "Member" },
            { "Muhammad Sagheer", "M", "Mauve", "Socials", "Co-director" },
            { "Muhammad Shahmeer", "M", "Mauve", "Security", "Member" },
            { "Muhammad Suleman Kamal", "M", "Blue", "Socials", "Member" },
            { "Muqeet Bux", "M", "Mauve", "Media", "Co-director" },
            { "Musa Mubashir", "M", "Yellow", "Finance", "Co-director" },
            { "Mustafa", "M", "White", "Security", "Member" },
            { "Mustafa Hussain", "M", "Blue", "Committee Affairs", "Director" },
            { "Myesha Irfan", "G", "", "EC", "Director General" },
            { "Nabeela Naveed", "G", "", "Socials", "Member" },
            { "Najeeb ur Rehman", "M", "Red", "EC", "Secretary General" },
            { "Natasha Fida", "G", "", "Publications", "Member" },
            { "Naveen Ahmed Yar", "G", "", "Socials", "Member" },
            { "Neha Amir", "G", "", "Media", "Member" },
            { "Omar Abdullah", "M", "Mauve", "Liaison", "Member" },
            { "Omar Zakir", "M", "Purple", "Committee Affairs", "Member" },
            { "Omer Abbasi", "M", "Yellow", "Logistics", "Member" },
            { "Qirat Zehra", "G", "", "Security", "Member" },
            { "Raja Shumail", "M", "Mauve", "Security", "Member" },
            { "Raja Uzair Younis", "M", "Purple", "EC", "Director General" },
            { "Rania Wadood", "G", "", "Socials", "Member" },
            { "Razan Naji", "G", "", "IT", "Co-director" },
            { "Rida Alam Khan", "G", "", "Outreach", "Director" },
            { "Romaisa Nizami", "G", "", "EC", "Secretary General" },
            { "Saad Abbasi", "M", "Red", "Logistics", "Director" },
            { "Saim Khan", "M", "Orange", "IT", "Director" },
            { "Samiullah", "M", "Silver", "Outreach", "Member" },
            { "Sana Murtaza", "G", "", "Security", "Member" },
            { "Sara Raza", "G", "", "Registration", "Co-director" },
            { "Sara Sarmad", "G", "", "Liaison", "Co-director" },
            { "Sehr Abbasi", "G", "", "Security", "Director" },
            { "Shanze Khan", "G", "", "Media", "Member" },
            { "Shanzay Omer", "G", "", "Logistics", "Director" },
            { "Shiza Usman", "G", "", "Marketing", "Co-director" },
            { "Shujauddin", "M", "Purple", "Publications", "Co-director" },
            { "Sophe Patafi", "G", "", "Liaison", "Member" },
            { "Syed M Ayan", "M", "Blue", "Finance", "Member" },
            { "Taha Habib", "M", "Red", "Socials", "Member" },
            { "Talal Khan Ghori", "M", "Red", "Media", "Director" },
            { "Talal Khawaja", "M", "Silver", "Socials", "Member" },
            { "Talha Khan", "M", "Red", "Media", "Member" },
            { "Tamiya Faisal", "G", "", "Outreach", "Member" },
            { "Tayyab Ashfaq", "M", "White", "Media", "Member" },
            { "Usna Raja", "G", "", "Security", "Member" },
            { "Usarim Nabeel", "M", "Blue", "Committee Affairs", "Co-director" },
            { "Ushna Shah", "G", "", "Finance", "Co-director" },
            { "Wasma Zahra", "G", "", "Security", "Member" },
            { "Yamna Farhan", "G", "", "Finance", "Member" },
            { "Yashfa Maheen", "G", "", "IT", "Member" },
            { "Yumainah Maryam", "M", "White", "Security", "Member" },
            { "Yusra Iqbal", "G", "", "Media", "Director" },
            { "Zahid", "M", "Blue", "Outreach", "Co-director" },
            { "Zain Ali", "M", "Green", "Security", "Member" },
            { "Zaina Zeeshan", "G", "", "Liaison", "Member" },
            { "Zaina Zeeshan ", "G", "", "Liaison", "Member" },
            { "Zainab sajjad", "G", "", "Committee Affairs", "Member" },
            { "Zeerak Hussain", "M", "Silver", "Registration", "Member" },
            { "Zimal Nisar", "G", "", "Committee Affairs", "Director" },
            { "Zoha Aziz", "G", "", "Marketing", "Member" },
            { "Zoha Sardar", "G", "", "Security", "Member" },
            { "Zohair Zulfiqar", "M", "Red", "Publications", "Member" },
            { "Zoraiz Jashal", "M", "Green", "IT", "Member" },
            { "Zunaira Hasan", "G", "", "Logistics", "Member" },
            { "Zyna Malik", "G", "", "IT", "Member" }
        };
        static string[] departments = new string[] 
        {
            "EC",
            "Liaison",
            "IT",
            "Committee Affairs",
            "Logistics",
            "Finance",
            "Marketing",
            "Media",
            "Outreach",
            "Publications",
            "Registration",
            "Socials",
            "Security" 
        };
        static string[] positions = new string[] {"Director", "Co-director", "Member"};
        static string[] executiveCouncil = new string[] { "Secretary General", "Director General", "Under Secretary General", "Head of Host Team" };

        // Fields for the search
        static string firstName = "";
        static string section = "";
        static string dept = "";
        static string post = "";
        static string gender = "";

        // Loop based booleans and search parameter arrays
        static bool mainLoop = true;
        static bool choiceBool = true; // This boolean will be used for the validation loops that we will place for the menu
        static bool errorDisplay = false; // This boolean will be used to explicitly state if the value entered is invalid
        static string menuChoice = "";
        static char[] alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        

        // List for the search results
        static List<int> searchResults = [];

        static void Main(string[] args)
        {
            clear();
            while (mainLoop)
            {
                clear();

                // Displaying the different fields to pick from for the search
                Console.WriteLine("BMIDC Rebirth\nHost Team Database\n\n");
                Console.WriteLine("Search fields:\n\n1. First Name\n2. Department\n3. Position\n4. Section\n5. Gender\n6. Clear fields\n\n7. Begin search");

                // Taking input for which field the user would like to search from
                Console.Write("\nPlease enter the number corrosponding to the field you would like to set: "); menuChoice = Console.ReadLine();
                clear();

                // Enabling the choiceBool boolean to use for the while loops
                choiceBool = true;

                if (menuChoice == "1") // Name selection
                {
                    while (choiceBool)
                    {
                        // Utilising booleans for verification of values entered
                        bool alphabetVerified;

                        clear();
                        if (errorDisplay) Console.WriteLine("ERROR! Your input either contained a symbol, a space, or was null. Please enter a valid value.");
                        errorDisplay = false;
                        Console.WriteLine("Enter the *FIRST* name of the person you would like to search for. Make sure there are no symbols and no spaces in the name.");
                        menuChoice = Console.ReadLine();

                        if (firstName == "") { errorDisplay = true; }
                        else
                        {
                            // Breaking down the whole word into individual characters in an array
                            char[] nameBroken = (firstName.ToUpper()).ToCharArray();
                            foreach (char character in nameBroken)
                            {
                                alphabetVerified = false;
                                foreach (char letter in alphabet)
                                {
                                    // If anyone of the characters is equal to the alphabet then it is flagged is correct
                                    if (letter == character)
                                    {
                                        alphabetVerified = true;
                                    }
                                }

                                // If the character from the nameBroken array is not in the alphabet, then it means it is invalid and must be re-entered
                                // For this we will use a selection statement further
                                if (!alphabetVerified)
                                    errorDisplay = true;
                            }
                            
                        }

                        // If all is set and done and no errorDisplay message is active, than the loop will close and return
                        // the user to the main menu
                        if (!errorDisplay) choiceBool = false;
                    }
                    firstName = menuChoice;
                } 
                else if (menuChoice == "2") // Department selection
                {
                    while (choiceBool)
                    {
                        clear();
                        
                        Console.WriteLine("The following is a list of all the departments in the database, and their assigned numbers:\n");
                        
                        // Using a for loop to display each department easier
                        for (int department = 0; department < departments.Length; department++)
                        {
                            Console.WriteLine($"{(department + 1)}. {departments[department]}");
                        }
                        Console.WriteLine(); // This acts as a full \n to create neatness
                        

                        if (dept != "") // Presence check
                            Console.WriteLine("The department for the search is currently set to ", dept);
                        if (errorDisplay) // Displays a message if the last value was invalid
                            Console.WriteLine("Your choice was invalid. Please enter a valid choice.");

                        // Taking the input for the choice
                        Console.Write("Enter the number associated with the department you would like to search: ");
                        menuChoice = Console.ReadLine();

                        // Utlising tryparse to ensure that the value is parsable to an Integer
                        // If it isnt then isParsable will be false
                        int deptChoice;
                        bool isParsable = int.TryParse(menuChoice, out deptChoice);
                        errorDisplay = false;

                        // Using the parsed statement
                        if (isParsable)
                        {
                            // Using a range check
                           if (deptChoice >= 1 && deptChoice <= departments.Length)
                           {
                                // Reducing the value by 1 to fit it into range for the array's index
                                deptChoice--;
                                dept = departments[deptChoice];
                           }
                           else
                           {
                                errorDisplay = true;
                           }
                        }
                        else { errorDisplay = true; }

                        if (!errorDisplay)
                            choiceBool = false;
                    }
                }
                else if (menuChoice == "3") // Position selection menu
                {
                    while (choiceBool)
                    {
                        /*
                         IMPORTANT TO NOTE ABOUT THIS SELECTION MENU!!!!!

                        The positions will be displayed based on whether the department chosen is the Executive Council or not
                        By default, it will present the directors, co dirs, and team members
                        However, if the department is set to EC, it will set it to the EC Positions instead
                        If the department is changed to something else after being set to the EC, and the position is one of the EC
                        positions, then that position will be replaced. This has already been coded into the department selection.
                        
                         */

                        clear();


                        // Basic display message
                        Console.WriteLine("The following is a list of positions and their associated numbers:\n");
                        
                        // Setting up the parse variables a little late but still
                        int choiceInteger;
                        bool isParsable;
                        
                        //// Utilising selection statement to print the positions
                        // Both utilise for loops to work
                       if (dept == "EC") // <------ This selection statement prints only the EC positions
                            for (int posit = 0; posit < executiveCouncil.Length; posit++)
                            {
                                Console.WriteLine($"{posit + 1}. {executiveCouncil[posit]}");
                            }
                        else // <--------- This selection statement prints the rest of the positions
                            for (int posit = 0; posit < positions.Length; posit++)
                            {
                                Console.WriteLine($"{posit + 1}. {positions[posit]}");
                            }

                        // Taking input into menuChoice
                        Console.Write("\nType the number associated with the post you would like to set for the search: ");
                        menuChoice = Console.ReadLine();

                        // TryParse-ing the value to get a boolean and an integer (if parsed)
                        isParsable = int.TryParse(menuChoice, out choiceInteger);
                        choiceInteger--; // Decrementing the integer to make it usable for the array

                        // Using a boolean that works based off of whether or not the dept is set to the EC or not,
                        // stored into a variable for effeciency
                        bool isEC = dept == "EC";

                        if (isParsable) // Selection statement which only works in the case of a value that is parsable
                        {
                            if (isEC && choiceInteger >= 0 && choiceInteger < 3) // This checks if the value is in range for the EC posts
                                post = executiveCouncil[choiceInteger];
                            else if (!isEC && choiceInteger >= 0 && choiceInteger < 4) // This checks of the value is in range for the default posts
                                post = positions[choiceInteger];
                            else
                                errorDisplay = false;
                        } 
                        else { errorDisplay = false; }

                        if (!errorDisplay)
                            choiceBool = false;
                    }
                }
                else if (menuChoice == "5") // Menu for gender selection
                {
                    // Page for the selection of the gender for the search
                    while (choiceBool)
                    {
                        clear();
                        // Case statement for gender already selected
                        if (gender == "")
                            Console.WriteLine("No gender specified for search");
                        else if (gender == "M" || gender == "G")
                            Console.WriteLine($"Current gender specified for search: {gender}");

                        // List of options
                        Console.WriteLine("\n1. Male (BMI-B)\n2. Female (BMI-G)\n");

                        if (errorDisplay)
                            Console.WriteLine("Invalid choice! Please enter a valid option from those displayed above.");
                        Console.Write("Enter the number corresponding to the choice you wish to make: "); menuChoice = Console.ReadLine();

                        // Selection of gender variable
                        if (menuChoice == "1")
                            gender = "M";
                        else if (menuChoice == "2")
                            gender = "G";  // This exists to simply do NOTHING and send the user back to the menu
                        else
                            errorDisplay = true;

                        // Selection to remove the errorDisplay boolean for future use
                        if (menuChoice == "1" || menuChoice == "2" || menuChoice == "3")
                        {
                            errorDisplay = false;
                            choiceBool = false;
                        }
                    }
                }   
            }
        }



        static void clear()
        {
            Console.Clear();
        }
    }
}