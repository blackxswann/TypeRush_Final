using TypeRush_Final.UI.LevelUpAndLeaderboard;

namespace TypeRush_Final
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormContainer());
        }
    }
    public enum Caller
    {
        SignUp = 1,
        LogIn = 2,
        Verification = 3,
        ResetPassword = 4
    }
    public enum AuthenticationError
    {
        usernameExists = 1, 
        emailExists = 2, 
        usernameAndEmailExists = 3,
        successfulOperation = 4,
        usernameNotFound = 5,
        incorrectPassword = 6,
        databaseError = 7
    }
}