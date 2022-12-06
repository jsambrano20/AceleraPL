// let => local (Private)
// var => Global (Public)
// const => Valor constante ()

// function nomeFuncao(nome, sobrenome) {
//     let mensagem = "Nome" + nome + " Sobrenome:" + sobrenome;
//     return mensagem;
// }

// console.log(nomeFuncao("joao","Sambrano"));


// const idadeMinima = 18;

// let idadeAtual = 16 ; 

// function verificarIdade(){
//     if(idadeAtual < idadeMinima)
//     {
//         console.log("menor de idade");
//     }
//     else{
//         console.log("maior de idade");

//     }
// }

// verificarIdade()
console.log("----------Exercicio 1 -----------")
let num = 55;

console.log("Raiz: " + Math.sqrt(num))
console.log("Inteiro: " + Number.isInteger(num))
console.log("Nan: " + Number.isNaN(num))


console.log("----------Exercicio 2 -----------")

let num1=125.4584454;
let num2 = 29.335;

console.log("Baixo:" + Math.floor(num1) )
console.log("Baixo:" + Math.floor(num2) )
console.log("Cima:" + Math.ceil(num1))
console.log("Cima:" + Math.ceil(num2))
console.log("Decimais:"  + num1.toFixed(2))
console.log("Decimais:" + num2 .toFixed(2))
console.log("O número encontrado é:" + num1.toFixed(4))
console.log("O número encontrado é:" + num2.toFixed(4))


console.log("----------Exercicio 3 -----------");

let random = Math.floor(Math.random() * (10 - 1) + 1);

console.log("NUMERO RANDOM: " + random)

