using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*  1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
    2. Для списка сотрудников и списка департаментов предусмотреть визуализацию(отображение). Это можно сделать, например, с использованием ComboBox или ListView.
    3. Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность изменить департамент у сотрудника.Список департаментов для выбора можно выводить в ComboBox,
        и все это можно выводить на дополнительной форме.
    4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать это либо на форме редактирования, либо сделать новую форму.

    Александр Кушмилов
*/

namespace GB_CSharp_lvl_2._5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Lesson7; Integrated Security = True; Pooling=False

                DBClass db = new DBClass();

        public MainWindow()
        {
            InitializeComponent();
            db.Init(100, 10);
            this.DataContext = db;
        }

        private void ListOfDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listOfEmp.ItemsSource = db.Employees.Where(
                w => w.DepID == (listOfDep.SelectedItem as Department)?.ID
                );

            //TODO отображение названия департамента в списке
            //Department tempDep = listOfDep.SelectedItem as Department;
            //ColumnDep.DisplayMemberBinding =  tempDep.Name;

        }

        private void Btn_DepDel_Click(object sender, RoutedEventArgs e)
        {
            db.DelDep(listOfDep.SelectedItem as Department);
        }

        private void Btn_DepAdd_Click(object sender, RoutedEventArgs e)
        {
            db.DepAdd();
        }

        private void Btn_EmpDel_Click(object sender, RoutedEventArgs e)
        {
            db.EmpDel(listOfEmp.SelectedItem as Employee);
            listOfEmp.ItemsSource = db.Employees.Where(
               w => w.DepID == (listOfDep.SelectedItem as Department)?.ID
               );
        }

        private void Btn_EmpAdd_Click(object sender, RoutedEventArgs e)
        {
            db.EmpAdd(new Employee((listOfDep.SelectedItem as Department).ID));
            listOfEmp.ItemsSource = db.Employees.Where(
               w => w.DepID == (listOfDep.SelectedItem as Department)?.ID
               );
        }

        private void Btn_EmpChange_Click(object sender, RoutedEventArgs e)
        {
            if (listOfEmp.SelectedItem != null)
            {
                new Win_EmpChanging(db, db.Employees.IndexOf(listOfEmp.SelectedItem as Employee)).ShowDialog();
            }
        }
    }
}
