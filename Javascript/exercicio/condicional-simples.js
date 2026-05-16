var readline = require('readline-sync')
var numero = readline.questionInt('digite um numero:')

if (numero % 2==0)
    console.log(`o número ${numero}, é par`)
else
    console.log(`o número ${numero}, é impar.`) 