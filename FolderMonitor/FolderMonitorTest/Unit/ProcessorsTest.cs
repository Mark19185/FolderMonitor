using FolderMonitor.FileProcessors;

namespace FolderMonitorTest.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HtmlProcessorTest()
        {
            HtmlProcessor processor = new HtmlProcessor()
            {
                FilePath = "D:\\MonitorTest\\Текстовый документ (3).html",
                ResultFilePath = "D:\\MonitorTest\\result.txt"
            };
            processor.Execute();
        }

        [Test]
        public void CssProcessorTest()
        {
            CSSProcessor processor = new CSSProcessor()
            {
                FilePath = "D:\\MonitorTest\\cssfile.css",
                ResultFilePath = "D:\\MonitorTest\\result.txt"
            };
            processor.Execute();
        }

        [Test]
        public void TextProcessorTest()
        {
            TextProcessor processor = new TextProcessor()
            {
                FilePath = "D:\\MonitorTest\\testText.txt",
                ResultFilePath = "D:\\MonitorTest\\result.txt"
            };
            processor.Execute();
        }
    }
}