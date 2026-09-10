using System.ComponentModel;
using Spectre.Console;

namespace account_system_cs;

class Program
{
    public static string database = "account_database.csv";

    static void Main(string[] args)
    {
        AddAccountInterface();
        StartSelection();

        // creating of new accounts with passwords
        // logging into the new accounts
        // accounts having different permissions (root, normal user for now)
        // deleting accounts from list if you have root perms
        // no encryption cuz i suck
    }

    static void StartSelection()
    {
        Console.Clear();

        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do")
                .AddChoices("Login", "Create New Account", "Exit"));

        switch (mode)
        {
            case "Login":
                LoginProcess();
                break;
            case "Create New Account":
                AddAccountInterface();
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }

    static void LoginProcess()
    {
        Console.Clear();

        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        if (!(username is null || password is null)) // IF user typed in his username and password, this is too confusing and I'm too stupid to do recursion
        {
            Console.WriteLine($"Cool! You logged in with username {username} and password {password}"); // placeholder
            LoginManager(username, password);
        }
        else // if user did NOT type in his username or password
        {
            Console.Write("Please enter a username and password.");
            Console.ReadKey();
        }
    }

    static void LoginManager(string username, string password)
    {
        string[] accountList = File.ReadAllLines(database); // For going through the list of all accounts
        string[] accountInfo = new string[3]; // For initializing going through username and password

        for (int i = 0; i < accountList.Length; i++)
        {
            accountInfo = accountList[i].Split(',');
        }
    }

    static void AddAccountInterface()
    {
        Console.Clear();

        Console.Write("Enter new username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter new password: ");
        string? password = Console.ReadLine();
        Console.Write($"Should {username} have root access? (y/N) ");
        char rootAccess = Console.ReadKey().KeyChar;

        if (!(username is null || password is null)) // IF user typed in his username and password, this is too confusing and I'm too stupid to do recursion
        {
            AddAccount(username, password, rootAccess);
            Console.Write("Your account was successfully added to the database!");
            Console.ReadKey();
            StartSelection();
        }
        else // if user did NOT type in his username or password
        {
            Console.Write("Please enter a username and password.");
            Console.ReadKey();
        }
    }

    static void AddAccount(string username, string password)
    {
        string inputBuffer = username + "," + password + ",user\n";
        File.AppendAllText(database, inputBuffer);
    }
}
