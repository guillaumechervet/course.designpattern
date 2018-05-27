import Article from './Article.js';
import Basket from './Basket.js';

export default class MainContainer {
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
                    selectedArticle.remove();
                }
            }
        }
        else {

            if (this.fixedFridge.isHover({ x: cX, y: cY })) {
                const fridge = new Article("id", "./img/fridge.jpg", this.fixedFridge.getPosition());
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