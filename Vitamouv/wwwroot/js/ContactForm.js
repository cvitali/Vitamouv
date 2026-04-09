
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

    //on s'assure que le formulaire est correctement rempli avant de l'envoyé
    //évite à l'api fetch de contourner les dataAnnotations
    if (!$(form).valid()) {
        return
    }

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
        const result = await response.json();
        if (result.errors) {
            // à remplacer par des logs
            console.log(result.errors.Email);
        }

        return;
    }
})

//Fermeture du formulaire de contact

const windowToClose = document.getElementById('js-modalContactForm')
const closeBtn = document.getElementById("js-closeModalContactForm")

if (dialog) {
    closeBtn.addEventListener("click", () => {
        windowToClose.close()
    })
}