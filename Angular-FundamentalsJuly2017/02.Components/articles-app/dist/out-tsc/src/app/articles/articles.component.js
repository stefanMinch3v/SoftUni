var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { ArticleData } from '../data/data';
var ArticlesComponent = /** @class */ (function () {
    function ArticlesComponent() {
    }
    ArticlesComponent.prototype.ngOnInit = function () {
        this.articles = new ArticleData().getData();
    };
    ArticlesComponent.prototype.dataReceived = function (data) {
        alert(data);
    };
    ArticlesComponent = __decorate([
        Component({
            selector: 'articles-parent',
            templateUrl: './articles.component.html',
            styleUrls: ['./articles.component.css']
        })
    ], ArticlesComponent);
    return ArticlesComponent;
}());
export { ArticlesComponent };
//# sourceMappingURL=articles.component.js.map