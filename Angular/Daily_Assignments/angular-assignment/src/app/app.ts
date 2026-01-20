import { Component } from '@angular/core';
import { EmployeeComponent } from './components/employee/employee';
import { Databinding } from './components/databinding/databinding';
import { Crud } from './components/crud/crud';
import { CalciComponent } from './components/calci/calci';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    EmployeeComponent,
    Databinding,
    Crud,
    CalciComponent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}
