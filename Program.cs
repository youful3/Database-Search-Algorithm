using System;
using System.ComponentModel.DataAnnotations;
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
            { "Arham Goroya", "M", "Mauve", "Publications", "Member" },
            { "Ayan", "M", "Silver", "Liaison", "Member" },
            { "Ayan", "M", "White", "Outreach", "Co-director" },
            { "Ayan Khan", "M", "Red", "Marketing", "Director" },
            { "Hasen Waqar", "M", "Yellow", "Logistics", "Member" },
            { "Mohib", "M", "Green", "IT", "Co-director" },
            { "Rafay Abbasi", "M", "Purple", "Registration", "Member" },
            { "Zayyan Zohaib", "M", "Silver", "IT", "Member" },
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
            { "Abdullah Malhi", "M", "Mauve", "EC", "Under Secretary General" },
            { "Momina Rehab", "G", "", "Registration", "Member" },
            { "Moosa Obaid", "M", "Purple", "Committee Affairs", "Member" },
            { "Essa Hashmi", "M", "Silver", "Media", "Member" },
            { "Haris", "M", "Silver", "IT", "Member" },
            { "Sagheer", "M", "Mauve", "Socials", "Co-director" },
            { "Shahmeer", "M", "Mauve", "Security", "Member" },
            { "Suleman Kamal", "M", "Blue", "Socials", "Member" },
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
            { "Zahid", "M", "Blue", "Outreach", "Member" },
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
        static string[] departments =  
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
        static string[] positions = {"Director", "Co-director", "Member"};
        static string[] executiveCouncil = { "Secretary General", "Director General", "Under Secretary General", "Head of Host Team" };
        static string[] sections = {
                                "Blue",
                                "Green",
                                "Mauve",
                                "Orange",
                                "Purple",
                                "Red",
                                "Silver",
                                "White",
                                "Yellow"
                            };
        

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
        static char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        

        // List for the search results
        static List<int> searchResults = [];
        // Used by the first name search algorithm to store the similarity scores for each entry in the database,
        // which will be used to determine if the entry is similar enough to the search name to be a result, and to sort the results by similarity
        static List<float> similarityScores = [];

        static void Main(string[] args)
        {
            clear();
            while (mainLoop)
            {
                // Resetting the search results list to clear the previous search results for the new search, and other result lists/arrays
                // as well as clearing the console for neatness
                searchResults = [];
                similarityScores = [];
                clear();

                // Displaying the different fields to pick from for the search
                Console.WriteLine("BMIDC Rebirth\nHost Team Database\n\n");
                Console.WriteLine
                    (
                    "Search fields:\n\n" +
                    "1. First Name\n" +
                    "2. Department\n" +
                    "3. Position\n" +
                    "4. Section\n" +
                    "5. Gender\n" +
                    "6. Clear fields\n\n" +
                    "7. Begin search"
                    );

                // Taking input for which field the user would like to search from
                Console.Write("\nPlease enter the number corrosponding to the field you would like to set: "); menuChoice = Console.ReadLine();
                clear();

                // Enabling the choiceBool boolean to use for the while loops
                choiceBool = true;

                if (menuChoice == "1") // Name selection
                {
                    while (choiceBool)
                    {

                        clear();
                        if (errorDisplay) Console.WriteLine("ERROR! Your input either contained a symbol, a space, or was null. Please enter a valid value.");
                        errorDisplay = false;
                        Console.WriteLine("Enter the *FIRST* name of the person you would like to search for. Make sure there are no symbols and no spaces in the name.");
                        menuChoice = Console.ReadLine();


                        if (menuChoice == "") { errorDisplay = true; }
                        else
                        {
                            // Breaking down the whole word into individual characters in an array
                            char[] nameBroken = firstName.ToUpper().ToCharArray();
                            foreach (char character in nameBroken)
                            {
                                // Using selection to verify if the character is the alphabet
                                if (!(alphabet.Contains(character)))
                                    errorDisplay = true;
                            }
                        }

                        // If all is set and done and no errorDisplay message is active, than the loop will close and return
                        // the user to the main menu, and this selection statement will also set the first name for the search
                        if (!errorDisplay)
                        {
                            choiceBool = false;
                            firstName = menuChoice;
                        }
                    }
                    firstName = menuChoice;
                }
                else if (menuChoice == "2") // Department selection
                {
                    while (choiceBool)
                    {
                        // Declaring and initialising menu specific local variables for the department selection menu
                        bool isPostEC = executiveCouncil.Contains(post);
                        /* This variable is used to store the value of the department before the department is changed,
                         so that if the department is changed from EC to something else, and the post is one of the EC posts,
                         then it can be replaced with a default value to avoid errors */
                        string deptBefore = dept;
                        // Used to check if the position selected is not in the EC
                        bool isPostDept = positions.Contains(post);
                        // This variable is used to check if the department is currently set to EC for the position selection menu
                        bool isPositionSet = post != "";
                        bool flagged = false;
                        /* Declaring now to initialise later based on the boolean logic,
                           as it is not necessary to initialise it if the position is not set, or if the position is in the department positions */
                        bool isNewPostEC;


                        clear();

                        Console.WriteLine("The following is a list of all the departments in the database, and their assigned numbers:\n");

                        // Using a for loop to display each department easier
                        for (int department = 0; department < departments.Length; department++)
                        {
                            Console.WriteLine($"{(department + 1)}. {departments[department]}");

                            // Adding a further selection statement warning the user if the position they have selected is in the EC,
                            // as that will change the options for the position selection
                            if (departments[department] == "EC" && isPositionSet)
                            {
                                if (!isPostEC)
                                    Console.WriteLine($">>> NOTE: The position for your search has been set to {post} which is not in the Executive Council; Setting it to the Executive Council will reset the position.\n");
                                else if (isPostEC)
                                    Console.WriteLine($">>> NOTE: The position for your search is currently set to {post} which is in the Executive Council; Setting the department to anything other than the Executive Council will reset the position.\n");
                            }
                        }
                        Console.WriteLine(); // This acts as a full \n to create neatness

                        // Initialising for boolean logic
                        isNewPostEC = executiveCouncil.Contains(post);

                        if (dept != "") // Presence check
                            Console.WriteLine("The department for the search is currently set to " + dept);
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

                        // Using boolean logic as much as possible to decide if the post must be reset or not
                        flagged = (isNewPostEC && !isPostEC) || (!isNewPostEC && isPostEC);

                        // Using the parsed statement
                        if (isParsable && inRange(deptChoice, departments))
                        {
                            // Reducing the value by 1 to fit it into range for the array's index
                            deptChoice--;
                            dept = departments[deptChoice];

                            // Resetting the position if the boolean logic for flagged comes back as true
                            if (flagged)
                            {
                                post = "";
                            }
                        }
                        else
                        { errorDisplay = true; }


                        // If there is no error, then the loop will end and the user will be returned to the main menu
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
                        
                        Further note that inRange cannot be used here as there are two possible lists with varying lengths.
                        Wese tho flowkirkenuinely I could do something but its needlessly complicated especially if this code is to be
                        recycled for future use.

                        This menu is a sole exception.

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

                        // Checking if the input value is within the given range for the menu

                        // Using a boolean that works based off of whether or not the dept is set to the EC or not,
                        // stored into a variable for effeciency
                        bool isEC = dept == "EC";

                        if (isParsable) // Selection statement which only works in the case of a value that is parsable
                        {
                            // This checks if the value is in range for the EC posts
                            if (isEC && inRange(choiceInteger, executiveCouncil))
                                post = executiveCouncil[choiceInteger];
                            else if (!isEC && inRange(choiceInteger, positions)) // This checks of the value is in range for the default posts
                                post = positions[choiceInteger];
                            else
                                errorDisplay = false;
                        }
                        else { errorDisplay = false; }

                        if (!errorDisplay)
                            choiceBool = false;
                    }
                }
                else if (menuChoice == "4")
                {
                    while (choiceBool)
                    {
                        if (gender != "G")
                        {
                            clear();

                            // Case statement to display the current section selected for the search
                            if (section == "")
                                Console.WriteLine("No section specified for search");
                            else
                                Console.WriteLine($"Current section specified for search: {section}");

                            // Setting up the parse variables a little late but still
                            int choiceInteger = 0;
                            bool isParsable;

                            // List of options for the section selection
                            Console.WriteLine("The following is a list of positions and their associated numbers:\n");
                            for (int sect = 0; sect < sections.Length; sect++)
                            {
                                Console.WriteLine($"{sect + 1}. {departments[sect]}");
                            }

                            // Taking input into menuChoice
                            Console.Write("\nType the number associated with the section you would like to set for the search: ");
                            menuChoice = Console.ReadLine();

                            // Parsing the choice through TryParse
                            isParsable = int.TryParse(menuChoice, out choiceInteger);
                            choiceInteger--; // Decrementing the integer to make it usable for the array

                            // Utilising selection statement to validate the input 
                            if (!isParsable || !inRange(choiceInteger, sections))
                                errorDisplay = true;
                            else
                            {
                                // Setting the section variable to the section selected and ending the loop if there is no error
                                section = sections[choiceInteger];
                                errorDisplay = false;
                                choiceBool = false;
                            }
                        }
                        else
                        {
                            clear();
                            Console.WriteLine("This field is unavailable to BMI-G (Girls) as they are not assigned sections in the database." +
                                " Please select a different field for your search, or change your gender field.");
                        }
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

                        if (section != "")
                            Console.WriteLine("WARNING: If you set the gender to Female, your sections field will be cleared.");

                        if (errorDisplay)
                            Console.WriteLine("Invalid choice! Please enter a valid option from those displayed above.");
                        Console.Write("Enter the number corresponding to the choice you wish to make: "); menuChoice = Console.ReadLine();

                        // Selection of gender variable
                        if (menuChoice == "1")
                            gender = "M";
                        else if (menuChoice == "2") {
                            gender = "G"; 
                            section = ""; // Clearing the section
                        }
                        else
                            errorDisplay = true;

                        // Selection to remove the errorDisplay boolean for future use
                        if (menuChoice == "1" || menuChoice == "2")
                        {
                            errorDisplay = false;
                            choiceBool = false;
                        }
                    }
                }
                else if (menuChoice == "6") // Clear fields menu
                {
                    clear();

                    // Taking confirmation for the clearing of the fields to avoid accidental clearing
                    Console.WriteLine("This will reset/wipe all fields that you have currently set." + "\n" +
                                      "Are you sure you would like to continue?");
                    Console.Write("To confirm, enter Y, and to return to menu without resetting fields press [ENTER]: ");
                    menuChoice = Console.ReadLine();
                    menuChoice = menuChoice.ToUpper();

                    Console.WriteLine(); // For neatness ofc

                    // Using selection to reset the fields if the user confirms, and to return to the menu if they dont confirm
                    if (menuChoice == "Y" || menuChoice == "YES")
                    {
                        firstName = "";
                        section = "";
                        dept = "";
                        post = "";
                        Console.WriteLine("Clearing fields...");
                    }
                    else
                        Console.WriteLine("Fields not cleared. Returning to menu...");

                    // Pausing the menu to let the user read what's actually happening before returning to the menu
                    Thread.Sleep(2500);
                }
            }
        }

        // Method to check if an input index is within the range of an array, used for validation of menu choices
        static bool inRange<T>(int inputIndex, T[] array) 
        {
            return inputIndex >= 0 && inputIndex < array.Length;
        }

        // Method to clear the console, used multiple times in the program to make it more user friendly
        static void clear()
        {
            Console.Clear();
        }

        #region

        /*
        
        
        Method to get search results based on the fields selected,
        These methods will be the main algorithms behind everything regarding the searches
        The use of lists will be crucial in all of these contexts
        
        >>> First Name:
        The most process heavy algorithm will be the one that checks for the first name, as that is the most unique identifier, 
        and will be the most efficient to check first, 
        as it will reduce the number of entries for the rest of the algorithms to check through significantly, increasing efficiency drastically.
        Furthermore, it will also need to be dynamic and be able to check for similar names as well. If I was to type in Osarm it would still return me Usarim.
        If I was to type Adil, it would show Adeel, and if I was to type in Ayan, it would show me all the Ayans. 
        This is a very important feature as it will make the search much more user friendly and efficient, as the user may not remember 
        the exact spelling of the name, but they can still find the person they are looking for with a similar name.
        We will use alot of Mathematical equtions here. I'll honestly have to wing it alot.


        */

        #endregion

        //// First name search algorithm
        static List<int> getFirsNameResults(string searchName, string[,] database, int index /* This is the index of the name within the database */ )
        {
            //// Declaring local variable(s) for the algorithm
            // List of unique characters within the name itself, all uppercase
            List<char> searchNameBroken = searchName.ToUpper().ToCharArray().Distinct().ToList();
            int length = searchNameBroken.Count;
            List<int> results = [];
            // List of the indices of the results within the database/ List of the similarity scores for each entry in the database,


            // *Sigh* this is gonna be a long one
            // Using a for loop to check each name in the database one by one
            for (int i = 0; i < database.GetLength(0); i++)
            {
                // Breaking down the name in the database into characters as well, and making them uppercase for uniformity
                List<char> nameInDatabaseBroken = database[i, index].ToUpper().ToCharArray().Distinct().ToList();
                // Using a value to check if the name in the database is similar enough to the search name to be a result
                float similarity = 0;
                // Boolean to decide whether each index is worth it as a result
                bool validResult = false;

                // Using a for loop to check each character in the search name against the characters in the name in the database
                for (int j = 0; j < searchNameBroken.Count; j++)
                {
                    // Further nesting another for loop
                    for (int k = 0; k < nameInDatabaseBroken.Count; k++)
                    {
                        // If there is a match between the character in the search name and the character in the name in the database,
                        // then the similarity score will increase by 1
                        if (searchNameBroken[j] == nameInDatabaseBroken[k])
                        {
                            similarity++;
                        }
                    }
                }

                // Converting the similarity score to a percentage
                similarity = (similarity / length) * 100;

                // Once all the characters have been checked, the similarity score will be divided by the total number of unique characters
                // in the search name to get a percentage similarity score. There will also be certain nuemrical thresholds for what counts as a
                // result, and what doesnt, which will be determined through selection statements,
                if (length >= 4)
                {
                    if (similarity >= 60)
                        validResult = true;
                }
                else if (length == 3)
                {
                    if (similarity >= 66.66)
                        validResult = true;
                }
                else if (length >= 2)
                {
                    if (similarity == 100)
                        validResult = true;
                }

                // Selection statement to decide if the results are worth storing or not, based on the boolean validResult
                if (validResult)
                {
                    results.Add(i);
                    similarityScores.Add(similarity);
                }
            }

            return results;
        }
    }
}