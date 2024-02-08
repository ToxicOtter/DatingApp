import { Photo } from "./photo";

export interface Root {
    id: number;
    userName: string;
    photoUrl: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    gender: string;
    lookingFor: string;
    interests: string;
    city: string;
    country: string;
    photos: Photo[];
}