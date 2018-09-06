import { Article } from '../models/article.model';
import { data } from '../data/seed';
var ArticleData = /** @class */ (function () {
    function ArticleData() {
    }
    ArticleData.prototype.getData = function () {
        var articles = [];
        for (var i = 0; i < data.length; i++) {
            articles[i] = new Article(data[i].title, data[i].description, data[i].author, data[i].imageUrl);
        }
        return articles;
    };
    return ArticleData;
}());
export { ArticleData };
;
//# sourceMappingURL=data.js.map