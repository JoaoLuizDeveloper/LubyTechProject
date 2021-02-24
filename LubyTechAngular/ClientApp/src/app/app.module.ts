import { NgModule, Component, Pipe, Directive } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
//import { AuthInterceptor } from '../auth/auth.interceptor';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RankingComponent } from './ranking/List/ranking.component';

import { DeveloperComponent } from './developer/List/developer.component';
import { DeveloperCreateUpComponent } from './developer/CreateUpdate/developerCreateUp.component';

import { ProjectComponent } from './project/List/project.component';
import { ProjectCreateUpComponent } from './project/CreateUpdate/projectCreateUp.component';
 
import { NgxPaginationModule } from 'ngx-pagination';
import { CommonModule } from '@angular/common';
//import { NgxMaskModule, IConfig } from 'ngx-mask';
import { AngularFontAwesomeModule } from 'angular-font-awesome';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,

    DeveloperComponent,
    DeveloperCreateUpComponent,

    ProjectComponent,
    ProjectCreateUpComponent,
    RankingComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    NgxPaginationModule,
    AngularFontAwesomeModule,
    //NgxMaskModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent},
      { path: 'developer', component: DeveloperComponent},
      { path: 'developerCreateUp', component: DeveloperCreateUpComponent},
      { path: 'developerCreateUp/:id', component: DeveloperCreateUpComponent},

      { path: 'project', component: ProjectComponent},
      { path: 'projectCreateUp', component: ProjectCreateUpComponent},
      { path: 'projectCreateUp/:id', component: ProjectCreateUpComponent},
      { path: 'ranking', component: RankingComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
