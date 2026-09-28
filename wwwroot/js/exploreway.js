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

  // Navbar: acumula cuerpo (sólida + blur + sombra) al dejar el tope,
  // y se oculta al bajar / reaparece al subir o al llegar arriba.
  initNavbarScrollEffect: function () {
    const appbar = document.querySelector('.exploreway-appbar');
    if (!appbar) return;

    let ultimoY = window.scrollY;
    let pendiente = false;

    const actualizar = () => {
      const y = window.scrollY;
      appbar.classList.toggle('is-scrolled', y > 24);

      const bajando = y > ultimoY && y > 120;
      appbar.classList.toggle('exploreway-appbar--hidden', bajando);

      ultimoY = y;
      pendiente = false;
    };

    window.addEventListener('scroll', () => {
      if (!pendiente) {
        pendiente = true;
        requestAnimationFrame(actualizar);
      }
    }, { passive: true });

    actualizar();
  },

  // Pill deslizante que acompaña la sección visible.
  initActiveSection: function () {
    const enlaces = Array.from(document.querySelectorAll('[data-section-link]'));
    const pill = document.querySelector('.exploreway-nav-pill');
    if (!enlaces.length || !pill) return;

    const moverPill = (enlace) => {
      if (!enlace) return;
      enlaces.forEach(l => l.classList.toggle('active', l === enlace));
      const base = 100;
      pill.style.transform =
        'translateX(' + enlace.offsetLeft + 'px) scaleX(' + (enlace.offsetWidth / base) + ')';
    };

    const activoActual = () =>
      document.querySelector('[data-section-link].active') || enlaces[0];

    const secciones = enlaces
      .map(e => document.getElementById(e.getAttribute('data-section-link')))
      .filter(Boolean);

    if (secciones.length && 'IntersectionObserver' in window) {
      const observador = new IntersectionObserver((entradas) => {
        const visible = entradas
          .filter(e => e.isIntersecting)
          .sort((a, b) => b.intersectionRatio - a.intersectionRatio)[0];

        if (visible) {
          const enlace = enlaces.find(
            l => l.getAttribute('data-section-link') === visible.target.id);
          moverPill(enlace);
        }
      }, { rootMargin: '-30% 0px -55% 0px', threshold: [0, 0.2, 0.5, 1] });

      secciones.forEach(s => observador.observe(s));
    }

    enlaces.forEach(e => e.addEventListener('click', () => moverPill(e)));
    window.addEventListener('resize', () => moverPill(activoActual()));
    window.addEventListener('load', () => moverPill(activoActual()));
    if (document.fonts && document.fonts.ready) {
      document.fonts.ready.then(() => moverPill(activoActual()));
    }

    moverPill(activoActual());
  },

  // Reveals: los elementos aparecen al entrar en pantalla; sin JS quedan visibles.
  initScrollReveals: function () {
    document.documentElement.classList.add('js-anim');
    const objetivos = document.querySelectorAll('[data-reveal]');
    if (!objetivos.length) return;

    const reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    if (reduceMotion || !('IntersectionObserver' in window)) {
      objetivos.forEach(el => el.classList.add('is-visible'));
      return;
    }

    const observador = new IntersectionObserver((entradas, obs) => {
      entradas.forEach(entrada => {
        if (!entrada.isIntersecting) return;

        const el = entrada.target;
        const demora = parseInt(el.getAttribute('data-reveal-delay') || '0', 10);
        if (demora) {
          el.style.transitionDelay = demora + 'ms';
          el.addEventListener('transitionend', () => {
            el.style.transitionDelay = '';
          }, { once: true });
        }

        el.classList.add('is-visible');
        obs.unobserve(el);
      });
    }, { rootMargin: '0px 0px -10% 0px', threshold: 0.12 });

    objetivos.forEach(el => observador.observe(el));
  }
};

document.addEventListener('DOMContentLoaded', function () {
  if (window.exploreWayJs) {
    window.exploreWayJs.initNavbarScrollEffect();
    window.exploreWayJs.initActiveSection();
    window.exploreWayJs.initScrollReveals();
  }
});
