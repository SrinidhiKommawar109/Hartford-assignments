import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'highlight',
  standalone: true
})
export class HighlightPipe implements PipeTransform {
  transform(value: string, searchTerm: string): string {
    if (!value || !searchTerm) return value;
    
    const regex = new RegExp(`(${searchTerm})`, 'gi');
    return value.replace(regex, '<mark style="background-color: #FFD700; color: #000; padding: 2px 4px; border-radius: 3px;">$1</mark>');
  }
}
