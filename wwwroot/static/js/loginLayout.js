const userSetting = document.querySelector('.user-setting')

userIcon.onclick = () => {
    userSetting.classList.toggle('active')
}

document.onclick = (e) => {
    if (!userIcon.contains(e.target) && !userSetting.contains(e.target))
        userSetting.classList.remove('active');
}

