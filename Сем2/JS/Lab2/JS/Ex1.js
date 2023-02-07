const bootAddidas1 = {
    ID: 5,
    Size: 24,
    Color: "Red",
    Price: 123
};
const bootAddidas2 = {
    ID: 101,
    Size: 53,
    Color: "Yellow",
    Price: 900
};
const sandalNike1 = {
    ID: 142,
    Size: 24,
    Color: "Blue",
    Price: 189
};
const sneakersRunner1 = {
    ID: 11,
    Size: 23,
    Color: "Red",
    Price: 150
};
const Boots = {
    ID: 1,
    Boots: [bootAddidas1, bootAddidas2]
};
const Sandals = {
    ID: 2,
    Boots: [sandalNike1]
};
const Sneakers = {
    ID: 3,
    Boots: [sneakersRunner1]
};
const products = {
    Products: Boots.Boots.concat(Sandals.Boots, Sneakers.Boots)
};
console.log(`
    Exesize 1
`);
products.Products.forEach(element => {
    console.log(element.ID);
});
export default products;
