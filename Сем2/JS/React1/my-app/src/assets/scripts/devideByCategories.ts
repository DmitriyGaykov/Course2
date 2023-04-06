import ICategory from "../models/ICategory";
import IProduct from "../models/IProduct";

const devideByCategories = (products : IProduct[]) : ICategory[] | null => {
    if(
        products === null || 
        products === undefined) 
    {
        console.warn(`Error | devideByCategories() | products is null`);
        return null;
    } else if (typeof products[Symbol.iterator] !== 'function') {
        console.warn(`Error | devideByCategories() | products is not iterable`);
        return null;
    }

    const categories : ICategory[] = [];
    const setCats = new Set<string>();

    let category : ICategory;
    
    for(let el of products) {
        setCats.add(el?.category as string);
    }


    setCats.forEach(el => {
        category = { 
            category_name: el
        };

        category.products = products.filter(el => el?.category === category?.category_name);
        
        categories.push(category);
    });

    return categories;
}

export default devideByCategories;