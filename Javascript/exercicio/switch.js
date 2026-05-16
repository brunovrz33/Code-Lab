var readline = require('readline-sync')
var sexo = readline.question("informe o seu sexo:\n[M] Masculino \n[F] Feminino\n")

var sexoM = sexo.toUpperCase()

switch(sexoM){
    case "F":
       console.log("Sexo Feminino")
       break
    case "M":
       console.log("Sexo Masculino")
    break
    default:
       console.log("Sexo inválido")
}