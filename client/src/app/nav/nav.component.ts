import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service'
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountService) { }

  model: any = {}
  // loggedIn: boolean;

  // To stop unnecessary coe, commented the below code
  //currestUser$: Observable<User>;

  ngOnInit(): void {
    // this.getCurrentUser();

  // To stop unnecessary coe, commented the below code
    //this.currestUser$ = this.accountService.currentUser$;
  }

  login(){
   this.accountService.login(this.model).subscribe(response =>{
     console.log(response)
     //this.loggedIn = true;
   }, error => {
     console.log(error)
   })
  }

  logout(){
    this.accountService.logout();
    //this.loggedIn = false;
  }

  // set currentUser in the component
  // getCurrentUser(){
  //   this.accountService.currentUser$.subscribe(user => {
  //     this.loggedIn = !!user;
  //   }, error => {
  //     console.log(error);
  //   });
  // }

  // The above method is not http method and to avoid memory leakages we are stoping the it.

}
