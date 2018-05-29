
export default class Component {
    constructor(parentContainer, child) {
        parentContainer.appendChild(child);
        this.container = child;
    }
}
