import { Favorite } from './../../shared/models/favorite';
import { environment } from 'src/environments/environment';
import { Purchases } from './../../shared/models/purchase';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getPurchaseMovies():Observable<Purchases>{
    return this.http.get<Purchases>(`${environment.apiUrl}/user/purchases`);
  }

  getFavoriteMovies():Observable<Favorite>{
    return this.http.get<Favorite>(`${environment.apiUrl}/user/favorites`);
  }
}
