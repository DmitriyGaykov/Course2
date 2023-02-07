export default class Iterator {
    index;
    collection;
    constructor(collection) {
        this.index = 0;
        this.collection = collection;
    }
    next() {
        if (this.index === this.collection.length) {
            this.reset();
        }
        return this.collection[this.index++];
    }
    hasNext() {
        return this.index < this.collection.length;
    }
    reset() {
        this.index = 0;
    }
}
