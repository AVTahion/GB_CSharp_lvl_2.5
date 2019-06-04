using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_CSharp_lvl_2._5
{
    class DBClass
    {
        public ObservableCollection<Employee> Employees { set; get; }
        public ObservableCollection<Department> Departments { set; get; }

        Random rnd = new Random();

        public void Init(int x, int y)
        {
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();
            DepAdd(new Department( 0, "none"));

            for (int i = 1; i < y; i++)
            {
                DepAdd(new Department(i, "department " + i));
            }

            for (int i = 0; i < x; i++)
            {
                EmpAdd(new Employee(Departments[rnd.Next(1, y)].ID, "fio " + i, rnd.Next(20, 60), rnd.Next(5000, 25000)));
            }
        }

        /// <summary>
        /// Метод добавляет нового сотрудника в БД
        /// </summary>
        /// <param name="emp"></param>
        public void EmpAdd(Employee emp)
        {
            Employees.Add(emp);
        }

        /// <summary>
        /// Метод удаляет указанного сотрудника из БД
        /// </summary>
        /// <param name="emp"></param>
        public void EmpDel(Employee emp)
        {
            Employees.Remove(emp);
        }

        /// <summary>
        /// Метод добавляет указанный департамент в Бд
        /// </summary>
        /// <param name="x">Департамент для добавления в БД</param>
        public void DepAdd(Department x)
        {
            Departments.Add(x);
        }

        /// <summary>
        /// Департамент добавляет новый департамен в БД
        /// </summary>
        public void DepAdd()
        {
            int b = Departments.Last().ID + 1;
            Departments.Add(new Department(b, "department " + b));
        }

        /// <summary>
        /// Метод удаляет указанный департамент из БД
        /// </summary>
        /// <param name="x"></param>
        public void DelDep(Department x)
        {
            if (x.Name != "none" || x.ID != 0)
            {
                foreach (var emp in Employees)
                {
                    if (emp.DepID == x.ID) emp.DepID = 0;
                }
                Departments.Remove(x);
            }
        }
    }

    class Employee : ICloneable
    {
        public string FIO { get; set; }
        public int Age { get; set; }
        public int DepID { get; set; }
        public int Salary { get; set; }

        public Employee(int dep = 0, string fio = "new_fio", int age = 0, int salary = 0)
        {
            FIO = fio;
            Age = age;
            DepID = dep;
            Salary = salary;
        }

        public object Clone() => this.MemberwiseClone();
    }

    class Department
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Department(int id, string name)
        {
            Name = name;
            ID = id;
        }
    }
}
