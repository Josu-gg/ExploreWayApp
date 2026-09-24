window.exploreWayJs = {
  scrollToSection: function (elementId) {
    const cleanId = elementId.replace('#', '');
    const element = document.getElementById(cleanId);
    if (element) {
      const headerOffset = 80;
      const elementPosition = element.getBoundingClientRect().top;
      const offsetPosition = elementPosition + window.pageYOffset - headerOffset;
      window.scrollTo({
        top: offsetPosition,
        behavior: 'smooth'
      });
    }
  },

  initNavbarScrollEffect: function () {
    window.addEventListener('scroll', function () {
      const appbar = document.querySelector('.exploreway-appbar');
      if (appbar) {
        if (window.scrollY > 20) {
          appbar.style.backgroundColor = 'rgba(255, 255, 255, 0.98)';
        } else {
          appbar.style.backgroundColor = 'rgba(255, 255, 255, 0.92)';
        }
      }
    });
  }
};

document.addEventListener('DOMContentLoaded', function () {
  if (window.exploreWayJs) {
    window.exploreWayJs.initNavbarScrollEffect();
  }
});