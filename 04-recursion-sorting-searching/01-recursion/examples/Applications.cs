namespace AlgoTraining.Topics.S04T01;

[Lesson("04-recursion-sorting-searching/01-recursion", "Рекурсия")]
public static class Applications
{
    public static void Run()
    {
        Folder catalog = new Folder(2, new Folder(3), new Folder(1, new Folder(0)));
        Check.Equal(6L, Canonical.CountFiles(catalog), "Файлы вложенных каталогов");
        Check.Equal(6L, Modern.CountFiles(catalog), "Итеративный аудит хранилища");
        Check.Equal(0L, Canonical.CountFiles(new Folder(0)), "Пустая папка");
    }
}
