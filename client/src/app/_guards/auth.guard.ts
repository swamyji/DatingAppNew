import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toast: ToastrService) {}
  canActivate(): Observable<boolean> {

    return this.accountService.currentUser$.pipe(
      map(user =>{
        if (user) return true;
        this.toast.error('You are not allowed..!')
      })
    );
  }

}
