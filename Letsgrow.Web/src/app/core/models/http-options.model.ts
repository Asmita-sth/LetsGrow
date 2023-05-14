import { HttpParams, HttpHeaders } from "@angular/common/http";

export interface AppHttpOptions {
    headers?: HttpHeaders | {
        [header: string]: string | string[];
    };
    observe?: any;
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: any;
    withCredentials?: boolean;
    notCamalizedJson?: boolean;
}
