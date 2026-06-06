// ===== Theme Toggle =====
const themeBtn = document.getElementById('theme-btn');
const html = document.documentElement;

// Load saved theme
const savedTheme = localStorage.getItem('theme') || 'light';
html.setAttribute('data-theme', savedTheme);

themeBtn?.addEventListener('click', () => {
    const currentTheme = html.getAttribute('data-theme');
    const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
    html.setAttribute('data-theme', newTheme);
    localStorage.setItem('theme', newTheme);
});

// ===== Mobile Menu =====
const mobileMenuBtn = document.getElementById('mobile-menu-btn');
const nav = document.querySelector('.nav');

mobileMenuBtn?.addEventListener('click', () => {
    nav?.classList.toggle('active');
    mobileMenuBtn.classList.toggle('active');
});

// ===== Cart Functionality =====
class Cart {
    constructor() {
        this.items = JSON.parse(localStorage.getItem('cart')) || [];
        this.updateCartCount();
    }

    addItem(id) {
        const existingItem = this.items.find(item => item.id === id);
        if (existingItem) {
            existingItem.quantity++;
        } else {
            this.items.push({ id, quantity: 1 });
        }
        this.save();
        this.showNotification('Added to cart!');
    }

    removeItem(id) {
        this.items = this.items.filter(item => item.id !== id);
        this.save();
    }

    getItems() {
        return this.items;
    }

    getTotal() {
        return this.items.reduce((total, item) => {
            const painting = this.getPaintingById(item.id);
            return total + (painting?.price || 0) * item.quantity;
        }, 0);
    }

    clear() {
        this.items = [];
        this.save();
    }

    save() {
        localStorage.setItem('cart', JSON.stringify(this.items));
        this.updateCartCount();
    }

    updateCartCount() {
        const countElement = document.getElementById('cart-count');
        if (countElement) {
            const count = this.items.reduce((sum, item) => sum + item.quantity, 0);
            countElement.textContent = count;
            countElement.style.display = count > 0 ? 'flex' : 'none';
        }
    }

    getPaintingById(id) {
        // Mock data - in real app this would fetch from server
        const paintings = {
            1: { id: 1, title: 'Рассвет над морем', price: 45000, image: '/images/paintings/sunrise-sea.jpg' },
            2: { id: 2, title: 'Горный пейзаж', price: 55000, image: '/images/paintings/mountain.jpg' },
            3: { id: 3, title: 'Портрет незнакомки', price: 75000, image: '/images/paintings/portrait.jpg' },
            4: { id: 4, title: 'Абстрактная композиция', price: 35000, image: '/images/paintings/abstract.jpg' },
            5: { id: 5, title: 'Цветочный натюрморт', price: 28000, image: '/images/paintings/flowers.jpg' },
            6: { id: 6, title: 'Осенний лес', price: 42000, image: '/images/paintings/autumn.jpg' },
            7: { id: 7, title: 'Городские огни', price: 65000, image: '/images/paintings/city.jpg' },
            8: { id: 8, title: 'Медитация', price: 38000, image: '/images/paintings/meditation.jpg' }
        };
        return paintings[id];
    }

    showNotification(message) {
        const notification = document.createElement('div');
        notification.className = 'notification';
        notification.textContent = message;
        notification.style.cssText = `
            position: fixed;
            bottom: 20px;
            right: 20px;
            background: var(--primary-color);
            color: white;
            padding: 15px 25px;
            border-radius: var(--border-radius);
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
            z-index: 10000;
            animation: slideIn 0.3s ease;
        `;
        document.body.appendChild(notification);

        setTimeout(() => {
            notification.style.animation = 'slideOut 0.3s ease';
            setTimeout(() => notification.remove(), 300);
        }, 2000);
    }
}

const cart = new Cart();

// Add to cart buttons
document.querySelectorAll('.add-to-cart').forEach(btn => {
    btn.addEventListener('click', () => {
        const id = parseInt(btn.dataset.id);
        cart.addItem(id);
    });
});

// Render cart page
function renderCart() {
    const cartItems = document.getElementById('cart-items');
    const cartSummary = document.getElementById('cart-summary');
    const emptyCart = document.getElementById('empty-cart');
    const totalAmount = document.getElementById('total-amount');

    if (!cartItems) return;

    const items = cart.getItems();

    if (items.length === 0) {
        emptyCart.style.display = 'block';
        cartItems.style.display = 'none';
        cartSummary.style.display = 'none';
        return;
    }

    emptyCart.style.display = 'none';
    cartItems.style.display = 'block';
    cartSummary.style.display = 'block';

    cartItems.innerHTML = items.map(item => {
        const painting = cart.getPaintingById(item.id);
        if (!painting) return '';
        return `
            <div class="cart-item">
                <div class="cart-item-image">
                    <img src="${painting.image}" alt="${painting.title}" onerror="this.src='/images/placeholder.jpg'" />
                </div>
                <div class="cart-item-info">
                    <h3 class="cart-item-title">${painting.title}</h3>
                    <p class="cart-item-price">${painting.price.toLocaleString()} ₽</p>
                </div>
                <button class="cart-item-remove" onclick="removeFromCart(${item.id})">
                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <line x1="18" y1="6" x2="6" y2="18"/>
                        <line x1="6" y1="6" x2="18" y2="18"/>
                    </svg>
                </button>
            </div>
        `;
    }).join('');

    totalAmount.textContent = `${cart.getTotal().toLocaleString()} ₽`;
}

function removeFromCart(id) {
    cart.removeItem(id);
    renderCart();
}

// ===== Animations CSS (injected) =====
const style = document.createElement('style');
style.textContent = `
    @keyframes slideIn {
        from { transform: translateX(100%); opacity: 0; }
        to { transform: translateX(0); opacity: 1; }
    }
    @keyframes slideOut {
        from { transform: translateX(0); opacity: 1; }
        to { transform: translateX(100%); opacity: 0; }
    }
`;
document.head.appendChild(style);

// ===== Smooth scroll for anchor links =====
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
        }
    });
});

// ===== Form validation feedback =====
document.querySelectorAll('.form-control').forEach(input => {
    input.addEventListener('blur', function() {
        if (this.value.trim() !== '') {
            this.classList.add('filled');
        } else {
            this.classList.remove('filled');
        }
    });
});

// ===== Image lazy loading =====
if ('IntersectionObserver' in window) {
    const imageObserver = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                if (img.dataset.src) {
                    img.src = img.dataset.src;
                    img.removeAttribute('data-src');
                }
                observer.unobserve(img);
            }
        });
    });

    document.querySelectorAll('img[data-src]').forEach(img => {
        imageObserver.observe(img);
    });
}
