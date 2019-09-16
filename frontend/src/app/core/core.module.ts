import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService, UserService } from './services';
import { AppRouteGuard } from '@app/core/guards';
import { ApiInterceptor, TokenInterceptor } from './interceptors';

@NgModule({
    imports: [],
    providers: [
        AuthService,
        UserService,
        AppRouteGuard,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ApiInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true
        }
    ],
    declarations: []
})
export class AppCoreModule { }
