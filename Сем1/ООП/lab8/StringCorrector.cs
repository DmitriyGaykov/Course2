namespace lab8;
delegate void SrtC(ref string str);
static class StringCorrector
{
    public static SrtC ToCorrect;
    static StringCorrector()
    {
        ToCorrect += Trim;
        ToCorrect += ToLower;
        ToCorrect += AddDoth;
        ToCorrect += CorrectFirstLetter;
        ToCorrect += DellA;
    }
    /*#region Props

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
    */
    #region Methods

    private static void Trim(ref string str) => str = str.Replace(" ", "");

    private static void ToLower(ref string str) => str = str.ToLower();

    private static void AddDoth(ref string str) => str = str + ".";

    private static void CorrectFirstLetter(ref string str) => str = str[0].ToString().ToUpper() + str.Substring(1);

    private static void DellA(ref string str) => str = str.Replace("a", "");

    #endregion
}
