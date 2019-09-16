import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppHomeComponent } from './home/home.component';
import { AppLoginComponent } from './login/login.component';
import { PagesRoutingModule } from './pages.router';


@NgModule({
  declarations: [
    AppHomeComponent,
    AppLoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PagesRoutingModule
  ]
})
export class AppPagesModule { }
