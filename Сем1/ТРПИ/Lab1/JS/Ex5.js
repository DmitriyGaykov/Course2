class Figure {
    Width = 0;
    Height = 0;

    constructor(Width, Height) {
        this.Width = Width;
        this.Height = Height;
    }

    GetSquare = () => this.Width * this.Height;

    HowManyAreThere = Fig => {
        let Result = this.GetSquare() / Fig.GetSquare();
        return Math.floor(Result);
    }
}

let RectA = new Figure(45, 21);
let Square = new Figure(5, 5);
let Count = RectA.HowManyAreThere(Square);
alert(Count);