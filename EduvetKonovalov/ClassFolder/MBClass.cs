using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.Entity.Validation;

namespace EduvetKonovalov.ClassFolder
{
    internal class MBClass
    {
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ErrorMB(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void InfoMB(string text)
        {
            MessageBox.Show(text, "Информация",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static bool QestionMB(string text)
        {
            return MessageBoxResult.Yes ==
            MessageBox.Show(text, "Вопрос",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
        }

        public static void ExitMB()
        {
            bool result = QestionMB("Вы действительно желаете выйти?");
            if (result == true)
            {
                App.Current.Shutdown();
            }
        }

        public static void ErrorMB(DbEntityValidationException ex)
        {
            foreach (DbEntityValidationResult validationError in
                ex.EntityValidationErrors)
            {
                foreach (DbValidationError err in validationError
                    .ValidationErrors)
                {
                    InfoMB(err.ErrorMessage + " \n" + "Object: " + validationError
                        .Entry.Entity.ToString());
                }
            }
        }
    }
}
