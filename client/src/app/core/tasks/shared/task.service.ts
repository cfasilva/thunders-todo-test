import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewTask, Task } from './task.model';
import { of } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

  createTask(task: NewTask) {    
    return this.http.post<Task>(`${environment.apiUrl}/api/tasks`, task);
  }

  getTasks() {
    return this.http.get<Task[]>(`${environment.apiUrl}/api/tasks`);
  }
  
  deleteTask(id: number) {
    return this.http.delete(`${environment.apiUrl}/api/tasks/${id}`);
  }

  checkTask(id: number) {
    return this.http.post(`${environment.apiUrl}/api/tasks/${id}/check`, null);
  }

  uncheckTask(id: number) {
    return this.http.post(`${environment.apiUrl}/api/tasks/${id}/uncheck`, null);
  }

}
