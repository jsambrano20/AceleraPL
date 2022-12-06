const form = document.querySelector("#formulario");

form.addEventListener("submit", function(e){
    e.preventDefault();

    const inputPeso = e.target.querySelector("#peso");
    const inputAltura = e.target.querySelector("#altura");

    const peso = Number(inputPeso.value);
    const altura = Number(inputAltura.value);

    if(!peso){
        setMensagem('Informar o peso', false);
        return;
    }

    if(!altura){
        setMensagem('Informar a altura', false);
        return;
    }

    //Calcular IMC
    const imc = calcularIMC(peso, altura);
    const indiceimc = resultindiceIMC(imc);
    
    const msg = `Seu IMC é ${imc} - ${indiceimc}`;
    
    setMensagem(msg, true);
    
});

function calcularIMC(peso, altura){
    let imc = 0;
    const calculo = peso/ Math.pow(altura, 2);
    imc = calculo;

    return imc.toFixed(2);
    
}

function resultindiceIMC(imc){
    
    const indice = ['Abaixo do peso','Peso Normal','Sobrepeso','Obesidade grau 1',
    'Obesidade grau 2','Obesidade grau 3']

    if(imc >= 39.9) return indice[5]
    if(imc >= 34.9) return indice[4]
    if(imc >= 29.9) return indice[3]
    if(imc >= 24.9) return indice[2]
    if(imc >= 18.5) return indice[1]
    if(imc < 18.5) return indice[0]
}

function setMensagem(msg, isValid) {
    const resultado = document.querySelector("#resultado");
    resultado.innerHTML = '';
    const p = criarParagrafo();

    if(isValid)
    {
        p.classList.add('is-valid');   
    }
    else{
        p.classList.add('is-invalid');
    }
    p.innerHTML = msg;
    resultado.appendChild(p);

};

function criarParagrafo(){
    const p = document.createElement("p");
    return p;
};