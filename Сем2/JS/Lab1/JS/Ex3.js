const reverseArray = (arr, k) => {
    if (k < 0 || k > arr.length) {
        return arr;
    }
    let newArr = [];
    for (let i = arr.length - k; i < arr.length; i++) {
        newArr.push(arr[i]);
    }
    for (let i = 0; i < arr.length - k; i++) {
        newArr.push(arr[i]);
    }
    return newArr;
};
let resultRev = reverseArray([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 4).join(' ');
console.log(`
    Exesize 3
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] on 4 => ${resultRev}
    `);
