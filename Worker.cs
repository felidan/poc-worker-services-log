using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace worker_service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        const string PATH = @"D:\LOG.TXT";
        const int TIME_DELAY = 3000;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Serviço sendo executado - {time}", DateTimeOffset.Now);
                
                string textoAtual = String.Empty;
                
                if(Directory.Exists(PATH))
                    textoAtual = File.ReadAllText(PATH);
                
                string textoNovo = "Serviço sendo executado em: " + DateTimeOffset.Now;

                using(StreamWriter stream = new StreamWriter(PATH))
                {
                    stream.WriteLine(textoAtual + textoNovo + Environment.NewLine);
                }

                await Task.Delay(TIME_DELAY, stoppingToken);
            }
        }
    }
}
