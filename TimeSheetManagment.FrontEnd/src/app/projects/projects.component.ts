import { Component, OnInit } from '@angular/core';
import { ProjectsService } from '../projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  private Projects:any[];
  constructor(private service: ProjectsService) { }

  ngOnInit() {
    this.service.GetProjects()
    .subscribe(projects => {
      this.Projects = projects;
    });

  }

}
