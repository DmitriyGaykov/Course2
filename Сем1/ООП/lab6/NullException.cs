namespace lab6;
class NullException : UserException
{
    public NullException(ECode code) : base(Messages[code])
    { }

    protected static new Dictionary<ECode, string> Messages = new()
    {
        { ECode.ErrorDellNull, "На ноль делить нельзя!"},
    };
}
