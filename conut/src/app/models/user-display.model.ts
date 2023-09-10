import { FullName } from "./fullname.model";
import { Link_DisplayModel } from "./link-display.model";

export interface User_DisplayModel {
    fullName: FullName;
    imageUrl: string;
    signImageUrl?: string;
    description: string;
    professions: string;
    links: Link_DisplayModel[];
    rate: number;
}