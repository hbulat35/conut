import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Article_PagedModel, OrderDirection } from 'src/app/models';
import { ArticlesService } from 'src/app/services';

@Component({
    selector: 'app-home-articles-corousel',
    templateUrl: './articles-corousel.component.html'
})

export class HomeArticlesCorouselComponent implements OnInit {
    public slickConfig = {
        infinite: true,
        slidesToShow: 1,
        dots: true,
        arrow: false,
        autoplay: true,
        autoplaySpeed: 2000,
        slidesToScroll: 1
    }
    public articles$: Observable<Article_PagedModel[]>;
    constructor(private readonly service: ArticlesService) { }

    ngOnInit() {
        this.articles$ = this.service.GetPaged({
            order: {
                direction: OrderDirection.Descending,
                orderBy: "ViewsCount"
            },
            paging: {
                count: 3,
                page: 0
            }
        })
        .pipe(
            map(x => x.result)
        );
    }
}