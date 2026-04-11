using KLS_Furniture.DAL;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Lookups;

namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Handles employee login and logout operations.
    /// </summary>
    public class AuthController
    {
        private readonly EmployeeDBDAL employeeDBDAL;

        /// <summary>
        /// Initializes a new instance of the AuthController class with the provided data access layer.
        /// </summary>
        public AuthController(EmployeeDBDAL employeeDBDAL)
        {
            this.employeeDBDAL = employeeDBDAL;
        }

        /// <summary>
        /// Tries to log in the employee using the provided credentials.
        /// </summary>
        public bool Login(string username, string password)
        {
            //return employeeDBDAL.UpdatePassword(username, password);
            LoggedInUserLookupItem user = employeeDBDAL.AuthenticateUser(username, password);

            if (user == null)
            {
                return false;
            }

            CurrentSession.LoggedInUser = user;
            return true;
        }

        /// <summary>
        /// Logs out the current employee.
        /// </summary>
        public void Logout()
        {
            CurrentSession.Logout();
        }

        /// <summary>
        /// Returns the currently logged-in employee, or null if no one is logged in.
        /// </summary>
        public LoggedInUserLookupItem GetCurrentUser()
        {
            return CurrentSession.LoggedInUser;
        }

        /// <summary>
        /// Returns true if an employee is currently logged in.
        /// </summary>
        public bool IsLoggedIn()
        {
            return CurrentSession.IsLoggedIn;
        }

        /// <summary>
        /// Returns the display name for the logged-in employee.
        /// </summary>
        public string GetLoggedInUserDisplayText()
        {
            if (!CurrentSession.IsLoggedIn)
            {
                return "";
            }

            return CurrentSession.LoggedInUser.ToString();
        }
    }
}