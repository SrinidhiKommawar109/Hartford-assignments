import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CalciService } from '../../services/calci';

@Component({
  selector: 'app-calci',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calci.html',
  styleUrl: './calci.css'
})
export class CalciComponent {

  n1 = 0;
  n2 = 0;
  result = 0;

  constructor(private calciService: CalciService) {}

  add() {
    this.result = this.calciService.add(this.n1, this.n2);
  }
  sub() {
    this.result = this.calciService.sub(this.n1, this.n2);
  }
  mul() {
    this.result = this.calciService.mul(this.n1, this.n2);
  }
  div() {
    this.result = this.calciService.div(this.n1, this.n2);
  }
}
