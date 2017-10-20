import { Injectable, Inject } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class ProjectsService {

  url: string ="http://localhost:8089/api/Projects";
  constructor(private http:Http) { }

  GetProjects(){
    return this.http.get(this.url)
        .map(res=>res.json());
  }
 
}
