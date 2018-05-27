

export default function Basket(id, position) {
    var size = { width: 100, height: 100 };

    var image = document.createElement('img');
    image.src = "./img/basket.jpg";
    image.style.width = size.width + "px";
    image.style.height = size.height + "px";
    const container = document.getElementById("main");
    container.appendChild(image);

    if (position) {
        image.style.position = "absolute";
        image.style.top = position.top + "px";
        image.style.left = position.left + "px";
    }

    this.getPosition = function () {
        return image.getBoundingClientRect();
    }

    this.isHover = function (point) {
        const offsets = image.getBoundingClientRect();
        const x = offsets.left;
        const y = offsets.top;
        const width = size.width;
        const height = size.height;

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