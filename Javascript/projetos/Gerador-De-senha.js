const readline = require('readline-sync')

function getLetra() {
  let letra = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'
  return letra[Math.floor(Math.random() * letra.length)]
}

function getNumero() {
  let numero = '0123456789'
  return numero[Math.floor(Math.random() * numero.length)]
}

function getSimbolos() {
  let simbolo = '!@#$%&*'
  return simbolo[Math.floor(Math.random() * simbolo.length)]
}

function gerarSenha(tamanho, usarLetra, usarNumero, usarSimbolo) {
  let senha = ''

  for (let i = 0; i < tamanho; i++) {
    let tipo = Math.floor(Math.random() * 3)

    if (tipo === 0 && usarLetra) {
      senha += getLetra()
    } else if (tipo === 1 && usarNumero) {
      senha += getNumero()
    } else if (tipo === 2 && usarSimbolo) {
      senha += getSimbolos()
    } else {
      i--
    }
  }

  return senha
}

let tamanho = readline.questionInt('Tamanho da senha: ')

let usarLetra = readline.question('Usar letras? (s/n): ') === 's'
let usarNumero = readline.question('Usar numeros? (s/n): ') === 's'
let usarSimbolo = readline.question('Usar simbolos? (s/n): ') === 's'

let senha = gerarSenha(tamanho, usarLetra, usarNumero, usarSimbolo)

console.log(`🔐 Senha gerada: ${senha}`)