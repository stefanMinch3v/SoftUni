var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../models/article.model';
var ArticleComponent = /** @class */ (function () {
    function ArticleComponent() {
        this.symbols = 250;
        this.showReadMoreBtn = true;
        this.showHideBtn = false;
        this.imageIsShown = false;
        this.imageButtonTitle = 'Show Image';
        this.articleDescLen = 0;
        this.descToShow = "";
        this.testSend = new EventEmitter();
    }
    ArticleComponent.prototype.testSendToParent = function () {
        this.testSend.emit('Data to parent');
    };
    ArticleComponent.prototype.readMore = function () {
        this.articleDescLen += this.symbols;
        if (this.articleDescLen >= this.articleDesc.length) {
            this.showHideBtn = true;
            this.showReadMoreBtn = false;
        }
        else {
            this.descToShow = this.articleDesc.substring(0, this.articleDescLen);
        }
    };
    ArticleComponent.prototype.toggleImage = function () {
        this.imageIsShown = !this.imageIsShown;
        this.imageButtonTitle = this.imageButtonTitle === "Show Image"
            ? "Hide Image" : "Show Image";
    };
    ArticleComponent.prototype.hideDesc = function () {
        this.descToShow = "";
        this.articleDescLen = 0;
        this.showHideBtn = false;
        this.showReadMoreBtn = true;
    };
    __decorate([
        Input(),
        __metadata("design:type", Article)
    ], ArticleComponent.prototype, "article", void 0);
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], ArticleComponent.prototype, "articleDesc", void 0);
    __decorate([
        Output(),
        __metadata("design:type", EventEmitter)
    ], ArticleComponent.prototype, "testSend", void 0);
    ArticleComponent = __decorate([
        Component({
            selector: 'app-article',
            templateUrl: './article.component.html',
            styleUrls: ['./article.component.css']
        }),
        __metadata("design:paramtypes", [])
    ], ArticleComponent);
    return ArticleComponent;
}());
export { ArticleComponent };
//# sourceMappingURL=article.component.js.map