
// find the width of tree
function levelWidth() {
  let counter = [0]; 
  let arr = [root, 's'];
  
  while(arr.length > 1){
    const node = arr.shift();
    if(node === 's') {
      counters.push(0); 
      arr.push('s');
    } else {
      arr.push(...node.children);
      counter[counter.length - 1]++;
    }
  }
  
  return counter;
  
}
