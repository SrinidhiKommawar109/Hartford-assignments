import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/crud';

@Component({
  selector: 'app-crud',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './crud.html',
  styleUrl: './crud.css'
})
export class Crud {

  employees: Employee[] = [];

  employee: Employee = {
    id: 0,
    name: '',
    email: ''
  };

  isEditMode = false;

  saveEmployee() {
    if (this.isEditMode) {
      const index = this.employees.findIndex(
        e => e.id === this.employee.id
      );
      this.employees[index] = { ...this.employee };
      this.isEditMode = false;
    } else {
      this.employee.id = Date.now();
      this.employees.push({ ...this.employee });
    }
    this.resetForm();
  }

  editEmployee(selected: Employee) {
    this.employee = { ...selected };
    this.isEditMode = true;
  }

  deleteEmployee(id: number) {
    this.employees = this.employees.filter(e => e.id !== id);
  }

  resetForm() {
    this.employee = { id: 0, name: '', email: '' };
  }
}
