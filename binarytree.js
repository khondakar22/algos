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

const treeNode = new Node(8);
treeNode.add(10)
console.log(treeNode.data); // 100
