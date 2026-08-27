using Spectre.Console;

namespace account_system_cs;

class Program
{
    public static string database = "account_database.csv";

    static void Main(string[] args)
    {
        StartSelection();

        // creating of new accounts with passwords
        // logging into the new accounts
        // accounts having different permissions (root, normal user for now)
        // deleting accounts from list if you have root perms
        // no encryption cuz i suck
    }

    static void StartSelection()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do")
                .AddChoices("Login", "Create New Account", "Exit"));

        switch (mode)
        {
            case "Login":
                LoginProcess();
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }

    static void LoginProcess()
    {
        while (1 == 1)
        {
            string username;
            string password;

            Console.Clear();

            Console.Write("Enter username: ");
            username = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            if (username == null || password == null)
            {
                Console.Write("Please enter a username and password.");
                Console.ReadKey();
            } else
            {
                // Login manager
                Console.WriteLine($"Cool! You logged in with username {username} and password {password}"); // placeholder
            }
        }

    }
}
