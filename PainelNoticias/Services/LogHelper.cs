using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelNoticias.Services
{
    public class LogHelper
    {
        private readonly string _logFilePath;

        // Construtor que define o caminho do arquivo de log
        public LogHelper(string logFileName = "application.log")
        {
            // Obtém o diretório atual de execução da aplicação
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Define o caminho completo do arquivo de log
            _logFilePath = Path.Combine(currentDirectory, logFileName);
        }

        // Método para escrever no log
        public void WriteLog(string message)
        {
            try
            {
                // Formata a mensagem de log com data e hora
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

                // Escreve a mensagem no arquivo (cria o arquivo se não existir)
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Exceções podem ser tratadas conforme necessário
                Console.WriteLine($"Erro ao escrever no log: {ex.Message}");
            }
        }

        // Método opcional para obter o caminho do arquivo de log
        public string GetLogFilePath()
        {
            return _logFilePath;
        }
    }

}
