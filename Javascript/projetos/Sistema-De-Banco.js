const readline = require('readline-sync')

let saldo = 1000
let opcao = 0

while(opcao != 4){

    console.log('\n=== CAIXA ELETRÔNICO ===')
    console.log('1 - Ver saldo')
    console.log('2 - Depositar')
    console.log('3 - Sacar')
    console.log('4 - Sair')

    opcao = readline.questionInt('O que você deseja fazer? ')

    if(opcao == 1){
        console.log(`Seu saldo é: ${saldo}`)
    }

    else if(opcao == 2){
        let valor = readline.questionFloat('Quanto você deseja depositar? ')

        if(valor <= 0){
            console.log('Valor inválido!')
        } else {
            saldo += valor
            console.log('Depósito realizado com sucesso!')
        }
    }

    else if(opcao == 3){
        let valor = readline.questionFloat('Quanto você deseja sacar? ')

        if(valor > saldo){
            console.log('Saldo insuficiente!')
        } else {
            saldo -= valor
            console.log('Saque realizado com sucesso!')
        }
    }

    else if(opcao == 4){
        console.log('Encerrado!')
    }

    else {
        console.log('Opção inválida!')
    }
}