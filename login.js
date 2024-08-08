window.onload = function(e) {

    let btnEntrar = document.getElementById("btnEntrar");

    let caixaEmail = document.getElementById("email");

    let caixaSenha = document.getElementById("senha");

    caixaEmail.focus();

    btnEntrar.onclick = function(e) {

        e.preventDefault();
    
        let email = caixaEmail.value;
        let senha = caixaSenha.value;

        if(email === "") {
        exibirErro("Campo E-mail Obrigatório!")
        }

        else if(senha === "") {
        exibirErro("Campo Senha Obrigatório!")
        }

        else{
            realizarLogin(email, senha);
        }
    };
    function exibirErro(mensagem) {
      
        let spnErro = document.getElementById("spnErro");

        spnErro.innerText = mensagem;

        spnErro.style.display = "block";

        setTimeout(function () {
            spnErro.style.display = "none"
        }, 5000);

    }

    function realizarLogin(email, senha) {
        var data = JSON.stringify({
            "email": email,
            "senha": senha
          });
          
          var xhr = new XMLHttpRequest();
          xhr.withCredentials = true;
          
          xhr.addEventListener("readystatechange", function() {
            if(this.readyState === 4) {
             var loginResult = JSON.parse(this.responseText);
             if(loginResult.sucesso) {
                
                localStorage.setItem("usuarioGuid", loginResult.usuarioGuid);
                window.location.href = "home.html";

             }
             else{
                exibirErro(loginResult.mensagem);
             }
            }
          });
          
          xhr.open("POST", "https://localhost:7243/api/usuario/login");
          xhr.setRequestHeader("Content-Type", "application/json");
          
          xhr.send(data);
    }
}