using Lotus_Care.Administrator;
using Lotus_Care.CommonCode;
using Lotus_Care.CommonForms;
using Lotus_Care.Doctor;
using Lotus_Care.Nurse;
using Lotus_Care.Receptionist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Care
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Lotus\Lotus_Care\Lotus_Care\LotusCareDatabase.mdf;Integrated Security=True";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            //Application.Run(new Users());
            //Application.Run(new SelectedPatientDetails());

            bool exitApp = false;

            // Showing the Login form
            while (!exitApp)
            {
                using (Login loginForm = new Login())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Based on role, run the specific dashboard as the main form
                        //if (loginForm.UserRole == "Admin")
                        //{
                        //    Application.Run(new AdministratorDashboard());
                        //}
                        //else if (loginForm.UserRole == "Doctor")
                        //{
                        //    Application.Run(new DoctorDashboard());
                        //}
                        //else if (loginForm.UserRole == "Nurse")
                        //{
                        //    Application.Run(new NurseDashboard());
                        //} else if (loginForm.UserRole == "Receptionist")
                        //{
                        //    Application.Run(new ReceptionistDashboard());
                        //}
                        Form dashboard = null;

                        switch (loginForm.UserRole)
                        {
                            case UserRole.Admin:
                                Application.Run(new AdministratorDashboard(loginForm.UserRole));
                                break;
                            case UserRole.Doctor:
                                Application.Run(new DoctorNurse(loginForm.UserRole));
                                break;
                            case UserRole.Nurse:
                                Application.Run(new DoctorNurse(loginForm.UserRole));
                                break;
                            case UserRole.Receptionist:
                                Application.Run(new ReceptionistDashboard());
                                break;
                            default:
                                MessageBox.Show("Unknown role. Contact admin.");
                                break;
                        }

                        if (dashboard != null)
                        {
                            Application.Run(dashboard); // Run chosen dashboard
                        }
                    }
                    else
                    {
                        exitApp = true; // If login was canceled, exit loop -> close app
                    }
                }
            }
        }
    }
}
