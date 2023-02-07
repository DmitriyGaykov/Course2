import {IBoot} from "./IBoot.js";
import {ICategory} from "./ICategory.js";
import {IProducts} from "./IProducts.js";

const bootAddidas1 : IBoot = 
{
    ID: 5,
    Size: 24,
    Color: "Red",
    Price: 123
};

const bootAddidas2 : IBoot = 
{
    ID: 101,
    Size: 53,
    Color: "Yellow",
    Price: 900
};
const sandalNike1 : IBoot =
{
    ID: 142,
    Size: 24,
    Color: "Blue",
    Price: 189
}
const sneakersRunner1 : IBoot =
{
    ID: 11,
    Size: 23,
    Color: "Red",
    Price: 150
}

const Boots : ICategory = 
{
    ID: 1,
    Boots: [bootAddidas1, bootAddidas2]
}

const Sandals : ICategory =
{
    ID: 2,
    Boots: [sandalNike1]
}

const Sneakers : ICategory =
{
    ID: 3,
    Boots: [sneakersRunner1]
}

const products : IProducts = 
{
    Products: Boots.Boots.concat(Sandals.Boots, Sneakers.Boots)
}
console.log(`
    Exesize 1
`)
products.Products.forEach(element => {
    console.log(element.ID);
});

export default products;