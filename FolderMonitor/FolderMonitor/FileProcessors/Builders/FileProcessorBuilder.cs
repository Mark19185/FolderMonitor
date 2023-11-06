using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FolderMonitor.FileProcessors.Builders
{
    public class FileProcessorBuilder
    {
        FileProcessor _processor;

        Dictionary<string, Func<FileProcessor>> processorsMapping = new Dictionary<string, Func<FileProcessor>>()
        {
            { ".html", new Func<FileProcessor>(() => { return new HtmlProcessor(); }) },
            { ".css", new Func<FileProcessor>(() => { return new CSSProcessor(); }) },

        };

        public FileProcessorBuilder ForFileExtension(string extension)
        {
            if (!processorsMapping.ContainsKey(extension))
            {
                _processor = new TextProcessor();
            }
            else
            {
                _processor = processorsMapping[extension]?.Invoke();
            }

            return this;
        }

        public FileProcessorBuilder WithFilePath(string filePath)
        {
            _processor.FilePath = filePath;
            return this;
        }

        public FileProcessorBuilder WithResultFile(string resultFilePath)
        {
            _processor.ResultFilePath = resultFilePath;
            return this;
        }

        public FileProcessor Build() 
        {
            return _processor; 
        }

    }
}
