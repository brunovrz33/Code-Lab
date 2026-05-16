var readline = require('readline-sync')
var senhaCorreta = 1307

for (let c = 1; c <= 3; c++) {
    var senha = readline.questionInt("insira a senha: ")

    if (senha == senhaCorreta) {
        console.log('Usuario autenticado!')
        break
    } else {
        let tentativasRestantes = 3 - c
        if (tentativasRestantes > 0) {
            console.log(`Senha incorreta! ${tentativasRestantes} tentativa(s) restante(s).`)
        } else {
            console.log("Usuário bloqueado! Entre em contato com o suporte!")
        }
    }
}