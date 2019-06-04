﻿using System;
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
using System.Windows.Shapes;

namespace GB_CSharp_lvl_2._5
{
    /// <summary>
    /// Логика взаимодействия для Win_EmpChanging.xaml
    /// </summary>
    public partial class Win_EmpChanging : Window
    {
        internal Win_EmpChanging(DBClass db, int x)
        {
            InitializeComponent();
            //txtb_Fio.DataContext = db.Employees[x];
            //txtb_Age.DataContext = db.Employees[x];
            //txtb_Salary.DataContext = db.Employees[x];
            //CmbBox_Dep.DataContext = db;
            //CmbBox_Dep.SelectedIndex = db.Departments.IndexOf(db.Departments[db.Employees[x].DepID]);
            Employee tempEmp = (Employee)db.Employees[x].Clone();
            this.DataContext = tempEmp;
            CmbBox_Dep.DataContext = db;
            CmbBox_Dep.SelectedIndex = db.Departments.IndexOf(db.Departments.Single(w => w.ID == tempEmp.DepID));

            btn_Ok.Click += delegate
            {
                db.Employees[x].FIO = txtb_Fio.Text;
                db.Employees[x].Age = int.Parse(txtb_Age.Text);
                db.Employees[x].Salary = int.Parse(txtb_Salary.Text);
                db.Employees[x].DepID = db.Departments[CmbBox_Dep.SelectedIndex].ID;
                DialogResult = true;
            };

            btn_Cancel.Click += delegate { DialogResult = false; };
        }
    }
}
