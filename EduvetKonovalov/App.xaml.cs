using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EduvetKonovalov
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string DeptName { get; set; }

        public string AddLoginName { get; set; }

        public string AddPasswordName { get; set; }

        public string EditLoginAdminName { get; set; }

        public string EditPasswordAdminName { get; set; }

        public string EditPassportOneAdminName { get; set; }

        public string EditLoginStaffName { get; set; }

        public string EditPasswordStaffName { get; set; }

        public string EditPassportOneStaffName { get; set; }

        public string EditLoginAdminOneName { get; set; }

        public string EditLoginStaffOneName { get; set; }

        public string AddComingAdmin { get; set; }

        public string AddConsumptionAdmin { get; set; }

        public string AddRemainderAdmin { get; set; }

        public string EditComingAdmin { get; set; }

        public string EditConsumptionAdmin { get; set; }

        public string EditRemainderAdmin { get; set; }

        public string AddComingStaff { get; set; }

        public string AddConsumptionStaff { get; set; }

        public string AddRemainderStaff { get; set; }

        public string EditComingStaff { get; set; }

        public string EditConsumptionStaff { get; set; }

        public string EditRemainderStaff { get; set; }

        public string CheckAdmin { get; set; }

        public string CheckUser { get; set; }

        public string UserLogin { get; set; }

        public string ListBoxUserIndex { get; set; }

        public string ListBoxUserSearch { get; set; }

        public bool CheckLogin { get; set; }

        public string ColumsExcel { get; set; }
        public string AddPassportName { get; internal set; }
    }
}
