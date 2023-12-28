const listGroupItem = document.querySelectorAll('.list-group-item')

const opt = document.querySelector('.opt')
const listOption = opt.querySelectorAll('.tab')

listGroupItem.forEach((ele, idx) => {
    ele.addEventListener('click', (e) => {
        listGroupItem.forEach(item => {
            item.classList.remove('active')
        })

        if (!ele.classList.contains('active'))
            ele.classList.add('active')

        listOption.forEach(el => {
            el.classList.remove('active')
            el.classList.remove('show')
        })

        listOption.forEach((el, id) => {
            if (id == idx) {
                el.classList.add('active')
                el.classList.add('show')
            }
        })
    })
})

function reOpen() {
    listGroupItem.forEach(item => {
        item.classList.remove('active');
    });
    listOption.forEach(el => {
        el.classList.remove('active');
        el.classList.remove('show');
    });

    listGroupItem[2].classList.add('active'); // Assuming the password change tab is the second item
    listOption[2].classList.add('active');
    listOption[2].classList.add('show');
}

document.getElementById('verifyButton').addEventListener('click', function() {
    fetch('/Profile/SendVerificationEmail', { method: 'POST' })
        .then(response => {
            if (!response.ok) {
                console.error('Response status was not ok:', response.status);
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                var notyf = new Notyf();
                notyf.success('Sent verification email');
            } else {
                // Handle the error
            }
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        });
});
