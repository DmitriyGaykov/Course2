namespace lab6;
class PtrException : UserException
{
    public PtrException(ECode code) : base(Messages[code])
    {
    }

    protected static new Dictionary<ECode, string> Messages = new()
    {
        { ECode.ErrorNullptr, "Разыминование пустой ссылки" },
    };
}
