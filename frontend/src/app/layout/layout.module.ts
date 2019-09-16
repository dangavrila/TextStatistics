import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppHeaderComponent } from './header/header.component';
import { AppFooterComponent } from './footer/footer.component';
import { AppLayoutComponent } from './layout.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    // Components
    AppLayoutComponent,
    AppHeaderComponent,
    AppFooterComponent
  ],
  imports: [
    // Modules
    CommonModule,
    RouterModule
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
