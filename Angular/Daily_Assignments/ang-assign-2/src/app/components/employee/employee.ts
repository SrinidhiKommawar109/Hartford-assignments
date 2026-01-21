// src/app/components/employee/employee.ts
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [FormsModule, CommonModule, DatePipe],
  templateUrl: './employee.html',
  styleUrls: ['./employee.css'],  // <-- fixed typo
})
export class EmployeeComponent {

  employees: Employee[] = [
    {
      id: 1,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      email: 'mark@pragimtech.com',
      dateOfBirth: new Date('1988-10-25'),
      department: 'IT',
      isActive: true,
      photoPath: 'jack.jpeg'
    },
    {
      id: 2,
      name: 'Mary',
      gender: 'Female',
      contactPreference: 'Phone',
      phoneNumber: 2345978640,
      dateOfBirth: new Date('1979-11-20'),
      department: 'HR',
      isActive: true,
      photoPath: 'mark.jpeg'
    },
    {
      id: 3,
      name: 'John',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 5432978640,
      dateOfBirth: new Date('1976-03-25'),
      department: 'IT',
      isActive: false,
      photoPath: 'mark.png'
    }
  ];

}
