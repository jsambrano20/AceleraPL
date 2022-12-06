//criar mascaras para inputs

//CEP
//Valor monetario
//Telefone (dinamico)
//CPF e CNPJ (dinamico)

jQuery(document).ready(function ($) {
  $(".cep").mask("00000-000");
  $('.fone').mask('(00) 0000-0000');
  $('.celular').mask('(00) 00000-0000');
  $('.cpf').mask('000.000.000-00', {reverse: true});
  $('.cnpj').mask('00.000.000/0000-00', {reverse: true});
});
