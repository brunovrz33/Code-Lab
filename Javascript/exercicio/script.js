var readline = require('readline-sync')

var nome = readline.question('Qual o seu nome?')
var numero = readline.questionInt('me fala um numero.')
var numero2 = readline.questionInt('me fale outro numero.')

var soma = numero + numero2

console.log (`${nome}, a soma dos dois números é: ${soma} `)