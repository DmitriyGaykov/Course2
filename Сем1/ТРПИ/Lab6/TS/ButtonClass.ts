class ButtonClass 
{
    //#region Fields

    private className : string;
    private text : string;

    //#endregion

    //#region Properties

    public get ClassName() : string
    {
        return this.className;
    }

    public set ClassName(value : string)
    {
        this.className = value;
    }
    
    public get Text() : string
    {
        return this.text;
    }

    public set Text(value : string)
    {
        this.text = value;
    }

    //#endregion

    //#region Constructors

    /**
     *
     */
    constructor(className: string,
                text: string) 
    {
        this.className = className;
        this.text = text;
    }

    //#endregion

    //#region Methods

    public toHTML() : string
    {
        return `<button class="${this.className}">${this.text}</button>`;
    }

    //#endregion
}
