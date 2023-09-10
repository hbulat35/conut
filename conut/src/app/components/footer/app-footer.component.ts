import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Article_PagedModel, OrderDirection } from 'src/app/models';
import { ArticlesService } from 'src/app/services';

@Component({
    selector: 'app-footer',
    templateUrl: 'app-footer.component.html',
    styleUrls: ['./app-footer.component.scss']
})
export class AppFooterComponent implements OnInit {
    public recentPosts$: Observable<Article_PagedModel[]>;

    constructor(private readonly apiService:ArticlesService) {}

    ngOnInit() {
        this.recentPosts$ = this.apiService.GetPaged({
            order: {
                orderBy: 'CreatedAt',
                direction: OrderDirection.Descending
            },
            paging: {
                count: 2,
                page: 0
            }
        })
        .pipe(
            map(r => r.result)
        );
    }
}