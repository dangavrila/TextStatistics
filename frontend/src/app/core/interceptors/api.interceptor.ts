import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor() { }

  private BACKEND_URL = 'https://daq0fak3z6.execute-api.us-east-2.amazonaws.com/Prod/api';

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const requestUrl = req.url.startsWith('/')
      ? `${this.BACKEND_URL}${req.url}` :
      `${this.BACKEND_URL}/${req.url}`;

    req = req.clone({
      url: requestUrl
    });

    return next.handle(req);
  }
}
