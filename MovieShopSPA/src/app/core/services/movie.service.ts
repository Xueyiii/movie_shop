import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/movieCard';

import {environment} from 'src/environments/environment';
import { Movie } from 'src/app/shared/models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  // Home Component => 
  // Always Angular Service return Observable
  getTopGrossingMovies(): Observable<MovieCard[]> {
    
    return this.http.get<MovieCard[]>(`${environment.apiUrl}movies/toprevenue`);
    // return this.http.get<Moviecard[]>('https://localhost:5681/api/Movies/toprevenue');
    // return this.http.get('https://localhost:5681/api/Movies/toprevenue').pipe(map(resp => resp as Moviecard[]));

    // call our API to get list of top movies
    // HttpClient => XMlHttpRequest 
    // Http Get
    // https://localhost:5001/api/Movies/toprevenue => JSON 
    // convert JSON data to Typescript models and return
    // Http 
    // Database => I/O  async/await Tasks
    // JS async Promises => Observables
    // Obseerver pattern, publish/subsribe pattern
    // YouTube Channel => post videos frequently...get notofications when that channel posts videos
    // Subscribe => 
    // Observables => Only when u subscribe you get notofication=> Lazy...emit multiple values over time...
    // Angular => Observables extensively in the Framework.....
    // ASP.NET COre MS => Tasks async/await


    // rxjs as js LINQ
    // map in JS RXJS => Select
    // Where => filter

  }

  getMovieDetails(id: number): Observable<Movie> {
    // call API methods that returns movie details
    return this.http.get<Movie>(`${environment.apiUrl}movies/${id}`);
    //return this.http.get<Movie>('https://localhost:5681/api/Movies/${id}');
  }
}
