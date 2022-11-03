namespace Exesize5_2;

class Client
{
    #region Fields
    
    private string name;
    private Channel channel = null;
    
    #endregion

    #region Props

    public string? Name
    {
        get => name;
        set => name = value ??
                      "default";
    }

    public Channel? Channel
    {
        get => channel;
        set => channel = value;
    }

    #endregion

    #region Ctors

    public Client(string? name) => Name = name;

    #endregion

    #region Methods


    #endregion
}
