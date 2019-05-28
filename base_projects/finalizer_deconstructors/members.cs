using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace finalizer_deconstrucors
{
class Members
{
    private string memberName;
    private string jobTitle;
    public int age;
    public int salary = 53000;

    public string Prop_jobTitle
    {
        get => jobTitle;
        set => jobTitle = value;
    }

    public string Prop_memberName
    {
        get => memberName;
        set => memberName = value;
    }

    public int Prop_age
    {
        get => age;
        set => age = value;
    }

    public int Prop_salary
    {
        get => salary;
        set => salary = value;
    }

    public void Introducting(bool isFriend)
    {
        if(isFriend)
        {
            SharingPrivateInfo();
        }
        else
        {
            Console.WriteLine("hi, my name is {0}. and my job title is {1}. I'm {1} years old", arg0:Prop_memberName,
            arg1: Prop_age);
        }
    }

    private void SharingPrivateInfo()
    {
        Console.WriteLine("my salary is {0}", arg0: Prop_salary);
    }
    public Members()
    {
        Prop_age = 30;
        Prop_memberName = "lucy";
        Prop_jobTitle = "developer";
        Prop_salary = 54000;
        Console.WriteLine("Member Created");
    }
        //finalizer and destructor
    ~Members()
    {
            //clean up statments
            Console.WriteLine("deconstrcution of Members Object");
            Debug.Write("decsontrction successful");
    }
}
}