using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_CSharp_lvl_2._5
{
    class DBClass
    {
        public List<Employee> employees = new List<Employee>();
        public List<Department> departments = new List<Department>();

        Random rnd = new Random();

        public void Init(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                DepAdd(new Department("department " + i));
            }

            for (int i = 0; i < x; i++)
            {
                EmpAdd(new Employee("fio " + i, rnd.Next(20, 60), departments[rnd.Next(0, y)].Name , rnd.Next(5000, 25000)));
            }
        }

        public void EmpAdd(Employee emp)
        {
            employees.Add(emp);
        }

        public void DepAdd(Department dep)
        {
            departments.Add(dep);
        }
    }

class Employee
    {
        public string FIO { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public Employee(string fio, int age, string dep, int salary)
        {
            FIO = fio;
            Age = age;
            Department = dep;
            Salary = salary;
        }

        public override string ToString()
        {
            return FIO;
        }

        public string DetailsToString()
        {
            return $"ФИО: {FIO}/n Возраст {Age}/n Департамент: {Department}/n Зарплата: {Salary}";
        }
    }

    class Department
    {
        public string Name { get; set; }

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
