export default class Iterator<T> 
{
    private index : number;
    private collection : T[];

    constructor(collection : T[])
    {
        this.index = 0;
        this.collection = collection;
    }

    public next() : T
    {
        if(this.index === this.collection.length)
        {
            this.reset();
        }

        return this.collection[this.index++];
    }

    public hasNext() : boolean
    {
        return this.index < this.collection.length;
    }

    public reset() : void
    {
        this.index = 0;
    }
}