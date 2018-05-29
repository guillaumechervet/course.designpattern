
import Component from "./Component.js";

export default class ArticleComponent extends Component{

    constructor(parentContainer, id, label, src, position) {
        const size = { width: 50, height: 50 };

        const container = document.createElement('img');
        container.src = src;
        container.style.width = size.width + "px";
        container.style.height = size.height + "px";
        if (position) {
            container.style.position = "absolute";
            container.style.top = position.top + "px";
            container.style.left = position.left + "px";
        }
        const mouseSelectedPosition = { x: 0, y: 0 };
        super(parentContainer, container);
        this.mouseSelectedPosition = mouseSelectedPosition;
        this.isSelected = false;
        this.size = size;
        this.id = id;
        this.label = label;
    }
    setSelected(point) {
        const offsets = this.container.getBoundingClientRect();
        this.mouseSelectedPosition.x = point.x - offsets.x;
        this.mouseSelectedPosition.y = point.y - offsets.y;
        this.isSelected = true;

        this.container.style.position = "absolute";
        this.container.style.top = offsets.top + "px";
        this.container.style.left = offsets.left + "px";
    }

    unselect() {
        this.isSelected = false;
    }
    move(point) {
        const x = (point.x - this.mouseSelectedPosition.x);
        const y = (point.y - this.mouseSelectedPosition.y);
        this.container.style.top = y + "px";
        this.container.style.left = x + "px";
    }
    isHover(point) {
        const offsets = this.container.getBoundingClientRect();
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