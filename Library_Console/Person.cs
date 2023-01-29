using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Console;

class Person
{
    //считываем путь к файлу с пользователями
    string path = "/Users/fetaniz/Desktop/Study/C#/Library_Console/Library_Console/Login_List.txt";
    public int ID;
    public string FirstName { get; set; }
    public string SecondtName { get; set; }
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }

    public Person(string firstName, string secondtName, string userLogin, string userPassword)
    {
        //информация о пользователях
        this.ID = this.get_new_id();
        FirstName = firstName;
        SecondtName = secondtName;
        UserLogin = userLogin;
        UserPassword = userPassword;
    }

    public int get_new_id()
    {
        //обновление айди на следующий по возрастанию
        int max_id = 0;
        string[] lines = File.ReadLines(path).ToArray();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i][0] > max_id)
            {
                max_id = lines[i][0];
            }
        }
        return max_id;
    }


    public override string ToString()
    {
        //вывод информации о пользователе
        return "" + ID + "," + FirstName + "," + SecondtName + "," + UserLogin + "," + UserPassword;
    }

}
//гость, он же пользователь
class Guest : Person
{
    public string Read_Ticket;

    public Guest(string firstName, string secondtName, string userLogin, string userPassword) : base(firstName, secondtName, userLogin, userPassword)
    {
    }
}
//работник, он же сотрудник библиотеки
class Worker : Person
{
    public Worker(string firstName, string secondtName, string userLogin, string userPassword) : base(firstName, secondtName, userLogin, userPassword)
    {
    }
}