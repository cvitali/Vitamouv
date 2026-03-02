//liens du logo interactif renvoyant vers les différentes disciplines

const eventLinks = document.querySelectorAll(".link-js")

eventLinks.forEach((link) => {
    link.addEventListener("click", () => {
        if (link.classList.contains("rect__mini"))
        {
            location.href = "../Prestations/Mini'MOUV"
        }
        if (link.classList.contains("rect__school")) {
            location.href = "../Prestations/School'MOUV"
        }
        if (link.classList.contains("rect__slow")) {
            location.href = "../Prestations/Slow'MOUV"
        }
        if (link.classList.contains("rect__danse")) {
            location.href = "../Prestations/Danse'MOUV"
        }
        if (link.classList.contains("rect__event")) {
            location.href = "../Prestations/Event'MOUV"
        }
    })
})


//page Eventmouv: affichage du texte caché sous les photos au survol de la souris

const events = document.querySelectorAll(".event-js")

events.forEach((event) => {
    let textToShow = event.querySelector(".hiddenText-js")
    event.addEventListener("mouseover", () => {

        textToShow.classList.remove("hidden-js")
    })
    event.addEventListener("mouseout", () => {

        textToShow.classList.add("hidden-js")
    })
})
