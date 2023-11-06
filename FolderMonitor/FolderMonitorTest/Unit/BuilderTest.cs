using FolderMonitor.FileProcessors;
using FolderMonitor.FileProcessors.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMonitorTest.Unit
{
    public class BuilderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test() 
        {
            var fileProcessorForHtml = new FileProcessorBuilder()
                .ForFileExtension("html")
                .WithFilePath("D:\\MonitorTest\\Текстовый документ (3).html")
                .WithResultFile("D:\\MonitorTest\\result.txt")
                .Build();

            var fileProcessorForTxt = new FileProcessorBuilder()
                .ForFileExtension("txt")
                .WithFilePath("D:\\MonitorTest\\Текстовый документ (3).html")
                .WithResultFile("D:\\MonitorTest\\result.txt")
                .Build();

            Assert.True(fileProcessorForHtml is HtmlProcessor);
            Assert.True(fileProcessorForTxt is TextProcessor);
        }
    }
}
