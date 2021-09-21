class Node {
  constructor(data) {
    this.data = data;
    this.children = [];
  }

  // Add Method
  add(value) {
    this.children.push(new Node(value));
  }
  
  // Remove Method
  remove(arrData) {
    this.children = this.children.filter(node => node.data !== arrData);
  }
}

class Tree {
  constructor() {
    this.root = null;
  }
  traverseBF(fn) {
    let result = [];
    let arr = [this.root]; 
    while(arr.length) {
      const node = arr.shift();
     // for(let child of node.children) {
       // arr.push(child);
      //}
      arr.push(...node.children);
      fn(node);
    }
   
  }
  
   traverseDF(fn) {
    let result = [];
    let arr = [this.root]; 
    while(arr.length) {
      const node = arr.shift();
     // for(let child of node.children) {
       // arr.push(child);
      //}
      arr.unshift(...node.children);
      fn(node);
    }
  
  }
}

const treeNode = new Node(8);
treeNode.add(9);
treeNode.add(10);
treeNode.add(11);
const treeNode1 = new Node(12);

treeNode1.add(13);
treeNode1.add(14);
treeNode1.add(15);

const tree = new Tree();
tree.root = treeNode;

const tree1 = new Tree();
tree1.root = treeNode1;

tree1.traverseBF((node) => {
  console.log(node.data)
} );
tree.traverseDF((node) => {
  console.log(node.data)
} );
