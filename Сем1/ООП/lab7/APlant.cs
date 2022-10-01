namespace lab4;
abstract class APlant
{
    public virtual TypePlant Type { get; set; }
    public virtual string Name { get; set; }
    public virtual DateTime WasPlanted { get; set; }
    public abstract DateTime WillBeRipen { get; set; }

    public APlant(string Name) =>
        this.Name = Name;

    public abstract void Plant();
}

enum TypePlant
{
    BUSH,
    TREE,
    FLOWER,
    CACTUS
}