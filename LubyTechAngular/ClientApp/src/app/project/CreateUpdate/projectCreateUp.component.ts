import { Component, OnInit} from '@angular/core';
import { ProjectService } from '../../Services/project.service';
import { IProject } from '../../Models/project.interface';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-projectCreateUp-component',
  templateUrl: './projectCreateUp.component.html',
  providers: [ProjectService]
})
export class ProjectCreateUpComponent implements OnInit {

  // Project
  project: IProject = <IProject>{};
  projects: IProject[];

  //Forms Variables
  formLabel: string;
  isEditMode: boolean = false;
  form: FormGroup;

  constructor(private projectService: ProjectService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.form = fb.group({
      "name": ["", Validators.required],
      "description": ["", Validators.required],
      "created": [""],
    });
    this.formLabel = "Create Project";
  }

  ngOnInit() {
    this.route.params.subscribe(parametros => {
      if (parametros['id']) {
        this.projectService.getProjectById(parametros['id']).subscribe(response => {
          this.edit(response);
        });
      }
    });
  }
  
  onSubmit() {
    this.project.name = this.form.controls["name"].value;
    this.project.description = this.form.controls["description"].value;

    //Create and Update
    if (this.isEditMode) {
      this.project.created = this.form.controls["created"].value;
      this.projectService.updateProject(this.project)
        .subscribe(response => {
          alert("The Project has been updated");
          this.form.reset();
          this.formLabel = "Create Project";
        });
    } else {
      this.project.created = new Date();
      this.projectService.saveProject(this.project)
        .subscribe(response => {
          alert("The Project has been created");
          this.form.reset();
          this.formLabel = "Create Project";
        });
    }
  };

  //Update the Project
  edit(projectForm: IProject) {
    this.formLabel = "Update Project";
    this.isEditMode = true;
    this.project = projectForm;
    this.form.get("name")!.setValue(projectForm.name);
    this.form.get("description")!.setValue(projectForm.description);

    this.form.get("created")!.setValue(projectForm.created);
  };

  cancel() {
    this.project = <IProject>{};
    this.form.get("name")!.setValue('');
    this.form.get("description")!.setValue('');
  };
}
