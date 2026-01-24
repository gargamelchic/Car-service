document.addEventListener('DOMContentLoaded', function() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function(e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate__animated', 'animate__fadeInUp');
            }
        });
    }, observerOptions);

    document.querySelectorAll('.service-card, .gallery-item, .card').forEach(el => {
        observer.observe(el);
    });
});

function validateContactForm() {
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function(e) {
            const phoneInput = form.querySelector('input[name$="Phone"]');
            if (phoneInput && phoneInput.value) {
                const phoneRegex = /^[\+]?[7-8]?[0-9\s\-\(\)]{10,15}$/;
                if (!phoneRegex.test(phoneInput.value)) {
                    e.preventDefault();
                    alert('Пожалуйста, введите корректный номер телефона');
                    phoneInput.focus();
                }
            }
        });
    }
}

document.addEventListener('DOMContentLoaded', validateContactForm);