import { User_DisplayModel } from "./user-display.model";

export interface Article_PagedModel {
    id: number;
    title: string;
    shortDescription: string;
    author: User_DisplayModel;
    createdAt: Date;
    updatedAt?: Date;
    imageUrl: string;
    viewsCount: number;
    commentsCount: number;
    category: string;
}