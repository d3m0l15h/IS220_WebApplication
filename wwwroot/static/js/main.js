// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)

// -------------- VARIBLES --------------
const menuIcon = $('.menu-icon') // $ để select element đó (ở trong jquery)
const navBar = $('.menu')
const bellIcon = $('.noti') // for notification
// for authecation form
const userIcon = $('.user-icon')
const loginForm = $('.login-form-container')
const registerForm = $('.register-form-container')

// --------------- Custom Scroll Bar --------------
window.onscroll = () => {
    mufunction()
}

const mufunction = () => {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop
    var height =
        document.documentElement.scrollHeight -
        document.documentElement.clientHeight
    var scrolled = (winScroll / height) * 100
    document.getElementById('scroll-bar').style.width = scrolled + '%'
}

// -------------- MENU ICON --------------
menuIcon.onclick = () => {
    navBar.classList.toggle('active')
    menuIcon.classList.toggle('move')
    bellIcon.classList.remove('active')
}

// -------------- NOTIFICATION --------------
$('#bell-icon').onclick = () => {
    bellIcon.classList.toggle('active')
}

// -------------- AUTHENTICATION FORM --------------
const authContainer = $('#container');
const registerBtn = $('#register');
const loginBtn = $('#login');

registerBtn.onclick = () => {
    authContainer.classList.add("active");
}

loginBtn.onclick = () => {
    authContainer.classList.remove("active");
};

$('.close-form').onclick = () => {
    authContainer.classList.remove('isDisplay')
}

$('.user-icon').onclick = () => {
    authContainer.classList.add('isDisplay')
}

// -------------- SWIPER (library for display game in trending section) --------------
const swiper = new Swiper('.trending_content', {
    slidesPerView: 1,
    spaceBetween: 10,
    pagination: {
        el: '.swiper-pagination',
        clickable: true
    },
    autoplay: {
        delay: 3000, // 3s
        disableOnInteraction: false
    },
    breakpoints: {
        640: {
            slidesPerView: 2,
            spaceBetween: 10
        },
        768: {
            slidesPerView: 3,
            spaceBetween: 15
        },
        1024: {
            slidesPerView: 5,
            spaceBetween: 20
        }
    }
})

// -------------- PAGINATION in NEW GAMES SECTION --------------
const startBtn = $('#startBtn')
const endBtn = $('#endBtn')
const prevNext = $$('.prevNext')
const numbers = $$('.link')

// page đầu là 0, khi hiển thị UI là 1
let currentStep = 0

// Để update
const updateBtn = () => {
    // khi ở page cuối
    if (currentStep === 4) {
        endBtn.disabled = true
        prevNext[1].disabled = true

        // khi ở page đầu
    } else if (currentStep === 0) {
        startBtn.disabled = true
        prevNext[0].disabled = true

        // không thì 4 nút di chuyển đều 
    } else {
        endBtn.disabled = false
        prevNext[1].disabled = false
        startBtn.disabled = false
        prevNext[0].disabled = false
    }
}

// Add event listeners cho mấy cái số ở idx
numbers.forEach((number, numIndex) => {
    number.addEventListener('click', e => {
        e.preventDefault()

        // Set the current step to the clicked number link
        currentStep = numIndex
        // Remove the "active" class from the previously active number link
        $('.active').classList.remove('active')
        // Add the "active" class to the clicked number link
        number.classList.add('active')

        updateBtn() // Update the button states
    })
})

// Add event listeners cho nút chuyển tới, chuyển lui
prevNext.forEach(button => {
    button.addEventListener('click', e => {
        // Increment or decrement the current step based on the button clicked
        currentStep += e.target.id === 'next' ? 1 : -1

        numbers.forEach((number, numIndex) => {
            // Toggle the "active" class on the number links based on the current step
            number.classList.toggle('active', numIndex === currentStep)

            updateBtn() // Update the button states
        })
    })
})

// Add event listener cho nút chuyển tới đầu
startBtn.addEventListener('click', () => {
    // Remove the "active" class from the previously active number link
    $('.active').classList.remove('active')
    // Add the "active" class to the first number link
    numbers[0].classList.add('active')
    currentStep = 0

    updateBtn() // Update the button states

    endBtn.disabled = false
    prevNext[1].disabled = false
})

// Add event listener cho cái nút chuyển tới cuối
endBtn.addEventListener('click', () => {
    // Remove the "active" class from the previously active number link
    $('.active').classList.remove('active')
    // Add the "active" class to the last number link
    numbers[4].classList.add('active')
    currentStep = 4

    updateBtn() // Update the button states

    startBtn.disabled = false
    prevNext[0].disabled = false
})

