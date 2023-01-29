using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

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
            //переход к логину
            Console.Clear();
            Login();
        }
        else if (input == "Reg")
        {
            //переход к регистрации
            Console.Clear();
            Reg();
        }
        else
        {
            //если не совпадает, то просьба попробовать сначала
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
        //ввод логина и пароля с клавиатуры
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
        //при успешном логине и наличие в логине admin, заходим в меню админов
        if (loginSuccessful && username.Contains("admin"))
        {
            Console.WriteLine("Admin Login Successful! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            AdminMenu();
        }
        //аналогично с админами, но пользовательское меню
        else if (loginSuccessful && username.Contains("user"))
        {
            Console.WriteLine("User Login Successful! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            UserMenu();
        }
        //если нет совпадений, то просьба заново ввести логин и пароль
        else
        {
            Console.WriteLine("Username or password is incorrect. Try again");
            Console.ReadKey();
            Console.Clear();
            Login();
        }
        //админское меню
        static void AdminMenu()
        {
            Console.WriteLine("Admin Main menu");
            Console.WriteLine("Current books available:");
            //считывание списка книг из текстового файла
            string path = "/Users/fetaniz/Desktop/Study/C#/Git/Library_Console/Library_Console/Books.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    //вывод книг построчно. Информация о книгах разделена запятыми
                    var creds = line.Split(',');
                    Console.WriteLine("Title: " + creds[0] + ", Author: " + creds[1]+", Code: " + creds[2]+", Description: " + creds[3]+", Status: " + creds[4]);
                }
                reader.Close();
            }
            Console.Read();

            Console.Read();
        }
        //пользовательское меню
        static void UserMenu()
        {
            Console.WriteLine("User Main menu");
            //чтение пользователей
            string path = "/Users/fetaniz/Desktop/Study/C#/Git/Library_Console/Library_Console/Guest_Info.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    //приветсвуем пользователя и выводим его информацию
                    var creds = line.Split(',');
                    Console.WriteLine("Welcome, "+creds[0]+" " + creds[1]);
                    Console.WriteLine("Your Reading Ticket is " + creds[2]);
                    Console.WriteLine("Your have " + creds[3]+" books on hand");
                    Console.WriteLine("Your took " + creds[4]+" books");
                }
                reader.Close();
            }
            Console.Read();
        }

    }
    //окно регитсрации
    public static void Reg()
    {
        //считывание пути к файлу с логин-паролями
        string path = "/Users/fetaniz/Desktop/Study/C#/Library_Console/Library_Console/Login_List.txt";
        //считывание имени,фамилии,логина и пароля с клавиатуры
        Console.WriteLine("Enter your First name: ");
        string? firstname = Console.ReadLine();
        Console.WriteLine("Enter your Second name: ");
        string? secondname = Console.ReadLine();
        Console.WriteLine("Enter your username: ");
        string? username = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        string? password = Console.ReadLine();

        //создание новой персоны с данными выше
        Person newPerson = new Person(firstname, secondname, username, password);

        //добавление персоны с введенными данными в файл с логин-паролями
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