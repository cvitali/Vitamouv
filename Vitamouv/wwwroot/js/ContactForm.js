
//ouverture du formulaire de contact au clic sur le bouton "prendre contact"
document.addEventListener("DOMContentLoaded", () => {
    const contactButtons = document.querySelectorAll('.js-contactBtn')
    const dialog = document.getElementById('js-modalContactForm')
        contactButtons.forEach(button => {
            button.addEventListener("click", () => {                
                dialog.showModal()
            })
        })    
})

//on intercepte le formulaire lors du submit puis on l'envoi au controlleur avec fetch
const dialog = document.getElementById('js-modalContactForm')
document.getElementById("contactForm").addEventListener("submit", async(e) => {
    e.preventDefault()

    const form = e.target
    const data = new FormData(form)

    const response = await fetch(form.action,{
        method: "POST",
        body: data
    })

    if (response.ok) {
        const dialog = document.getElementById('js-modalContactForm')
        dialog.close()
        form.reset()
        setTimeout(() => {
            window.alert("Votre message a bien été envoyé.")
        }, 500)
    } else {
        window.alert("Votre message n'a pas pu être envoyé.")
        const dialog = document.getElementById('js-modalContactForm')
        dialog.showModal()
    }
})
