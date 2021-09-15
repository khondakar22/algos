function selectionSort(arr = [29,9,0,1,76]) {
  for(let i = 0; i < arr.length; i++) {
    let indexOfMin = i; // 0
    for(let j = i+1; j < arr.length; j++) {
      if( arr[j] < arr[indexOfMin]) {
        indexOfMin  = j; // 1
      }
    }
    if(indexOfMin !== i) {
      let lesser = arr[indexOfMin]; // 9
      arr[indexOfMin] = arr[i];
      arr[i] = lesser;
    }
  }
  return arr;
}

console.log(selectionSort());
