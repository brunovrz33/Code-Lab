const readline = require('readline-sync')

console.log('  Esse é um jogo da adivinhação!!\nVocê tem 5 chances para adivinhar meu número!')
var escolha = readline.questionInt('Voce deseja qual modo?\n 1-Facil\n 2-Medio\n 3-Dificil\n')
let max

if(escolha == 1){
    max = 10
}else if(escolha == 2){
    max = 50
}else{
    max = 100
}

let numerosecret = Math.floor(Math.random() *max) + 1
let tentativas = 0
let acertou = false

while(!acertou && tentativas < 5){
var palpite = readline.questionInt(`Me fala um numero de 1 a ${max}:`)

tentativas++

if (numerosecret == palpite){
    console.log(' Parabéns, você acertouu!!')
    acertou = true
}else if(palpite < numerosecret){
    console.log('Fale um número MAIOR')
}else{
    console.log('Fale um número MENOR')
}

}

if(!acertou){
    console.log('Suas chances esgotaram!')
}
