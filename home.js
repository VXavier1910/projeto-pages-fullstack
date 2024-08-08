window.onload = function(e) {

var usuarioGuid = localStorage.getItem("usuarioGuid");

if(usuarioGuid == null) {
    window.location.href = "login.html";
}

else{
    obterUsuario(usuarioGuid);
}

var linkSair = document.getElementById("linkSair")

linkSair.onclick = function(e) {
    localStorage.removeItem(usuarioGuid)

    window.location.href = "login.html"
}

var icon = document.querySelector(".icon")

icon.onclick = function(e) {

var menu = document.querySelector(".topNav")

if(menu.className == "topNav") {
    menu.className += " open"
}
else{
    menu.className = "topNav" 
}

}

function obterUsuario(usuarioGuid) {

    var xhr = new XMLHttpRequest();
xhr.withCredentials = true;

xhr.addEventListener("readystatechange", function() {
  if(this.readyState === 4) {

    var result = JSON.parse(this.responseText);

    if(result.sucesso) {
        // SUCESSO!!!
    var spnMensagem = document.getElementById("spnMensagem")
        spnMensagem.innerText = "Bem-Vindo ao sistema " + result.nome;

    }
    else{
        window.location.href = "login.html";
    }
  }
});

xhr.open("GET", "https://localhost:7243/api/usuario/obterUsuario?usuarioGuid=" + usuarioGuid);

xhr.send();

}

}