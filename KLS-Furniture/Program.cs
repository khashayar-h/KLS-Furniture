using KLS_Furniture;
using KLS_Furniture.Controller;
using KLS_Furniture.DAL;
using KLS_Furniture.DebugTools;
using KLS_Furniture.View;
using System;
using System.Threading;
using System.Windows.Forms;

namespace KLSFurniture
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnUiThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            try
            {
                /// smoke test for rental save functionality, can be removed after testing
                /// RentalDebugRunner.RunRentalSaveSmokeTest();

                EmployeeDBDAL employeeDBDAL = new EmployeeDBDAL();
                AuthController authController = new AuthController(employeeDBDAL);

                while (true)
                {
                    using (LoginForm loginForm = new LoginForm(authController))
                    {
                        DialogResult result = loginForm.ShowDialog();

                        if (result != DialogResult.OK)
                        {
                            break;
                        }
                        Application.Run(new MainForm(loginForm, authController));
                    }
                }
                
            }
            catch (Exception ex)
            {
                ShowFatalErrorAndExit(ex);
            }
        }

        private static void OnUiThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowFatalErrorAndExit(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception
                           ?? new Exception("A non-exception error was thrown by the runtime.");

            ShowFatalErrorAndExit(ex);
        }

        private static void ShowFatalErrorAndExit(Exception ex)
        {
            MessageBox.Show(
                "Unexpected error occurred. The application will close.\n\n" + ex.Message,
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            Environment.Exit(1);
        }
    }
}