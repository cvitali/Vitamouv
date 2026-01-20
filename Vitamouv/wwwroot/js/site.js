//liens du logo interactif renvoyant vers les différentes disciplines

let links = document.querySelectorAll(".link-js")

links.forEach((link) => {
    link.addEventListener("click", () => {
        if (link.classList.contains("rect__mini"))
        {
            location.href = "../Activities/Minimouv"
        }
        if (link.classList.contains("rect__school")) {
            location.href = "../Activities/Schoolmouv"
        }
        if (link.classList.contains("rect__slow")) {
            location.href = "../Activities/Slowmouv"
        }
        if (link.classList.contains("rect__danse")) {
            location.href = "../Activities/Dansemouv"
        }
        if (link.classList.contains("rect__event")) {
            location.href = "../Activities/Eventmouv"
        }
    })
})


//page Eventmouv: modification du texte sous les photos au survol de la souris

