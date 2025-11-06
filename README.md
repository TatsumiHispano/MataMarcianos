# 👾 El Mata Marcianos – Juego 2D en Unity

**El Mata Marcianos** es un juego 2D tipo *space shooter* desarrollado en **Unity**, en el que el jugador controla una nave espacial para destruir enemigos mientras avanza por un mundo infinito.  
Cuenta con sistema de disparo cargado, cámara dinámica, movimiento fluido y efectos visuales con partículas y UI integradas.

---

## 🎮 Características Principales

- 🛩️ **Control del avión** con movimiento libre en el eje X/Y.  
- 🔫 **Sistema de disparo doble:**  
  - Disparo normal (rápido).  
  - Disparo cargado (potente, con efectos visuales).  
- ⚡ **Barra de carga visual** con colores dinámicos (verde → rojo → azul neón).  
- 🔥 **Partículas de carga y disparo** para mejorar la experiencia visual.  
- 🎥 **Cámara en movimiento automático** con seguimiento al jugador.  
- 🚀 **Avance infinito** del escenario para crear sensación de vuelo continuo.  
- 🧱 **Límites de cámara y jugador** configurables con márgenes personalizados.  
- 🎵 **Efectos de sonido y animaciones** fácilmente integrables en el flujo de juego.

---

## 🧩 Scripts Principales

### 🛠️ `AvionController.cs`
Controla el movimiento y el sistema de disparo del jugador:
- Movimiento libre con límites en la pantalla.  
- Disparo normal o cargado dependiendo del tiempo que se mantenga presionada la tecla **espacio**.  
- Gestión de partículas y barra de carga.  
- Cambio dinámico de color en la barra según el nivel de carga.

---

### 📷 `MovimientoCamara.cs`
- Controla el desplazamiento automático de la cámara hacia la derecha.  
- Define márgenes de movimiento para limitar al jugador dentro de la pantalla.  
- Usa interpolación (`Lerp`) para suavizar la corrección de posición del jugador.

---

### ✈️ `AvionSeguirCamara.cs`
- Aplica movimiento automático al avión hacia adelante (eje X).  
- Puede usarse para mantener un desplazamiento constante, simulando vuelo continuo.

---

### 💥 `DisparoController.cs`
- Gestiona la lógica del proyectil.  
- Control del tiempo de vida de las balas.  
- Implementa un sistema de **potencia variable** según el tiempo de carga del disparo.  
- Permite disparos más rápidos o potentes dependiendo de la duración de la carga.

---

## 🌌 Mecánicas del Juego

### 🎮 Movimiento
El jugador puede desplazarse en todas las direcciones con las flechas (`← ↑ ↓ →`) dentro de los límites de cámara.

### 🔫 Disparo
- Presiona **espacio** para comenzar a cargar el disparo.  
- Si sueltas antes de **0.5 segundos** → disparo normal.  
- Si mantienes más tiempo → disparo cargado con daño y efectos aumentados.

### 🎥 Cámara Dinámica
La cámara se desplaza automáticamente, creando sensación de avance infinito, y mantiene al jugador centrado dentro de los márgenes establecidos.

### ⚡ Interfaz
La **barra de carga** muestra visualmente la potencia del disparo, cambiando de color según el progreso.

---

## ⚙️ Tecnologías y Recursos

- 🧱 **Unity Engine (2D)**  
- 💻 **C#**  
- 🎨 **UI System (Canvas, Slider, Image)**  
- ✨ **Particle System**  
- 🔊 **AudioSource** (para efectos de disparo, carga y explosión)  
- 🎬 **Animator** *(opcional)* para añadir animaciones de la nave o enemigos.
