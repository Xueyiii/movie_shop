import { MovieCard } from "./movieCard";

export interface Purchases {
    userId: number;
    totalMoviesPurchased: number;
    purchasedMovies: MovieCard[];
}