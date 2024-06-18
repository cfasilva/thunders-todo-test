import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {

  const matSnackBar = inject(MatSnackBar);

  return next(req).pipe(
    catchError((err) => {
      const errorMessage = `⚠️ ${err?.message || 'Unknown Error'}`;

      matSnackBar.open(errorMessage, 'Close', { 
        duration: 5000, 
        horizontalPosition: 'end' 
      });
      
      return throwError(() => new Error(err))
    })
  );
  
};
