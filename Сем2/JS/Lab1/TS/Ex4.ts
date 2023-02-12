// Есть два отсортированных массива nums1 и nums2 размера m и n соответственно, 
// вернуть медиану двух отсортированных массивов. Медиана число (два числа) находящееся в середине массива.

let nums1 = [1, 3];
let nums2 = [2];

let nums3 = [1, 2];
let nums4 = [3, 4];

function findMedianSortedArrays(nums1: number[], nums2: number[]) : number {
    //let nums = nums1.concat(nums2).sort((a, b) => a - b);
    let nums = [...nums1, ...nums2].sort((a, b) => a - b);
    let len = nums.length;
    return len % 2 === 0 ? 
           (nums[len / 2] + nums[len / 2 - 1]) / 2 : 
           nums[Math.floor(len / 2)];
}

console.log(
    `
    Exesize 4
    [1, 3] and [2] = ${findMedianSortedArrays(nums1, nums2)} 
    [1, 2] and [3, 4] = ${findMedianSortedArrays(nums3, nums4)}
    `);