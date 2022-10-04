namespace lab8;
static class StringCorrector
{
    #region Props

    public static string str
    {
        get;
        set;
    }

    #endregion

    #region Ctors

    static StringCorrector()
    {
        ToCorrect += () => str = StringCorrector.str.Replace(" ", "");
        ToCorrect += () => str = StringCorrector.str.ToLower();
        ToCorrect += () => str = StringCorrector.str + ".";
        ToCorrect += () => str = StringCorrector.str[0].ToString().ToUpper() + str.Substring(1); ;
        ToCorrect += () => str = StringCorrector.str.Replace("a", "");
    }

    #endregion

    #region Delegate

    public static Func<string> ToCorrect;

    #endregion

    #region Methods

    private static string Trim() => str = StringCorrector.str.Replace(" ", "");

    private static string ToLower() => str = StringCorrector.str.ToLower();

    private static string AddDoth() => str = StringCorrector.str + ".";

    private static string CorrectFirstLetter() => str = StringCorrector.str[0].ToString().ToUpper() + str.Substring(1);

    private static string DellA() => str = StringCorrector.str.Replace("a", "");

    #endregion
}
