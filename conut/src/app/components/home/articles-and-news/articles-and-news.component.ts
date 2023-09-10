import { Component, OnInit } from '@angular/core';
import { Article_PagedModel, OrderDirection, PagedResult_Article_PagedModel, PagingModel } from 'src/app/models';
import { ArticlesService } from 'src/app/services';

@Component({
    selector: 'app-home-articles-and-news',
    templateUrl: 'articles-and-news.component.html'
})

export class HomeArticlesAndNewsComponent implements OnInit {
    public articles: Article_PagedModel[] = [];
    public paging: PagingModel = {
        count: 3,
        page: 1
    };

    constructor(private readonly service: ArticlesService) { }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.service.GetPaged({
            order: {
                orderBy: "ViewsCount",
                direction: OrderDirection.Descending
            },
            paging: this.paging
        }).subscribe(r => {
            this.articles = this.articles.concat(r.result);
            this.paging.page++;
            console.log(this.paging);
        })
    }
}