namespace TourManagerment
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
            // Chạy LoginForm trước
            MainForm main = new MainForm(null);
            Application.Run(main);




        }
    }
}