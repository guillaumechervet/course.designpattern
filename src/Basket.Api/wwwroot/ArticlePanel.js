import Article from "./ArticleComponent.js";
import Basket from "./BasketComponent.js";

export default class ArticlePanel {
    constructor(document, basketPanel) {
        this.container = document.getElementById("articlePanel");
        this.mouseDown = this.mouseDown.bind(this);
        this.mouseMove = this.mouseMove.bind(this);
        this.items = [];
        this.fixedFridge = new Article(this.container, "2", "Fridge", "./img/fridge.jpg");
        this.fixedChair = new Article(this.container, "3", "Chair", "./img/chair.jpg");
        this.fixedBanana = new Article(this.container, "1", "banana", "./img/banana.jpg");
        this.fixedGrumly = new Article(this.container, "4", "grumly", "./img/grumly.jpg");
        this.fixedBasket = new Basket(this.container, { left: 20, top: 400 });
        this.basketPanel = basketPanel;
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
                    this.basketPanel.add({ id: selectedArticle.id, label: selectedArticle.label });
                }
            }
        }
        else {

            if (this.fixedFridge.isHover({ x: cX, y: cY })) {
                const fridge = new Article(this.container, this.fixedFridge.id, this.fixedFridge.label, "./img/fridge.jpg", this.fixedFridge.container.getBoundingClientRect());
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