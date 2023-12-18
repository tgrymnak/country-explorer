import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(catchError(err => {
			if (404 === err.status) {
				return throwError(() => new Error(err.error?.message || 'Something goes wrong, please contact us'));
			}
			else if (400 === err.status) {
				let msg = err.error || err;
				try {
					if (typeof msg === 'string') {
						if (msg.startsWith('{') && msg.endsWith('}')) {
							msg = Object.values(JSON.parse(msg))[0];
							if (Array.isArray(msg)) {
								msg = msg[0];
							}
						}
					} else if (typeof msg === 'object') {
						msg = Object.values(msg)[0];
						if (Array.isArray(msg)) {
							msg = msg[0];
						}
					}
				} catch {
					msg = 'Wrong request';
				} finally {
					return throwError(() => new Error(msg));
				}
			}
			else if (0 === err.status) {
				return throwError(() => new Error('Server offline, please try again later'));
			}

			const error = err.error?.message || err.error?.title || err.error || err;
			return throwError(() => new Error(error));
		}));
	}
}