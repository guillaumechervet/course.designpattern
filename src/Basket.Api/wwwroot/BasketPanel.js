import Article from "./ArticleComponent.js";
import Basket from "./BasketComponent.js";

export default class BasketPanel {
    constructor(document) {
        this.container = document.getElementById("basketPanel");
        this.container.innerHTML = '<h2>Basket</h2><span>Basket is empty</span>';
        this.data = {
            BasketLineArticles: []
        };
        this.total = 0;
    }
    add(article) {
        const currentArticle = this.data.BasketLineArticles.find(function (element) { return element.Id === article.id; });
        if (currentArticle) {
            currentArticle.Number++;
        } else {
            this.data.BasketLineArticles.push({ Id: article.id, Number: 1, Label: article.label })
        }

        fetch('/api/basket', {
            method: 'POST',
            body: JSON.stringify(this.data),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => {
            res.json().then((result) => {
                this.total = result.total / 100;
                this.render();
            });
        })
            .catch(error => console.error('Error:', error))
            .then(response => console.log('Success:', response));
    }
    render() {
        var innerHtml = '<h2>Basket</h2><ul>';
        for (let element of this.data.BasketLineArticles) {
            innerHtml += '<li>' + element.Number + ' '  + element.Label  + '</li>';
        }
        innerHtml += '</ul>';
        innerHtml += '<b>Total: '+ this.total +'€</b>';
        this.container.innerHTML = innerHtml;
    }
    
}