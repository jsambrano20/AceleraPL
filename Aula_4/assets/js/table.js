const form = document.querySelector("#formulario");
const tabela = document.querySelector("#table");

form.addEventListener("submit", function(e){
    e.preventDefault();

    const inputNome = e.target.querySelector("#nome");
    const inputEmail = e.target.querySelector("#email");
    const inputTelefone = e.target.querySelector("#telefone");

    const nome = inputNome.value;
    const email = inputEmail.value;
    const telefone = inputTelefone.value;

    const numeroLinhas = tabela.rows.length;
    const novalinha = tabela.insertRow(numeroLinhas);

    const nomecel = novalinha.insertCell(0);
    const emailcel = novalinha.insertCell(1);   
    const telefonecel = novalinha.insertCell(2); 

    nomecel.innerHTML = nome;
    emailcel.innerHTML = email;
    telefonecel.innerHTML = telefone;

    
});
