import { HttpResponse } from "@angular/common/http";

export type StrictHttpResponse<T> = HttpResponse<T> & {
    body: T;
}