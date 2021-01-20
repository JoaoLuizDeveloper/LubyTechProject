import { Component, OnInit} from '@angular/core';
import { DeveloperService } from "../../Services/developer.service";
import { ProjectService } from "../../Services/project.service";
import { IDeveloper } from '../../Models/developer.interface';
import { IProject } from '../../Models/project.interface';

@Component({
  selector: 'app-developer-component',
  templateUrl: './developer.component.html',
  providers: [DeveloperService, ProjectService],
})
export class DeveloperComponent implements OnInit  {
    // Developer
    developer: IDeveloper = <IDeveloper>{};
    developers: IDeveloper[];

    // Product
    product: IProject = <IProject>{};
    products: IProject[];

  constructor(private developerService: DeveloperService, private productService: ProjectService) { }

  ngOnInit() {
    this.getDevelopers();
    this.getProducts();   
  }

  //Call the service to get all the developers
  private getDevelopers() {
    this.developerService.getDevelopers().subscribe(
      data => this.developers = data,
      error => alert(error),
      () => console.log(this.developers)

    )
  }

  private getProducts() {
    this.productService.getProjects().subscribe(
      data => this.products = data,
      error => alert(error),
      () => console.log(this.products)
    );
  }

  //Delete the Product
  delete(developer: IDeveloper) {
    if (confirm("You really want to delete this Developer? You can't be able to recover it")) {
      this.developerService.deleteDeveloper(developer.id)
        .subscribe(response => {
          alert("The Developer has been deleted");
          this.getDevelopers();
        });
    }
  };  
}
