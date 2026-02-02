import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatuscolorPipe } from '../statuscolor-pipe'; // path matters!

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, StatuscolorPipe],
  templateUrl: './order.html'
})
export class OrderComponent {
  orderStatus: string[] = ['Pending', 'Shipped', 'Delivered', 'Canceled','Unknown'];
}
