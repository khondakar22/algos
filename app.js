function mergeSort(arr){
  if(arr.length === 1) {
    return arr;
  }
  
  const center = Math.floor(arr.length / 2);
  const left = arr.slice(0, center);
  const right = arr.slice(center);
  
  return merge(mergeSort(left), mergeSort(right));
}

function merge(left, right) {
 
  // Add sorted array into a result
  let result = [];
  // check the duplicate element and remove
  left = [...new Set(left.filter(x => !right.includes(x)))];
  right = [... new Set(right.filter(x => !left.includes(x)))];
  while(left.length && right.length) {
    if(left[0] < right[0]) {
      result.push(left.shift());
    } else {
      result.push(right.shift());
    }
  }
  return [...result, ...left, ...right];
}

/// Short Cut

let a = [85,75,6,4,3,-1,75,0,69,56,966,854,69,336,1558].sort((a,b) => a - b);
console.log(a);
let b = [8,89,5,7,96,15,6,65,421,655,15647,215,2165,21221,454].sort((a,b) => a - b);
console.log(b);
let c = [...new Set(a.concat(b).sort((a,b) => a - b))]; 
console.log(c);

//let c = [-30,22]
//let d = [0,97]
//console.log(merge(mergeSort(a), mergeSort(b)))
//console.log(merge(c, d))
