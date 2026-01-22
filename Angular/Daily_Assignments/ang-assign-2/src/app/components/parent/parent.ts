import { Component } from '@angular/core';
import { ChildComponent } from '../child/child';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [ChildComponent],
  templateUrl: './parent.html',
  styleUrl: './parent.css'
})
export class ParentComponent {
  messageToChild = 'Hello Child';
  messageFromChild = '';
  childRating = 0; // store rating from child

  // Receive text from child
  receiveFromChild(message: string) {
    this.messageFromChild = message;
  }

  // Receive rating from child
  updateRating(rating: number) {
    this.childRating = rating;
  }

  // Update message to child manually
  updateMessageToChild(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.messageToChild = value;
  }
}
