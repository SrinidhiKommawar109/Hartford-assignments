import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  standalone: true,
  templateUrl: './child.html',
  styleUrl: './child.css'
})
export class ChildComponent {

  // Receive parent message
  @Input() parentMessage!: string;

  // Emit message to parent
  @Output() childMessage = new EventEmitter<string>();

  // Emit rating change to parent
  @Output() ratingChanged = new EventEmitter<number>();

  sendToParent(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.childMessage.emit(value);
  }

  onRatingChange(event: Event) {
    const value = Number((event.target as HTMLSelectElement).value);
    this.ratingChanged.emit(value);
  }
}
