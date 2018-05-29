import Article from "./ArticleComponent.js";
import Basket from "./BasketComponent.js";

export default class MainComponent {
    constructor(document) {
        this.container = document.getElementById("main");
        this.mouseDown = this.mouseDown.bind(this);
        this.mouseMove = this.mouseMove.bind(this);
        this.items = [];
        this.fixedFridge = new Article("id", "./img/fridge.jpg");
        this.fixedChair = new Article("id", "./img/chair.jpg");
        this.fixedBanana = new Article("id", "./img/banana.jpg");
        this.fixedGrumly = new Article("id", "./img/grumly.jpg");
        this.fixedBasket = new Basket("id", { left: 20, top: 400 });
        this.appendChild(this.fixedFridge);
        this.appendChild(this.fixedChair);
        this.appendChild(this.fixedBanana);
        this.appendChild(this.fixedGrumly);
        this.appendChild(this.fixedBasket);
    }
    appendChild(childComponent) {
        this.container.appendChild(childComponent.container);
    }
    removeChild(childComponent) {
        this.container.removeChild(childComponent.container);
    }
    mouseDown(event) {
        const cX = event.clientX;
        const cY = event.clientY;
        const selectedArticle = this.items.find(function (element) { return element.isSelected; });
        if (selectedArticle) {
            selectedArticle.unselect();
            if (this.fixedBasket.isHover({ x: cX, y: cY })) {
                const index = this.items.indexOf(selectedArticle);
                if (index > -1) {
                    this.items.splice(index, 1);
                    this.removeChild(selectedArticle);
                }
            }
        }
        else {

            if (this.fixedFridge.isHover({ x: cX, y: cY })) {
                const fridge = new Article("id", "./img/fridge.jpg", this.fixedFridge.container.getBoundingClientRect());
                fridge.setSelected({ x: cX, y: cY });
                this.items.push(fridge);
            }

            for (let element of this.items) {
                if (element.isHover({ x: cX, y: cY })) {
                    element.setSelected({ x: cX, y: cY });
                    break;
                }
            }
        }

    }

    mouseMove(event) {
        const container = this.container;
        const offsets = container.getBoundingClientRect();
        const cX = event.clientX;
        const cY = event.clientY;

        if (!(offsets.left < cX && cX < offsets.right)) {
            return;
        }

        if (!(offsets.top < cY && cY < offsets.bottom)) {
            return;
        }

        const selectedArticle = this.items.find(function (element) { return element.isSelected; });
        if (selectedArticle) {
            container.style.cursor = "move";
            selectedArticle.move({ x: cX, y: cY });
            if (this.fixedBasket.isHover({ x: cX, y: cY })) {
                container.style.cursor = "crosshair";
            }
        } else {
            let hasHover = false;
            for (let element of this.items) {
                if (element.isHover({ x: cX, y: cY })) {
                    container.style.cursor = "pointer";
                    hasHover = true;
                    break;
                }
            }
            if (this.fixedFridge.isHover({ x: cX, y: cY })) {
                container.style.cursor = "pointer";
                hasHover = true;
            }

            if (!hasHover) {
                container.style.cursor = "";
            }
        }
    }
}