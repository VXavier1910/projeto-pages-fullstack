window.onload = function(e) {

btnRecuperarSenha = document.getElementById("btnRecuperarSenha");

campoEmail = document.getElementById("email");

campoEmail.focus();

btnRecuperarSenha.onclick = function(e) {

    e.preventDefault();

    let email = campoEmail.value;

    if(email == "") {
       var mensagem = "E-mail obrigatório."
       mensagemErro(mensagem);
    }
    else{
        verificarEmail(email)
    }
    

};


function verificarEmail(email) {
    var data = JSON.stringify({
        "email": email
      });
      
      var xhr = new XMLHttpRequest();
      xhr.withCredentials = true;
      
      xhr.addEventListener("readystatechange", function() {
        if(this.readyState === 4) {
          var result = JSON.parse(this.responseText);
          if(result.sucesso) {
            //aqui faltava o alert
            alert("E-mail enviado com sucesso!");
          }
          else{mensagemErro(result.mensagem);}
        }
      });
      
      xhr.open("POST", "https://localhost:7243/api/usuario/esqueceuSenha");
      xhr.setRequestHeader("Content-Type", "application/json");
      
      xhr.send(data);
}

function mensagemErro(mensagem) {

    let spnErro = document.getElementById("spnErro");
    
    spnErro.innerText = mensagem;
    
    spnErro.style.display = "block"
    
    setTimeout(function() {
        spnErro.style.display = "none"
    }, 5000);
    
    }
}