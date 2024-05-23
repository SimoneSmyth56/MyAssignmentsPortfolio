// Download CV 

document.addEventListener('DOMContentLoaded', function() {
    var downloadBtn = document.getElementById('openInNewWindowBtn');

    if (downloadBtn) {
        downloadBtn.addEventListener('click', function(event) {
            event.preventDefault();
            var cvLink = downloadBtn.getAttribute('href');
            window.open(cvLink, '_blank');
        });
    }
});

// typing animation

document.addEventListener("DOMContentLoaded", function () {
    var typed = new Typed(".typing", {
        strings: ["Web Designer", "Web Developer", "Social Media Manager", "Content Creator"],
        typeSpeed: 100,
        backSpeed: 60,
        loop: true
    });
});







