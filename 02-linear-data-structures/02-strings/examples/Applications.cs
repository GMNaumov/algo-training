namespace AlgoTraining.Topics.S02T02;

[Lesson("02-linear-data-structures/02-strings", "Строки")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(true, Canonical.IsPalindrome("топот"), "Симметричное слово");
        Check.Equal(true, Modern.IsPalindrome("😀a😀"), "Название с emoji");
        Check.Equal(false, Canonical.IsPalindrome("дом"), "Несовпадающие края");
        Check.Equal(true, Modern.IsPalindrome(""), "Пустая строка");
        Check.Equal("новый заказ", Modern.JoinWords(["новый", "заказ"]), "Сборка подписи");
    }
}
