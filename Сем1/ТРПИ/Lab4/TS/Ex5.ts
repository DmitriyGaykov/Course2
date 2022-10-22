function makeCounter() : () => number
{
    let currentCount = 1;

    return function() : number
    {
        return currentCount++;
    }
}

let currentCount = 1;

function makeCounter1() : () => number
{
    return function() : number
    {
        return currentCount++;
    };
}

alert(`
Name of first func is ${makeCounter.name}
Name of second func is ${makeCounter1.name}
`);