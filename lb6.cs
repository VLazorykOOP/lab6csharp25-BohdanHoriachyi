 Lab 6 C# Program with multiple tasks
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#region Interfaces
interface IShowable
{
    void Show();
}

interface IPersona
{
    void ShowInfo();
    int GetAge();
}
#endregion

#region Base Class and Inheritance
abstract class BaseOrganization  IShowable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public abstract void Show();
    public virtual string GetInfo() = $Org {Name}, Address {Address};
    ~BaseOrganization() = Console.WriteLine($Destructing {Name});
    public string this[string prop] = prop == Name  Name  Address;
}

class InsuranceCompany  BaseOrganization
{
    public string InsuranceType { get; set; }
    public override void Show() = Console.WriteLine($Insurance {Name}, Type {InsuranceType});
}

class OilGasCompany  BaseOrganization
{
    public int Wells { get; set; }
    public override void Show() = Console.WriteLine($Oil & Gas {Name}, Wells {Wells});
}

class Factory  BaseOrganization
{
    public int Employees { get; set; }
    public override void Show() = Console.WriteLine($Factory {Name}, Employees {Employees});
}
#endregion

#region Persona classes
class Applicant  IPersona
{
    public string Surname;
    public DateTime BirthDate;
    public string Faculty;
    public void ShowInfo() = Console.WriteLine($Applicant {Surname}, Faculty {Faculty}, Age {GetAge()});
    public int GetAge() = DateTime.Now.Year - BirthDate.Year;
}

class Student  IPersona
{
    public string Surname;
    public DateTime BirthDate;
    public string Faculty;
    public int Course;
    public void ShowInfo() = Console.WriteLine($Student {Surname}, Faculty {Faculty}, Course {Course}, Age {GetAge()});
    public int GetAge() = DateTime.Now.Year - BirthDate.Year;
}

class Teacher  IPersona
{
    public string Surname;
    public DateTime BirthDate;
    public string Faculty;
    public string Position;
    public int Experience;
    public void ShowInfo() = Console.WriteLine($Teacher {Surname}, {Position}, {Faculty}, Experience {Experience}, Age {GetAge()});
    public int GetAge() = DateTime.Now.Year - BirthDate.Year;
}
#endregion

#region Custom Exception
class MyMemoryException  Exception
{
    public MyMemoryException(string msg)  base(msg) { }
}
#endregion

#region Collection with IEnumerable
class OrganizationGroup  IEnumerableBaseOrganization
{
    private ListBaseOrganization orgs = new();
    public void Add(BaseOrganization org) = orgs.Add(org);
    public IEnumeratorBaseOrganization GetEnumerator() = orgs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() = GetEnumerator();
}
#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine(Choose lab task (1-4));
        string task = Console.ReadLine();

        switch (task)
        {
            case 1
                BaseOrganization[] companies =
                {
                    new InsuranceCompany { Name = SafeLife, InsuranceType = Life },
                    new OilGasCompany { Name = DeepDrill, Wells = 40 },
                    new Factory { Name = SteelCorp, Employees = 300 }
                };
                foreach (var c in companies)
                {
                    c.Show();
                    Console.WriteLine(c[Name]);
                    Console.WriteLine(Type  + c.GetType());
                }
                break;
            case 2
                IPersona[] people =
                {
                    new Applicant { Surname = Ivanov, BirthDate = new DateTime(2006, 5, 1), Faculty = Physics },
                    new Student { Surname = Petrov, BirthDate = new DateTime(2003, 3, 15), Faculty = IT, Course = 2 },
                    new Teacher { Surname = Sidorov, BirthDate = new DateTime(1980, 12, 1), Faculty = Math, Position = Lecturer, Experience = 10 }
                };
                foreach (var p in people) p.ShowInfo();
                Console.WriteLine(Age range (from-to));
                int from = int.Parse(Console.ReadLine());
                int to = int.Parse(Console.ReadLine());
                foreach (var p in people.Where(p = p.GetAge() = from && p.GetAge() = to)) p.ShowInfo();
                break;
            case 3
                try
                {
                    throw new MyMemoryException(Custom simulated memory issue);
                }
                catch (MyMemoryException ex)
                {
                    Console.WriteLine(Caught custom exception  + ex.Message);
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(OutOfMemoryException  + ex.Message);
                }
                break;
            case 4
                var group = new OrganizationGroup();
                group.Add(new Factory { Name = AutoPlant, Employees = 100 });
                group.Add(new InsuranceCompany { Name = GuardInsure, InsuranceType = Health });
                foreach (var org in group)
                    org.Show();
                break;
            default
                Console.WriteLine(Invalid input);
                break;
        }
    }
}