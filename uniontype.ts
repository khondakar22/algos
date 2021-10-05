const anExampleVariable = "Hello World"
console.log(anExampleVariable)

// To learn more about the language, click above in "Examples" or "What's New".
// Otherwise, get started by removing these comments and the world is your playground.


type Icon = 'a' | 'b' | 'c' | 'd'; 
type Size = 20 | 40 | 70 | 80; 

type SizeIcon = `${Icon} - ${Size}`; 


let myIcon: SizeIcon = 'a - 20'
