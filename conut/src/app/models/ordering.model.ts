export interface SimpleOrderingModel {
    orderBy: string;
    direction: OrderDirection;
}

export interface OrderingModel extends SimpleOrderingModel {
    orderThen?: SimpleOrderingModel[];
}

export enum OrderDirection {
    "Ascending" = 0,
    "Descending" = 1
}