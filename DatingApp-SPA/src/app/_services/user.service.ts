import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { identifierModuleUrl } from '@angular/compiler';

/*
const httpOptions = {
   headers: new HttpHeaders({
  Authorization: 'Bearer ' + localStorage.getItem('token')
   })
 };
*/

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

}