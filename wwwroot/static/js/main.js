// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// for authecation form
const userIcon = document.querySelector('.user-icon')
const loginForm = document.querySelector('.login-form-container')
const registerForm = document.querySelector('.register-form-container')

// --------------- Custom Scroll Bar --------------
window.onscroll = () => {
    myfunction()
}

const myfunction = () => {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop
    var height =
        document.documentElement.scrollHeight -
        document.documentElement.clientHeight
    var scrolled = (winScroll / height) * 100
    document.getElementById('scroll-bar').style.width = scrolled + '%'
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
