import { Article_FilterModel } from "./article-filter.model";
import { OrderingModel } from "./ordering.model";
import { PagingModel } from "./paging.model";

export interface PagedQueryParams_Article_FilterModel {
    filter?: Article_FilterModel;
    paging?: PagingModel;
    order?: OrderingModel;
}