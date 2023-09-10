import { Article_PagedModel } from "./article-paged.model";

export interface PagedResult_Article_PagedModel {
    total: number;
    result: Article_PagedModel[];
}