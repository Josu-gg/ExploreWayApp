/* ============================================================
   EXPLOREWAY — INICIO "EL DESCENSO"
   - Genera las crestas del paisaje (SVG) con una semilla fija.
   - Parallax del hero (scroll + mouse).
   - Altímetro: altitud interpolada entre las paradas [data-alt].
   - Revelados al entrar en pantalla y línea de pasos que se dibuja.
   Todo se limpia en dispose() al salir de la página.
   ============================================================ */
window.ewInicio = (function () {
  'use strict';

  let estado = null;

  const clamp = (v, a, b) => Math.min(b, Math.max(a, v));

  function semilla(s) {
    return function () {
      s |= 0; s = (s + 0x6D2B79F5) | 0;
      let t = Math.imul(s ^ (s >>> 15), 1 | s);
      t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
      return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
    };
  }

  const W = 1700, H = 900, X0 = -50;

  // Desplazamiento de punto medio: cordillera irregular.
  function cresta(r, base, amp, aspereza, pasos) {
    let pts = [[X0, base + (r() - 0.5) * amp * 0.5], [X0 + W, base + (r() - 0.5) * amp * 0.5]];
    let desp = amp * 0.55;
    for (let i = 0; i < pasos; i++) {
      const sig = [];
      for (let j = 0; j < pts.length - 1; j++) {
        const a = pts[j], b = pts[j + 1];
        sig.push(a);
        sig.push([(a[0] + b[0]) / 2, (a[1] + b[1]) / 2 + (r() - 0.5) * 2 * desp]);
      }
      sig.push(pts[pts.length - 1]);
      pts = sig;
      desp *= aspereza;
    }
    const techo = base - amp * 1.15;
    const camino = pts.map(p => p[0].toFixed(1) + ' ' + clamp(p[1], techo, H).toFixed(1)).join('L');
    return 'M' + camino + 'L' + (X0 + W) + ' ' + H + 'L' + X0 + ' ' + H + 'Z';
  }

  // Cordillera alpina: picos de flancos empinados, más altos hacia la derecha, con rugosidad fina.
  function picos(r, base, amp, cantidad) {
    const lista = [];
    for (let i = 0; i < cantidad; i++) {
      const px = X0 + (i + 0.2 + r() * 0.6) * (W / cantidad);
      const escala = 0.42 + 0.58 * ((px - X0) / W);
      lista.push({ x: px, h: amp * escala * (0.55 + r() * 0.45), s: 0.8 + r() * 0.6 });
    }
    const ruido = cresta(r, 0, amp * 0.1, 0.55, 9);
    const sub = ruido.split('L').slice(0, -2);
    let d = '', k = 0;
    for (let x = X0; x <= X0 + W; x += 5) {
      let alto = 0;
      for (const p of lista) alto = Math.max(alto, p.h - p.s * Math.abs(x - p.x));
      const jitter = (parseFloat((sub[Math.min(sub.length - 1, k)] || '0 0').split(' ')[1]) || 0);
      k = Math.min(sub.length - 1, k + 2);
      d += (d ? 'L' : 'M') + x + ' ' + (base - alto + jitter * 0.9).toFixed(1);
    }
    return d + 'L' + (X0 + W) + ' ' + H + 'L' + X0 + ' ' + H + 'Z';
  }

  // Bosque de coníferas: dientes de sierra irregulares sobre una línea base ondulada.
  function bosque(r, base, alto) {
    let x = X0, d = 'M' + X0 + ' ' + H + 'L' + X0 + ' ' + base;
    while (x < X0 + W) {
      const ancho = 9 + r() * 15;
      const ondula = Math.sin(x / 230) * 12 + Math.sin(x / 71) * 4;
      const pico = base + ondula - alto * (0.3 + r() * 0.7);
      const valle = base + ondula - alto * 0.12 * r();
      d += 'L' + (x + ancho * 0.5).toFixed(1) + ' ' + pico.toFixed(1);
      d += 'L' + (x + ancho).toFixed(1) + ' ' + valle.toFixed(1);
      x += ancho;
    }
    return d + 'L' + (X0 + W) + ' ' + H + 'Z';
  }

  function construirPaisaje(raiz) {
    const r = semilla(5203);
    raiz.querySelectorAll('svg.ew-capa').forEach(function (svg, i) {
      const tipo = svg.getAttribute('data-cresta');
      const base = parseFloat(svg.getAttribute('data-base'));
      const amp = parseFloat(svg.getAttribute('data-amp'));
      const path = svg.querySelector('path');
      if (!path) return;
      let d;
      if (tipo === 'bosque') d = bosque(r, base, amp);
      else if (tipo === 'suave') d = cresta(r, base, amp, 0.52, 9);
      else d = picos(r, base, amp, tipo === 'alpina' && amp > 230 ? 7 : 9);
      path.setAttribute('d', d);
    });

    const cont = raiz.querySelector('.ew-estrellas');
    if (cont && !cont.childElementCount) {
      const rs = semilla(77);
      const frag = document.createDocumentFragment();
      for (let i = 0; i < 90; i++) {
        const e = document.createElement('i');
        const tam = 1 + rs() * 1.8;
        e.style.left = (rs() * 100).toFixed(2) + '%';
        e.style.top = (rs() * 62).toFixed(2) + '%';
        e.style.width = e.style.height = tam.toFixed(1) + 'px';
        e.style.opacity = (0.25 + rs() * 0.65).toFixed(2);
        if (i % 9 === 0) { e.className = 'titila'; e.style.animationDelay = (rs() * 5).toFixed(1) + 's'; }
        frag.appendChild(e);
      }
      cont.appendChild(frag);
    }
  }

  function formatoAltitud(m) {
    const abs = Math.abs(m);
    const redondo = abs > 100 ? Math.round(abs / 10) * 10 : Math.round(abs);
    const txt = String(redondo).replace(/\B(?=(\d{3})+(?!\d))/g, ' ');
    return (m < 0 && redondo !== 0 ? '−' : '') + txt;
  }

  function init() {
    if (estado) dispose();

    const raiz = document.getElementById('ew-inicio');
    if (!raiz) return;

    const reducir = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    document.body.classList.add('ew-en-inicio');

    raiz.classList.add('ew-js');
    construirPaisaje(raiz);

    const capas = Array.from(raiz.querySelectorAll('.ew-capa, .ew-luna'));
    const cuerpoHero = raiz.querySelector('.ew-hero-cuerpo');
    const hero = raiz.querySelector('.ew-hero');
    const anclas = Array.from(raiz.querySelectorAll('[data-alt]'));
    const numAlt = raiz.querySelector('.ew-alt-num');
    const refAlt = raiz.querySelector('.ew-alt-ref');
    const marca = raiz.querySelector('.ew-alt-marca');
    const fotos = Array.from(raiz.querySelectorAll('.ew-foto img'));
    const lista = raiz.querySelector('.ew-pasos-lista');

    const mouse = { x: 0, y: 0, cx: 0, cy: 0 };
    let programado = false;

    function altitudActual(vh) {
      if (!anclas.length) return 0;
      const sonda = vh * 0.5;
      const pts = anclas.map(function (el) {
        const r = el.getBoundingClientRect();
        return { c: (r.top + r.bottom) / 2, a: parseFloat(el.getAttribute('data-alt')) };
      });
      if (sonda <= pts[0].c) return pts[0].a;
      for (let i = 0; i < pts.length - 1; i++) {
        if (sonda <= pts[i + 1].c) {
          const t = (sonda - pts[i].c) / Math.max(1, pts[i + 1].c - pts[i].c);
          return pts[i].a + (pts[i + 1].a - pts[i].a) * t;
        }
      }
      return pts[pts.length - 1].a;
    }

    function pintar() {
      programado = false;
      const y = window.scrollY;
      const vh = window.innerHeight;

      // Barra de navegación: se vuelve sólida al dejar el tope (se consulta cada vez: Blazor puede reemplazar el nodo)
      const barra = document.querySelector('.exploreway-appbar');
      if (barra) barra.classList.toggle('is-scrolled', y > 24);

      // Altímetro
      const alt = altitudActual(vh);
      if (numAlt) numAlt.textContent = formatoAltitud(alt);
      if (refAlt) refAlt.textContent = alt > 0.5 ? 'sobre el nivel del mar' : (alt < -0.5 ? 'bajo el nivel del mar' : 'nivel del mar');
      if (marca) {
        const total = Math.max(1, document.documentElement.scrollHeight - vh);
        marca.style.top = (clamp(y / total, 0, 1) * 100).toFixed(2) + '%';
      }

      // Hero: parallax por profundidad
      if (!reducir && y < vh * 1.4) {
        mouse.cx += (mouse.x - mouse.cx) * 0.08;
        mouse.cy += (mouse.y - mouse.cy) * 0.08;
        capas.forEach(function (el) {
          const p = parseFloat(el.getAttribute('data-prof') || '0.5');
          const tx = -mouse.cx * p * 26;
          const ty = y * (1 - p) * 0.4 - mouse.cy * p * 9;
          el.style.translate = tx.toFixed(1) + 'px ' + ty.toFixed(1) + 'px';
        });
        if (cuerpoHero) {
          cuerpoHero.style.translate = '0 ' + (y * 0.2).toFixed(1) + 'px';
          cuerpoHero.style.opacity = clamp(1 - y / (vh * 0.75), 0, 1).toFixed(3);
        }
        if (Math.abs(mouse.x - mouse.cx) > 0.002 || Math.abs(mouse.y - mouse.cy) > 0.002) pedir();
      }

      // Fotos: parallax interno
      if (!reducir) {
        fotos.forEach(function (img) {
          const r = img.parentElement.getBoundingClientRect();
          if (r.bottom < -100 || r.top > vh + 100) return;
          const k = ((r.top + r.height / 2) - vh / 2) / vh;
          img.style.translate = '0 ' + (-k * 7).toFixed(2) + '%';
        });
      }

      // Pasos: la línea se dibuja al entrar
      if (lista) {
        const r = lista.getBoundingClientRect();
        const prog = clamp((vh * 0.78 - r.top) / (vh * 0.45), 0, 1);
        lista.style.setProperty('--prog', prog.toFixed(3));
      }
    }

    function pedir() {
      if (!programado) { programado = true; requestAnimationFrame(pintar); }
    }

    function alMouse(e) {
      mouse.x = (e.clientX / window.innerWidth) * 2 - 1;
      mouse.y = (e.clientY / window.innerHeight) * 2 - 1;
      pedir();
    }

    window.addEventListener('scroll', pedir, { passive: true });
    window.addEventListener('resize', pedir);
    if (!reducir) window.addEventListener('mousemove', alMouse, { passive: true });

    // Revelados
    const objetivos = raiz.querySelectorAll('[data-ew-in]');
    let obs = null;
    if (reducir || !('IntersectionObserver' in window)) {
      objetivos.forEach(function (el) { el.classList.add('ew-in'); });
    } else {
      obs = new IntersectionObserver(function (entradas) {
        entradas.forEach(function (en) {
          if (!en.isIntersecting) return;
          en.target.classList.add('ew-in');
          obs.unobserve(en.target);
        });
      }, { rootMargin: '0px 0px -12% 0px', threshold: 0.15 });
      objetivos.forEach(function (el) { obs.observe(el); });
    }

    // Entrada del hero: se quita el estado inicial en el siguiente frame
    requestAnimationFrame(function () {
      requestAnimationFrame(function () { raiz.classList.remove('ew-pre'); });
    });

    pintar();

    estado = { raiz: raiz, pedir: pedir, alMouse: alMouse, obs: obs };
  }

  function dispose() {
    if (!estado) return;
    window.removeEventListener('scroll', estado.pedir);
    window.removeEventListener('resize', estado.pedir);
    window.removeEventListener('mousemove', estado.alMouse);
    if (estado.obs) estado.obs.disconnect();
    document.body.classList.remove('ew-en-inicio');
    estado = null;
  }

  return { init: init, dispose: dispose };
})();
