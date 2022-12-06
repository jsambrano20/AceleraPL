//validação CNPJ 
//validação de CPF

function limparCamposCEP(){
    $("#rua").val(""); 
    $("#complemento").val("");
    $("#bairro").val("");
    $("#cidade").val("");
    $("#estado").val("");
}

$("#CPF").blur(function () {
    var cpf = $("#CPF")
      .val()
      .replace(/[^0-9]/g, "");
  
    if (cpf.length === 11) {
      //Calcula o primeiro dígito de verificação.
      var v = [];
      v[0] = 1 * cpf[0] + 2 * cpf[1] + 3 * cpf[2];
      v[0] += 4 * cpf[3] + 5 * cpf[4] + 6 * cpf[5];
      v[0] += 7 * cpf[6] + 8 * cpf[7] + 9 * cpf[8];
      v[0] = v[0] % 11;
      v[0] = v[0] % 10;
  
      //Calcula o segundo dígito de verificação.
      v[1] = 1 * cpf[1] + 2 * cpf[2] + 3 * cpf[3];
      v[1] += 4 * cpf[4] + 5 * cpf[5] + 6 * cpf[6];
      v[1] += 7 * cpf[7] + 8 * cpf[8] + 9 * v[0];
      v[1] = v[1] % 11;
      v[1] = v[1] % 10;
  
      if (v[0] != cpf[9] || v[1] != cpf[10]) {
        $("#msgCPF").html('<i class="fas fa-ban"></i>');
        return;
      }
      $("#msgCPF").html('<i class="fas fa-check"></i>');
    } else {
      $("#msgCPF").html('<i class="fas fa-ban"></i>');
    }
  });


$("#CNPJ").blur(function () {
    var cnpj = $("#CNPJ")
      .val()
      .replace(/[^0-9]/g, "");
  
    let bool = validaCNPJ(cnpj);
  
    if (!bool) 
    {
      $("#msgCNPJ").html('<i class="fas fa-ban"></i>');
    }
    $("#msgCNPJ").html('<i class="fas fa-check"></i>');
    serviceReceita(cnpj);
});

function validaCNPJ(cnpj) {
    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
    digitos_iguais = 1;
  
    if (cnpj.length < 14 && cnpj.length < 15) {
      return false;
    }
    for (i = 0; i < cnpj.length - 1; i++) {
      if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
        digitos_iguais = 0;
        break;
      }
    }
  
    if (!digitos_iguais) {
      tamanho = cnpj.length - 2;
      numeros = cnpj.substring(0, tamanho);
      digitos = cnpj.substring(tamanho);
      soma = 0;
      pos = tamanho - 7;
  
      for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) {
          pos = 9;
        }
      }
      resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
      if (resultado != digitos.charAt(0)) {
        return false;
      }
      tamanho = tamanho + 1;
      numeros = cnpj.substring(0, tamanho);
      soma = 0;
      pos = tamanho - 7;
      for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) {
          pos = 9;
        }
      }
      resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
      if (resultado != digitos.charAt(1)) {
        return false;
      }
      return true;
    } else {
      return false;
    }
  }