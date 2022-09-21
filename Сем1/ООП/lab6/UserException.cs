namespace lab6;
class UserException : Exception
{
    #region Props



    #endregion

    #region Ctors

    public UserException(ECode code) : base(Messages[code]) { }

    public UserException(string message) : base(message)
    { }

    #endregion

    #region Code of exceptions

    public enum ECode
    {
        ErrorInCreateUserName,
        ErrorInCreateUserAge,
        ErrorDellNull,
        ErrorInCalculateMenu,
        ErrorNullptr,
    }

    #endregion

    #region Dictionary with message of error

    protected static Dictionary<ECode, string> Messages = new()
    {
        { ECode.ErrorInCreateUserName , "Ошибка в создании пользователя | Ошибка ввода имени" },
        { ECode.ErrorInCreateUserAge,  "Ошибка в создании пользователя | Ошибка ввода поля возраста"},
        { ECode.ErrorInCalculateMenu, "Неверные данные в меню" },
    };

    #endregion
}
