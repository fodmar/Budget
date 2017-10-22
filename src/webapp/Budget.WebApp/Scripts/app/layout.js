document.getElementById("expand-menu").addEventListener("click", function () {
    var menu = document.getElementById("menu");

    if (!menu.classList.contains("show")) {
        menu.classList.add("show");
    }
});

window.onclick = function (event) {
    if (!event.target.matches('#menu, #menu *, #expand-menu')) {
        var menu = document.getElementById("menu");

        if (menu.classList.contains("show")) {
            menu.classList.remove("show");
        }
    }
}