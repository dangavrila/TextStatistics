import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseResponse, BaseEntity } from '@app/models';

export class BaseHttpService<TResponse extends BaseResponse> {
    constructor(private client: HttpClient, private url: string) { }
}
