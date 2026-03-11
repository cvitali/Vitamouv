
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

//flèches pour remonter en haut de page

const arrowsUp = document.querySelectorAll(".arrow-up-js")
arrowsUp.forEach(arrow => {
    arrow.addEventListener('click', () => {
        window.scrollTo({
            top: 0,
            behavior:"instant"
        })
    })
})

//flèches de renvoi vers la page Eventmouv

const arrowsBack = document.querySelectorAll(".arrow-back-js")
arrowsBack.forEach(arrow => {
    arrow.addEventListener('click', () => {
        window.location.assign("./")
    })
})



