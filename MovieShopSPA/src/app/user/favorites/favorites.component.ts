import { UserService } from './../../core/services/user.service';
import { Favorite } from './../../shared/models/favorite';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {

  favorite!: Favorite;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getFavoriteMovies().subscribe(
      f=> {
        this.favorite = f
      }
    )

  }

}
