import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShortenPipe } from '../custom_pipes/shorten-pipe';

@Component({
  selector: 'app-pipes',
  imports: [CommonModule,ShortenPipe],
  standalone: true,
  templateUrl: './pipes.html',
  styleUrl: './pipes.css',
})
export class Pipes {
name = 'Angular';
today = new Date();
price = 5000;
value = 25;
student = {
  name:'Srinidhi',
  branch:"aiml",
  age: 21
};
}
