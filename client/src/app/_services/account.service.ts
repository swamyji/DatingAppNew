import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../_models/User';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;

  private currentUserSource = new ReplaySubject<User>(1);

  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl+"account/login", model).pipe(
      map((response: User) => {
        const user =response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      } )
    )
  }


// Helper method
setCurrentUser(user: User){
  this.currentUserSource.next(user);
}

//Logout Functionality
logout(){
  localStorage.removeItem('user');
  this.currentUserSource.next(null);
}


// register method

register(model: any){
  return this.http.post(this.baseUrl+"account/register", model).pipe(
    map((user: User) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      }
    })
  );
}
}
