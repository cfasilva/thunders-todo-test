import { Component } from '@angular/core';
import { TaskComponent } from './core/tasks/task/task.component';
import { ToolbarComponent } from './core/components/toolbar/toolbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TaskComponent, ToolbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
}
