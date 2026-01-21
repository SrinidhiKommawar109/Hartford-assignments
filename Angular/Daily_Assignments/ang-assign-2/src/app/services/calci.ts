import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalciService {

  add(a: number, b: number): number {
    return a + b;
  }
  sub(a: number, b: number): number {
    return a - b;
  }
  mul(a: number, b: number): number {
    return a * b;
  }
  div(a: number, b: number): number {
    return b !== 0 ? a / b : 0;
  }
}
