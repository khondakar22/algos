const anExampleVariable = "Hello World"
console.log(anExampleVariable)

// To learn more about the language, click above in "Examples" or "What's New".
// Otherwise, get started by removing these comments and the world is your playground.


type Icon = 'a' | 'b' | 'c' | 'd'; 
type Size = 20 | 40 | 70 | 80; 

type SizeIcon = `${Icon} - ${Size}`; 


let myIcon: SizeIcon = 'a - 20'



// Duck Typing or Structural Typing
// Type Checking focuses on the shape that values have. 

// If two objects have the same shape, they are considered to be of the same type.

interface Point {
    x: number;
    y: number;
}

function logPoint(p: Point) {
    console.log(`${p.x}, ${p.y}`);
}

// logs "12, 26"

const point = {x:12, y:26};
logPoint(point);

// Point variable is never delecared a type of Point, but typescript compare that it is the same shape so it passes. 

const point3 = { x: 12, y: 26, z: 89 };
logPoint(point3); // logs "12, 26"
 
const rect = { x: 33, y: 3, width: 30, height: 80 };
logPoint(rect); // logs "33, 3"
 
const color = { hex: "#187ABF" };
logPoint(color);
