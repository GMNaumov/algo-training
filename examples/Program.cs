using System.Reflection;
using System.Text;
using AlgoTraining;
using AlgoTraining.Topics;

Console.OutputEncoding = Encoding.UTF8;
if (args is ["--verify"])
{
    try
    {
        Verification.Run();
        Console.WriteLine($"Проверок: {Check.Count}, ошибок: 0.");
        return 0;
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"ОШИБКА: {exception.Message}");
        return 1;
    }
}
var lessons = Assembly.GetExecutingAssembly().GetTypes()
    .Select(type => (Type: type, Info: type.GetCustomAttribute<LessonAttribute>()))
    .Where(item => item.Info is not null)
    .OrderBy(item => item.Info!.Id, StringComparer.Ordinal).ToArray();

if (args is ["--list"])
{
    foreach (var lesson in lessons)
        Console.WriteLine($"{lesson.Info!.Id} — {lesson.Info.Title}");
    return 0;
}

if (args.Length != 1)
{
    Console.WriteLine("Передайте --list, --all, --verify или полный путь темы из --list.");
    return 2;
}

var selected = lessons.Where(item => args[0] == "--all" || item.Info!.Id == args[0]).ToArray();
if (selected.Length == 0)
{
    Console.Error.WriteLine("Тема не найдена. Список: --list");
    return 2;
}

int failures = 0;
foreach (var lesson in selected)
{
    Console.WriteLine($"\n{lesson.Info!.Id} — {lesson.Info.Title}");
    try
    {
        lesson.Type.GetMethod("Run", BindingFlags.Public | BindingFlags.Static)!.Invoke(null, null);
    }
    catch (Exception exception)
    {
        failures++;
        Console.Error.WriteLine($"ОШИБКА: {(exception.InnerException ?? exception).Message}");
    }
}
Console.WriteLine($"\nТем: {selected.Length}, проверок: {Check.Count}, ошибок: {failures}.");
return failures == 0 ? 0 : 1;
