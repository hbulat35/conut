import { Injectable } from "@angular/core";
import { HttpClient, HttpResponse } from "@angular/common/http";
import { Observable, filter, map, tap } from "rxjs";
import { Article_SingleModel, PagedQueryParams_Article_FilterModel } from "src/app/models";
import { PagedResult_Article_PagedModel } from "src/app/models/paged-result_article-paged.model";
import { StrictHttpResponse } from "../strinct-http-request";

@Injectable({ providedIn: "root" })
export class ArticlesService {
    constructor(private httpClient: HttpClient) {

    }
    
    public GetSingle(id: number): Observable<Article_SingleModel> {
        return this.httpClient.get(
            `/api/Articles/${id}`
        ).pipe(
            map(r => r as Article_SingleModel)
        );
    }

    public GetPaged(query: PagedQueryParams_Article_FilterModel): Observable<PagedResult_Article_PagedModel> {
        return this.httpClient.post(
            `/api/Articles/search`,
            query
        ).pipe(
            map(r => r as PagedResult_Article_PagedModel)
        );
    }
}