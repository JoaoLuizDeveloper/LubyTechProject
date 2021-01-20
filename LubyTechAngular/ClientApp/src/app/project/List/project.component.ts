import { Component, OnInit} from '@angular/core';
import { ProjectService } from '../../Services/project.service';
import { IProject } from '../../Models/project.interface';

@Component({
  selector: 'app-project-component',
  templateUrl: './project.component.html',
  providers: [ProjectService]
})
export class ProjectComponent implements OnInit {
    // Project
    project: IProject = <IProject>{};
    projects: IProject[];
      
  constructor(private projectService: ProjectService) { }
     
  ngOnInit() {
    this.getProjects();    
  }

  // Call the service to get all the projects
  private getProjects() {
    this.projectService.getProjects().subscribe(
      data => this.projects = data,
      error => alert(error)
    );
  }

  //Delete the Project
  delete(project: IProject) {
    if (confirm("You really want to delete this Project? You can't be able to recover it")) {
      this.projectService.deleteProject(project.id)
        .subscribe(response => {
          alert("The Project has been deleted");
          this.getProjects();
        });
    }
  };  
}
