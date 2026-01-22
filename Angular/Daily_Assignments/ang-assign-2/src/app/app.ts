import { Component, signal } from '@angular/core';
import { EmployeeComponent } from './components/employee/employee';
import { Databinding } from './components/databinding/databinding';
import { Crud } from './components/crud/crud';
import { CalciComponent } from './components/calci/calci';
import { CommonModule } from '@angular/common';
import { Pipes } from './components/pipes/pipes';
import { ShortenPipe } from './components/custom_pipes/shorten-pipe';
import { ReactiveForm } from './components/reactive-form/reactive-form';
import { TodoList } from './components/todolist/todolist';
import { ProductsComponent } from './components/products/products';
import { ParentComponent } from './components/parent/parent';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    EmployeeComponent,
    Databinding,
    Crud,
    CalciComponent,
    CommonModule,
    Pipes,
    ShortenPipe,
    ReactiveForm,
    TodoList,
    ProductsComponent,
    ParentComponent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

}
