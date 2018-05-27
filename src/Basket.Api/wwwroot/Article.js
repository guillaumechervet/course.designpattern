
export default class Article {

    constructor(id, src, position) {
        const size = { width: 50, height: 50 };
        this.size = size;
        const image = document.createElement('img');
        image.src = src;
        image.style.width = size.width + "px";
        image.style.height = size.height + "px";
        const container = document.getElementById("main");
        container.appendChild(image);
        this.container = container;
        if (position) {
            image.style.position = "absolute";
            image.style.top = position.top + "px";
            image.style.left = position.left + "px";
        }

        const mouseSelectedPosition = { x: 0, y: 0 };
        this.mouseSelectedPosition = mouseSelectedPosition;
        this.isSelected = false;
        this.image = image;
    }
    setSelected(point) {
        const offsets = this.image.getBoundingClientRect();
        this.mouseSelectedPosition.x = point.x - offsets.x;
        this.mouseSelectedPosition.y = point.y - offsets.y;
        this.isSelected = true;

        this.image.style.position = "absolute";
        this.image.style.top = offsets.top + "px";
        this.image.style.left = offsets.left + "px";
    }

    unselect() {
        this.isSelected = false;
    }

    remove() {
        this.container.removeChild(this.image);
    }

    move(point) {
        const x = (point.x - this.mouseSelectedPosition.x);
        const y = (point.y - this.mouseSelectedPosition.y);
        this.image.style.top = y + "px";
        this.image.style.left = x + "px";
    }

    getPosition() {
        return this.image.getBoundingClientRect();
    }

    isHover(point) {
        const offsets = this.image.getBoundingClientRect();
        const x = offsets.left;
        const y = offsets.top;
        const width = this.size.width;
        const height = this.size.height;

        let isX = false;
        if (x < point.x && point.x < (x + width)) {
            isX = true;
        }
        let isY = false;
        if (y < point.y && point.y < (y + height)) {
            isY = true;
        }
        return isX && isY;
    }

}