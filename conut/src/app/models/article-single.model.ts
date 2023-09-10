import { Article_CommentModel } from "./article-comment.model";
import { User_DisplayModel } from "./user-display.model";

export interface Article_SingleModel {
    id: number;
    title: string;
    description: string;
    htmlContent?: string;
    category: string;
    author: User_DisplayModel;
    createdAt: Date;
    updatedAt?: Date;
    comments: Article_CommentModel[];
    imageUrl: string;
    viewsCount: number;
    commentsCount: number;
}