namespace Lab1;
static class ExString
{
    #region PointA
    // Объявите строковые литералы.Сравните их
    public static void EqualsString()
    {
        string str1 = "Hello";
        string str2 = "World";
        string str3 = "Hello";
        Console.WriteLine(str1 == str2); // false
        Console.WriteLine(str1 == str3); // true
    }
    #endregion
    #region PointB
    /*Создайте три строки на основе String.Выполните: сцепление,
копирование, выделение подстроки, разделение строки на слова,
вставки подстроки в заданную позицию, удаление заданной
подстроки. (https://docs.microsoft.com/ruru/dotnet/api/system.string?view=netcore-3.1 ) Продемонстрируйте
интерполирование строк*/
    public static void StringMethods()
    {
        // сцепление строк:
        string Name = "Ivan";
        string Surname = "Ivanov";
        string FullName;
        FullName = $"{Name} {Surname}"; //  == Ivan Ivanov
        // копирование строк:
        string CopyName = Name; // string.Copy(Name);
        // выделение подстроки:
        string NumberText = "Number is 123841784";
        int IndexFromCopy = NumberText.IndexOf("is "); // == 7
        string Number = NumberText.Substring(IndexFromCopy + 3); // == 123841784
        // разделение строки на слова:
        string[] Words = NumberText.Split(' '); // == ["Number", "is", "123841784"]
        // вставки подстроки в заданную позицию:
        string InsertText = NumberText.Insert(IndexFromCopy, "not "); // == Number is not 123841784
        // удаление заданной подстроки:
        string DeleteText = NumberText.Remove(IndexFromCopy, 3); // == Number 123841784
        // интерполяция строк:
        string Interpolation = $"Hello, {Name} {Surname}"; // == Hello, Ivan Ivanov
    }

    #endregion
    #region PointC
    /*Создайте пустую и null строку.Продемонстрируйте
использование метода string.IsNullOrEmpty.Продемонстрируйте
что еще можно выполнить с такими строками*/
    public static void NullString()
    {
        string EmptyString = string.Empty;
        string NullString = null;

        bool TestEmptyString = string.IsNullOrEmpty(EmptyString); // == true
        bool TestNullString = string.IsNullOrEmpty(NullString) /* Аналог IsNullOrWhiteSpace(NullString) */; // == true
    }
    #endregion
    #region PointD
    /*Создайте строку на основе StringBuilder.Удалите определенные
    позиции и добавьте новые символы в начало и конец строки*/
    public static void StringBuilder()
    {
        StringBuilder StrBuilder = new("Hello World");
        StrBuilder.Remove(6, 5); // == Hello
        StrBuilder.Insert(0, "Hello "); // == Hello Hello
        StrBuilder.Append(" World"); // == Hello Hello World
    }
    #endregion
}