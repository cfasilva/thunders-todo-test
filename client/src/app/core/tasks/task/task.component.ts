import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxChange, MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { animate, query, state, style, transition, trigger } from '@angular/animations';
import { DialogData } from '../../shared/dialog/dialog-data.model';
import { DialogComponent } from '../../shared/dialog/dialog.component';
import { NewTask, Task } from '../shared/task.model';
import { TaskService } from '../shared/task.service';

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatCheckboxModule, MatIconModule],
  templateUrl: './task.component.html',
  styleUrl: './task.component.scss',
  animations: [
    trigger('openClose', [
      transition(":leave", [
        animate("500ms ease-in-out", style({ height: 0, opacity: 0 }))
      ]),
      transition(":enter", [
        style({ height: 0, opacity: 0 }),
        animate("500ms ease-in-out", style({ height: '40px', opacity: 1 }))
      ])
    ])
  ]
})
export class TaskComponent implements OnInit {

  newTask: NewTask;
  todoList: Task[];

  get checkedList() {
    return this.todoList.filter(x => x.checked);
  }

  get uncheckedList() {
    return this.todoList.filter(x => !x.checked);
  }

  readonly dialog = inject(MatDialog);

  constructor(private service: TaskService) {
    this.newTask = { title: '' }
    this.todoList = [];
  }

  ngOnInit(): void {
    this.getTasks();
  }

  private getTasks() {
    this.service.getTasks().subscribe(tasks => {
      this.todoList = tasks;
    });
  }

  onSubmit() {
    if (this.newTask.title) {
      this.service.createTask(this.newTask).subscribe(task => {
        this.todoList.push(task);
        this.newTask.title = '';
      })
    }
  }

  onCheckboxChange(event: MatCheckboxChange, task: Task) {
    if (event.checked) {
      this.service.checkTask(task.id).subscribe({
        error: () => task.checked = !event.checked
      });
    }
    else {
      this.service.uncheckTask(task.id).subscribe({
        error: () => task.checked = !event.checked
      });
    }
  }

  openDialogDelete(task: Task) {
    const dialogData: DialogData = {
      title: 'Delete task',
      content: `Would you like to delete "${task.title}"?`,
      cancelText: 'Cancel',
      acceptText: 'Delete',
    }
    
    const dialogRef = this.dialog.open(DialogComponent, {
      data: dialogData
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.delete(task.id);
      }
    })
  }

  private delete(id: number) {
    this.service.deleteTask(id).subscribe(() => {
      this.todoList = this.todoList.filter(x => x.id !== id);
    })
  }

}
