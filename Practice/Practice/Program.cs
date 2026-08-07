using System;
using System.Windows.Forms;
using Practice.Classes;
using System.Drawing;
using Serilog; // Добавлено пространство имен для Serilog

namespace Practice
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Инициализация и настройка Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Устанавливаем минимальный уровень логирования
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Запись в файл с ежедневной ротацией
                .CreateLogger();

            try
            {
                Log.Information("Запуск приложения...");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Логирование фатальной ошибки, если приложение упадет
                Log.Fatal(ex, "Приложение завершилось с критической ошибкой");
            }
            finally
            {
                // Обязательный вызов для сброса буфера и закрытия файла логов перед выходом
                Log.CloseAndFlush();
            }
        }
    }
}