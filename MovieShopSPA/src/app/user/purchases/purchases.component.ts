import { UserService } from './../../core/services/user.service';
import { Purchases } from './../../shared/models/purchase';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {

  purchases!:Purchases;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getPurchaseMovies().subscribe(
      p=> {
        this.purchases = p
      }
    )
  }



}
