import { MovieCard } from "./movieCard";
export interface Favorite {
    id: number;
    movieId: number;
    userId: number;
    favoriteMovies: MovieCard[];
}