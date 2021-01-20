import { Component, OnInit } from '@angular/core';
import { DeveloperService } from "../../Services/developer.service";
import { IHourByDeveloper } from '../../Models/hourByDeveloper.interface';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  providers: [DeveloperService],
})
export class RankingComponent {
  // Developer
  developer: IHourByDeveloper = <IHourByDeveloper>{};
  developers: IHourByDeveloper[];

  constructor(private developerService: DeveloperService) { }

  ngOnInit() {
    this.getRanking();
  }

  //Call the service to get all the developers
  private getRanking() {
    this.developerService.getRanking().subscribe(
      data => this.developers = data,
      error => alert(error),
      () => console.log(this.developers)
    )
  }
}
