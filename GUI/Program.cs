using TubesKPL_Kelompok_2.Database;
using GUI.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string configPath = Path.Combine(AppContext.BaseDirectory, "Data", "currency_config.json");
            RuntimeConfig.Instance.Load(configPath);
            DatabaseHelper.InitializeDatabase();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
