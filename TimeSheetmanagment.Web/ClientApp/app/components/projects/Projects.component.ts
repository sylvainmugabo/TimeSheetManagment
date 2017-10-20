import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app-projects',
    templateUrl: 'projects.component.html',
    styleUrls: ['./projects.component.css']
    
})
export class ProjectsComponent {
    public projects: IProjects[];
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Projects').subscribe(result => {
            this.projects = result.json() as IProjects[];
        }, error => console.log(error));
    }

}
interface IProjects {
    id: number;
    description: string;
   
}