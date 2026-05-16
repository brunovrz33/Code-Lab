var c = 1
var soma = 0
var readline = require('readline-sync')
var nome = readline.question('Nome:')

do{
        var nota = readline.questionFloat(`Nota ${c}: `)
    soma+=nota
    while(c < 0 || nota > 10){
        console.log("Por favor, digite um numero de 0 a 10:")
    }
    c++
}while(c <= 4)
var media = soma / 4
         console.log(`Aluno: ${nome}`)
         console.log(`Media: ${media.toFixed(1)}`)