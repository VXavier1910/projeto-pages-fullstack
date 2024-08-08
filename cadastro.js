window.onload = function (e) {
  let btnCadastar = document.getElementById("btnCadastrar");

  let caixaNome = document.getElementById("name");

  let caixaSobrenome = document.getElementById("sobrenome");

  let caixaTelefone = document.getElementById("telefone");

  let caixaEmail = document.getElementById("email");

  let caixaGenero = document.getElementById("genero");

  let caixaSenha = document.getElementById("password");

  caixaNome.focus();

  btnCadastar.onclick = function (e) {
    e.preventDefault();

    let nome = caixaNome.value;
    let sobrenome = caixaSobrenome.value;
    let telefone = caixaTelefone.value;
    let email = caixaEmail.value;
    let genero = caixaGenero.value;
    let senha = caixaSenha.value;

    if (nome == "") {
      mensagemDeErro("Informe seu nome.");
    } else if (sobrenome == "") {
      mensagemDeErro("Informe seu sobrenome.");
    } else if (telefone == "") {
      mensagemDeErro("Informe seu telefone.");
    } else if (email == "") {
      mensagemDeErro("Informe seu E-mail.");
    } else if (senha == "") {
      mensagemDeErro("Defina uma senha.");
    } else {
      realizarCadastro(nome, sobrenome, telefone, email, genero, senha);
    }
  };

  function mensagemDeErro(mensagem) {
    let spnErro = document.getElementById("spnErro");

    spnErro.innerText = mensagem;

    spnErro.style.display = "block";

    setTimeout(function () {
      spnErro.style.display = "none";
    }, 5000);
  }

  function realizarCadastro(nome, sobrenome, telefone, email, genero, senha) {
    var data = JSON.stringify({
      nome: nome,
      sobrenome: sobrenome,
      email: email,
      telefone: telefone,
      senha: senha,
      genero: genero,
    });

    var xhr = new XMLHttpRequest();
    xhr.withCredentials = true;

    xhr.addEventListener("readystatechange", function () {
      if (this.readyState === 4) {
        var cadastroResult = JSON.parse(this.responseText);
        if (cadastroResult.sucesso) {

          localStorage.setItem("usuarioGuid", cadastroResult.usuarioGuid);
          window.location.href = "home.html";

        } 
        else {
          mensagemDeErro(cadastroResult.mensagem);
        }
      }
    });

    xhr.open("POST", "https://localhost:7243/api/usuario/cadastro");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.send(data);
  }
};
