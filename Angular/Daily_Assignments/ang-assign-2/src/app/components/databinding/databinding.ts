import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-databinding',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './databinding.html'
})
export class Databinding {
  name: string = '';
  age: number | null = null;
  email: string = '';
}
