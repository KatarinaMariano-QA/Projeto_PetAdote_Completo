$(document).ready(function() {

  var titlePage = document.title;

  if(titlePage == "PAGINA INICIAL | Projeto PetAdote"){
    $(".menuPaginaInicial").addClass("colorMenu");
  }
  else if(titlePage == "EDITAR DADOS | Projeto PetAdote"){
    $(".menuEditarDados").addClass("colorMenu");
  }
  else if(titlePage == "INCLUIR PET | Projeto PetAdote"){
    $(".menuIncluirPet").addClass("colorMenu");
  }
  else if(titlePage == "MEUS PETS | Projeto PetAdote"){
      $(".menuMeusPets").addClass("colorMenu");
  }
  else{
    $(".menuSair").addClass("colorMenu");
    }
  
  
  
  
});