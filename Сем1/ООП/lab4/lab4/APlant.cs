namespace lab4;
abstract class APlant
{
    public virtual TypePlant Type { get; init; }
    public virtual string Name { get; init; }
    public virtual DateTime WasPlanted { get; set; }
    public abstract DateTime WillBeRipen { get; }

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