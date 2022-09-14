namespace lab4;
partial class ClassBouquet
{
    #region Methods

    public void AddFlower(AFlower Flower)
    {
        Console.WriteLine(((IPlant)Flower).IsGrow());
        if (this.CurrentCount != this.MaxCount && ((IPlant)Flower).IsGrow())
        {
            this.Flowers[this.CurrentCount++] = Flower;
        }
    }

    public void AddsFlower(params AFlower[] Flowers)
    {
        for (var i = 0; i < Flowers.Length; i++)
        {
            this.AddFlower(Flowers[i]);
        }
    }

    #endregion
}
