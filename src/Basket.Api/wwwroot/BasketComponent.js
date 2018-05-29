
import Component from "./Component.js";


export default class BasketComponent extends Component {

    constructor(parentContainer, position) {
        const size = { width: 100, height: 100 };

        const image = document.createElement('img');
        image.src = "./img/basket.jpg";
        image.style.width = size.width + "px";
        image.style.height = size.height + "px";
        if (position) {
            image.style.position = "absolute";
            image.style.top = position.top + "px";
            image.style.left = position.left + "px";
        }
       
        super(parentContainer, image);
        this.size = size;
    }
    isHover(point) {
        const offsets = this.container.getBoundingClientRect();
        const x = offsets.left;
        const y = offsets.top;
        const width = this.size.width;
        const height = this.size.height;

        var isX = false;
        if (x < point.x && point.x < (x + width)) {
            isX = true;
        }
        var isY = false;
        if (y < point.y && point.y < (y + height)) {
            isY = true;
        }
        return isX && isY;
    }

}