namespace lab6;
class Logger
{
    #region Field

    private static readonly string Path = "log.txt";

    private DateTime ErrorTime;

    private DateTime EndTime;

    private string Message;

    private readonly DateTime StartTime;

    #endregion

    #region Constructors

    public Logger()
    {
        using StreamWriter LogFile = new(Path, false);
        StartTime = DateTime.Now;
        Message = StartTime.ToString();
        LogFile.WriteLine(Message);
    }

    #endregion

    #region Methods

    public void WriteLine(string msg)
    {
        using StreamWriter LogFile = new(Path, true);
        LogFile.WriteLine(msg);
    }

    public void WriteError(string msg)
    {
        using StreamWriter LogFile = new(Path, true);
        ErrorTime = DateTime.Now;
        Message = msg;
        LogFile.WriteLine($"Error: {Message}\n at {ErrorTime}");
    }
    public void WriteEnd()
    {
        EndTime = DateTime.Now;
        this.WriteLine(EndTime.ToString());
    }


    #endregion
}




//.Как называется процесс, который вызывает сервисную функцию с помощью некоторых определённых операций
//     -сервис
//  -клиент
//- сервер

//Как форматировать код в Visual Studio  C# автоматически 
/*/*/

