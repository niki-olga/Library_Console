using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Library_Console;

class Program
{
    public static void Main()
    {
        //выбор действия
        Console.WriteLine("For Login enter 'Log'");
        Console.WriteLine("For register enter 'Reg'");
        string? input = Console.ReadLine();

        if (input == "Log")
        {
            Console.Clear();
            Login();
        }
        else if (input == "Reg")
        {
            Console.Clear();
            Reg();
        }
        else
        {
            Console.WriteLine("Press any button to try again");
            Console.ReadKey();
            Console.Clear();
            Main();
        }
    }
    public static void Login()
    {
        //путь к файлу с логинами
        string path = "/Users/fetaniz/Desktop/Study/C#/Library_Console/Library_Console/Login_List.txt";
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();

        bool loginSuccessful = false;
        //считываем путь и проверяем файл построчно
        using (StreamReader reader = new StreamReader(path))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {//данные разделены , сравниваем те, что с 3 и 4 разделителем (логин, пароль)
                var creds = line.Split(',');
                if (username == creds[3] && password == creds[4])
                {
                    loginSuccessful = true;
                    break;
                }
            }
            reader.Close();
        }

        if (loginSuccessful && username.Contains("admin"))
        {
            Console.WriteLine("Admin Login Successful! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            AdminMenu();
        }
        else if (loginSuccessful && username.Contains("user"))
        {
            Console.WriteLine("User Login Successful! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            UserMenu();
        }
        else
        {
            Console.WriteLine("Username or password is incorrect. Try again");
            Console.ReadKey();
            Console.Clear();
            Login();
        }

        static void AdminMenu()
        {
            Console.WriteLine("Admin Main menu");
            Console.Read();
        }

        static void UserMenu()
        {
            Console.WriteLine("User Main menu");
            Console.Read();
        }

    }
    public static void Reg()
    {
        string path = "/Users/fetaniz/Desktop/Study/C#/Library_Console/Library_Console/Login_List.txt";
        Console.WriteLine("Enter your First name: ");
        string? firstname = Console.ReadLine();
        Console.WriteLine("Enter your Second name: ");
        string? secondname = Console.ReadLine();
        Console.WriteLine("Enter your username: ");
        string? username = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        string? password = Console.ReadLine();

        Person newPerson = new Person(firstname, secondname, username, password);

        using (StreamReader reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(newPerson.ToString());
                }
                break;

            }

            reader.Close();
        }

        Console.Read();
    }
}