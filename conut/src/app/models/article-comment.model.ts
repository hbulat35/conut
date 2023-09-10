export interface Article_CommentModel {
    id: number;
    authorName: string;
    imageUrl?: string;
    createdAt: Date;
    content: string;
}