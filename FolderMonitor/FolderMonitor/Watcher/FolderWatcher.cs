using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FolderMonitor.Monitor
{
    /*
     * Обертка для мониторинга папки
     * 
     * Т.к дефолтный фильтр для FileSystemWatcher поддерживает только одно расширение,
     * то в качестве обходного решения храним в конфиге список обрабатываемых расширений и 
     * сравниваем их во время выполнения события OnCreate
     */

    public class FolderWatcher
    {
        IConfiguration Configuration { get; init; }

        List<string> targetExtensions = new List<string>();
        FileSystemWatcher FileSystemWatcher { get; init; }

        /// <summary>
        /// Событие возвращает расширение и полный путь соответственно
        /// </summary>
        public Action<Tuple<string, string>> OnFileCreated;


        public FolderWatcher(IConfiguration config)
        {
            Configuration = config;

            targetExtensions = config.GetSection("TargetExtensions").Get<List<string>>();

            FileSystemWatcher = new FileSystemWatcher(config["FolderForMonitoring"])
            {
                IncludeSubdirectories = true,
                EnableRaisingEvents = true,
            };

            FileSystemWatcher.Created += OnCreated;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            //Игнорим результирующий файл
            if (e.FullPath == Configuration["ResultFilePath"])
            {
                return;
            }

            var fileExtension = Path.GetExtension(e.FullPath);

            if (!targetExtensions.Contains(fileExtension))
            {
                return;
            }

            OnFileCreated?.Invoke(new Tuple<string, string>(fileExtension, e.FullPath));
        }
    }
}
