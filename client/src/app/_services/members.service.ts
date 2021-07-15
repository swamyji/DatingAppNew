import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment.prod';
import { Member } from '../_models/member';
import { Observable } from 'rxjs';

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer '+JSON.parse(localStorage.getItem('user')).token
//   })
// }

@Injectable({
  providedIn: 'root'
})

export class MembersService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMemebers() {
   return this.http.get<Member[]>(this.baseUrl+'users')
  }

  getMember(username: string){
    return this.http.get<Member>(this.baseUrl+'users/'+username)
  }

}
