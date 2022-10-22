namespace lab4;
partial class ClassBouquet
{
    #region Methods

    public void AddFlower(AFlower Flower)
    {
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

    public string InfoAbout()
    {
        string info = $"{this.CurrentCount}\n";
        for (var i = 0; i < this.CurrentCount; i++)
        {
            info += $"{this.Flowers[i].GetType().ToString()}\n" +
                    $"{(int)this.Flowers[i].Color}\n" +
                    $"{this.Flowers[i].Name}\n" +
                    $"{this.Flowers[i].Price}\n" +
                    $"{this.Flowers[i].WasPlanted.Year}\n" +
                    $"{this.Flowers[i].WasPlanted.Month}\n" +
                    $"{this.Flowers[i].WasPlanted.Day}\n";
        }
        return info;
    }
    #endregion
}
