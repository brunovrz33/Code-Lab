var readline = require('readline-sync')
console.log("Lanchonete: ")
var pedido = readline.questionInt(" 10 - X-tudo\n 11 - X-calabresa\n 12 - dog com bacon\n 13 - X-burguer\n")

switch(pedido){
    case 10:
        console.log("Lanche escolhido: X-tudo")
        break
        case 11:
            console.log("Lanche escolhido: X-calabresa")
            break
            case 12:
                console.log("Lanche escolhido: dog com bacon")
                break
                case 13:
                    console.log("Lanche escolhido: X-burguer")
                    break
                    default:
                        console.log("Pedido incorretamente!")
}