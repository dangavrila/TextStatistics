import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLayoutModule } from '@app/layout';
import { AppPagesModule } from '@app/features';
import { AppCoreModule } from '@app/core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,

    // Core functionality
    AppCoreModule,

    // Feature Module
    AppLayoutModule,
    AppPagesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
