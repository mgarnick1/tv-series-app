import { NetworkLogo } from "./network-logos.model";

export interface TVSeries {
    id: number,
    name: string;
    showImage: string;
    description: string;
    rating: number,
    userId: string;
    genre: string;
    networkId: number;
    networkLogoUrl: string;
    networkName: string;
}