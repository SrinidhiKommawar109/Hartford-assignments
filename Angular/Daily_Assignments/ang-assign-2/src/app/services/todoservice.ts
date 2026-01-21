import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private baseUrl = 'https://jsonplaceholder.typicode.com/todos';

  constructor(private http: HttpClient) {}

  // READ (all)
  getTodos() {
    return this.http.get<any[]>(this.baseUrl);
  }

  // READ (by id)
  getTodoById(id: number) {
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  // CREATE
  addTodo(todo: any) {
    return this.http.post<any>(this.baseUrl, todo);
  }

  // UPDATE
  updateTodo(id: number, todo: any) {
    return this.http.put<any>(`${this.baseUrl}/${id}`, todo);
  }

  // DELETE
  deleteTodo(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
