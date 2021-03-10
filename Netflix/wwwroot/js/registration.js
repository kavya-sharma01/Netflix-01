const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('#Password');
togglePassword.addEventListener('click', function (e) {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'Password' ? 'text' : 'Password';
    password.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});
