import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article_PagedModel, Article_SingleModel, OrderDirection } from 'src/app/models';
import { ArticlesService } from 'src/app/services';

@Component({
    selector: 'app-article-page',
    templateUrl: 'article.component.html'
})

export class ArticlePageComponent implements OnInit {
    public article: Article_SingleModel;
    private readonly articleId: number;
    public alsoLikePosts: Article_PagedModel[];

    constructor(
        private readonly service: ArticlesService,
        route: ActivatedRoute) {
        this.articleId = route.snapshot.params['id'];
    }

    async ngOnInit() {
        this.article = await this.service.GetSingle(this.articleId).toPromise();
        this.alsoLikePosts = (await this.service.GetPaged({
                filter: {
                    category: this.article.category
                },
                order: {
                    orderBy: "ViewsCount",
                    direction: OrderDirection.Descending
                },
                paging: {
                    count: 3,
                    page: 1
                }
            }).toPromise()).result;
    }
}