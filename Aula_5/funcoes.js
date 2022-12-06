//function hoisting


const inicio = function() {
    console.log("Olá");
}

function exe(funcao){
    console.log("AIN");
    funcao();
}

exe(inicio);


// arrow functions

const funcaoArrow= () =>{
    console.log("arrow function");

}

funcaoArrow();