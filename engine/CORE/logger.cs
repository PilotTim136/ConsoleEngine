using System.Diagnostics;

namespace CEngine
{
    internal class Logger
    {
        private static string logFilePath = "log.txt";
        private static StreamWriter logStreamWriter = null!;
        private static bool isInitialized = false;

        static Logger()
        {
            try
            {
                File.WriteAllText(logFilePath, "");

                /*ProcessStartInfo psi = new ProcessStartInfo("notepad.exe", logFilePath)
                {
                    UseShellExecute = true
                };
                Process.Start(psi);*/
            }
            catch { }
        }

        private static void InitializeLogWriter()
        {
            if (!isInitialized)
            {
                try
                {
                    logStreamWriter = new StreamWriter(logFilePath, append: true);
                    logStreamWriter.AutoFlush = true;
                    isInitialized = true;
                }
                catch { }
            }
        }

        public static void Log(string message)
        {
            InitializeLogWriter();

            try
            {
                logStreamWriter.WriteLine($"{DateTime.Now}: {message}");
            }
            catch { }
        }
    }
}
