import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppHomeComponent } from './home/home.component';
import { AppLoginComponent } from './login/login.component';

const pageRoutes: Routes = [
    {
        path: '',
        component: AppHomeComponent
    },
    {
        path: 'login',
        component: AppLoginComponent
    }
];

@NgModule({
        imports: [
            RouterModule.forChild(pageRoutes)
        ],
        exports: [
            RouterModule
        ]
})
export class PagesRoutingModule { }
