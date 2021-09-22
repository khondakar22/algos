// Binary Search tree

// All needs at least o or 2 children
// Left.Value < parent.value
// Right.Value > Parent.value



class Node {
  
  constructor(data) {
    this.data = data;
    this.right = null;
    this.left = null;
  }
  
  insert(data){
    if(data < this.data && this.left) {
      this.left.insert(data);
    } else if(data < this.data) {
      this.left = new Node(data);
    } else if( data > this.data  && this.right) {
      this.right.insert(data);
    } else if(data > this.data) {
      this.right = new Node(data);
    }
  }
  
  contains(data) {
    if(this.data === data) {
      return this;
    }
    
    if(this.data < data && this.right) {
      return this.right.contains(data);
    } else if(this.data > data && this.left) {
      return this.left.contains(data);
    }
    
    return null;
  }
  
}

let bst  = new Node(30);
bst.insert(-5);
bst.insert(5);
bst.insert(22);
bst.insert(-1);
bst.insert(42);
bst.insert(11);
bst.insert(15);
bst.insert(41);
bst.insert(55);
bst.insert(60);

console.log(bst.contains(42));
console.log(bst.left);
console.log(bst.left.left);
console.log(bst.left.right);
console.log(bst.left.right.left);
console.log(bst.left.right.right);
console.log(bst.left.right.right.left);
console.log(bst.left.right.right.right);

console.log(bst.right);
console.log(bst.right.right);
console.log(bst.right.left);
console.log(bst.right.right.right);
console.log(bst.right.left.right);
