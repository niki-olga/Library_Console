using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Console;

class Person
{
    string path = "/Users/fetaniz/Desktop/Study/C#/Library_Console/Library_Console/Login_List.txt";
    public int ID;
    public string FirstName { get; set; }
    public string SecondtName { get; set; }
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }



    public Person(string firstName, string secondtName, string userLogin, string userPassword)
    {
        this.ID = this.get_new_id();
        FirstName = firstName;
        SecondtName = secondtName;
        UserLogin = userLogin;
        UserPassword = userPassword;
    }

    public int get_new_id()
    {
        int max_id = 0;
        string[] lines = File.ReadLines(path).ToArray();
        for (int i = 0; i < lines.Length-1; i++)
        {
            if (lines[i][0] > max_id)
            {
                max_id = lines[i][0];
            }
        }
        return max_id;
    }

    public int get_id()
    {
        return this.ID;
    }

    public void set_id(int new_id)
    {
        string[] lines = File.ReadLines(path).ToArray();
        for (int i = 0; i < lines.Length-1; i++)
        {
            if (lines[i][0] == this.ID)
            {
                throw new Exception("такой id уже занят");
            }
        }
        for (int i = 0; i < lines.Length-1; i++)
        {
            if (lines[i][0] == this.ID)
            {
                lines[i][0] = new_id;

            }
        }
    }





    public override string ToString()
    {
        return "" + this.ID + "," + FirstName + "," + SecondtName + "," + UserLogin + "," + UserPassword;
    }

}


