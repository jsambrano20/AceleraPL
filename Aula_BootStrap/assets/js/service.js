//chamada para API correios
//API que trás CNPJ --> dados da empresa ***

$(document).ready(function() {
    $("#CEP").blur(function() {
        let cep = $(this).val();

        let url = `https://viacep.com.br/ws/${cep}/json/`

        let resposta = {};

        fetch(url)
        .then((res) => {
            let x = res.json();
            return x;
        })
        .then((valor) =>{
            resposta = valor;
            if(!("erro" in resposta))
            {
                $("#rua").val(resposta.logradouro);  //como é entrada, utilizamos o '.val'
                $("#complemento").val(resposta.complemento);
                $("#bairro").val(resposta.bairro);
                $("#cidade").val(resposta.localidade);
                $("#estado").val(resposta.uf);
                $('#msgCEP').html('<i class="fas fa-check"></i>'); //como não é entrada, utilizamos o '.html'
            }
            else{ 
                $('#msgCEP').html('<i class="fas fa-ban"></i>');
                limparCamposCEP();
            }
        })

    });
});

function serviceReceita(cnpj){
    let url = `https://publica.cnpj.ws/cnpj/${cnpj}`;
    let resposta = {};

    fetch(url)
    .then((res) => {
        let x = res.json();
        return x;
    })
    .then((valor) =>{
        resposta = valor;
        $('#razaoSocial').val(resposta.razao_social);  //como é entrada, utilizamos o '.val'
    })

};
