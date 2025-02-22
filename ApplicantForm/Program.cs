using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicantForm
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //// Инициализация базы данных
            //AdmissionCommitteeBackend.DatabaseHelper.InitializeDatabase();

            // Запуск формы авторизации
            Application.Run(new LoginForm());
        }
    }
}
