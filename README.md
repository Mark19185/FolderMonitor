<b>Краткий принцип работы:</b>
1. Мониторинг осуществляется с помощью типа FileSystemWatcher, для которого написана обёртка FolderWatcher. Список расширений, которые необходимо отслеживать и путь к папке, которую мониторит утилита подгружаются из файла конфигурации. Когда наблюдатель обнаружил новый файл, он дёргает событие OnFileCreated, в которое передаются расширение и путь к файлу.
2. Полученные из п.1 данные передаются в билдер, который отдаёт нужный процессор и на нём вызывается метод полиморфный метод "Execute".

   
<b>Устройство</b>
1. Для обработки каждого из расширений используются собственные обработчики (HtmlProcessor, CSSProcessor и общий обработчик для всех остальных форматов - TextProcessor), унаследованные от абстрактного типа FileProcessor. При желании можно легко расширить функционал обработчиков или же добавить новые.
2. Чтобы получить нужный обработчик, используется билдер.
3. Для подсчета вхождений в тексте, был добавлен метод расширения для типа string "CountOfOccurrences"
