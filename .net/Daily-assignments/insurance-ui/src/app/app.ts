import { Component, Injectable } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


// ✅ Model
export interface InsuranceType {
  id?: number;
  name: string;
  description?: string;
  isActive: boolean;
}


// ✅ Service
@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  private api = 'https://localhost:7086/api/InsuranceTypes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<InsuranceType[]> {
    return this.http.get<InsuranceType[]>(this.api);
  }

  add(data: InsuranceType): Observable<any> {
    return this.http.post(this.api, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.api}/${id}`);
  }
}


// ✅ Component
@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [CommonModule, FormsModule]
})
export class App {

  constructor(private service: PolicyService) {}

  active = 'list';

  // ✅ array instead of signal
  policies: InsuranceType[] = [];

  // form model
  form: InsuranceType = {
    name: '',
    description: '',
    isActive: true
  };

  ngOnInit() {
    this.loadPolicies();
  }

  loadPolicies() {
    this.service.getAll().subscribe({
      next: data => {
        console.log("API Response:", data);
        this.policies = data;  
      },
      error: err => console.error("API ERROR:", err)
    });
  }

  add() {
    if (!this.form.name) return;

    this.service.add(this.form).subscribe(() => {
      this.loadPolicies();

      this.form = {
        name: '',
        description: '',
        isActive: true
      };

      this.active = 'list';
    });
  }

  delete(id: number) {
    this.service.delete(id).subscribe(() => this.loadPolicies());
  }
}