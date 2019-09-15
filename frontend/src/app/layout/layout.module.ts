import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppHeaderComponent } from './header/header.component';
import { AppLayoutComponent } from './layout.component';



@NgModule({
  declarations: [
    // Components
    AppLayoutComponent,
    AppHeaderComponent
  ],
  imports: [
    // Modules
    CommonModule
  ],
  providers: [
      // Services
  ],
  exports: [
      // Exported Components
      AppLayoutComponent
  ]
})
export class AppLayoutModule { }
