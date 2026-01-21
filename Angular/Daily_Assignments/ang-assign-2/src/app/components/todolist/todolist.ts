import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService } from '../../services/todoservice';

@Component({
  selector: 'app-todolist',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './todolist.html',
  styleUrl: './todolist.css',
})
export class TodoList {
  todos: any[] = [];

  newTodoTitle = '';
  selectedTodo: any = null;

  constructor(private todoService: TodoService) {}

  // READ
  getTodoData() {
    this.todoService.getTodos().subscribe(res => {
      this.todos = res.slice(0, 10);
    });
  }

  // CREATE
  addTodo() {
    if (!this.newTodoTitle.trim()) return;

    const todo = {
      title: this.newTodoTitle,
      completed: false,
    };

    this.todoService.addTodo(todo).subscribe(res => {
      this.todos.unshift(res);
      this.newTodoTitle = '';
    });
  }

  // EDIT (LOAD DATA)
  editTodo(todo: any) {
    this.selectedTodo = { ...todo }; // ✅ CLONE (IMPORTANT)
  }

  // UPDATE
  updateTodo() {
    this.todoService
      .updateTodo(this.selectedTodo.id, this.selectedTodo)
      .subscribe(() => {
        const index = this.todos.findIndex(
          t => t.id === this.selectedTodo.id
        );
        this.todos[index] = { ...this.selectedTodo };
        this.selectedTodo = null;
      });
  }

  // DELETE
  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.todos = this.todos.filter(todo => todo.id !== id);
    });
  }

  // SHOW
  showTodo(todo: any) {
    alert(`Title: ${todo.title}\nStatus: ${todo.completed}`);
  }
}
