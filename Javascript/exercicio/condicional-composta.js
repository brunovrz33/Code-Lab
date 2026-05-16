var readline = require('readline-sync')

var aluno = readline.question('qual seu nome?')
var nota1 = readline.questionFloat ("qual foi sua primeira nota?")
var nota2 = readline.questionFloat ("e a segunda nota?")
var media = (nota1 + nota2) / 2

console.log(`Aluno: ${aluno}`)
console.log(`Media: ${media}`)

if(media >= 6)
      console.log(`situação: Aprovado!`)

else if (media >= 4 && media < 6)
           console.log(`Situação: Recuperação!`)

else
          console.log(`situação: Reprovado!`)