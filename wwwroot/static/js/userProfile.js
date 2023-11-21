const listGroupItem = document.querySelectorAll('.list-group-item')

const opt = document.querySelector('.opt')
const listOption = opt.querySelectorAll('[id]')

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