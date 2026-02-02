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
import { StatuscolorPipe } from './statuscolor-pipe';
import { OrderComponent } from './order/order';

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
    StatuscolorPipe,
    ReactiveForm,
    TodoList,
    ProductsComponent,
    ParentComponent,
    OrderComponent,
    StatuscolorPipe


  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

}
