class ButtonClass {
    //#region Fields
    className;
    text;
    //#endregion
    //#region Properties
    get ClassName() {
        return this.className;
    }
    set ClassName(value) {
        this.className = value;
    }
    get Text() {
        return this.text;
    }
    set Text(value) {
        this.text = value;
    }
    //#endregion
    //#region Constructors
    /**
     *
     */
    constructor(className, text) {
        this.className = className;
        this.text = text;
    }
    //#endregion
    //#region Methods
    toHTML() {
        return `<button class="${this.className}">${this.text}</button>`;
    }
}
