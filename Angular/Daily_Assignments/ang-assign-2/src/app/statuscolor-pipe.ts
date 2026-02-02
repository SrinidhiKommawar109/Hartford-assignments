import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statuscolor',
  standalone : true
})
export class StatuscolorPipe implements PipeTransform {

  transform(status:string): string {
    if(!status) return 'gray';
    switch(status.toLowerCase()) {
      case 'pending':
        return 'orange';
        case 'shipped':
        return 'blue';
      case 'delivered':
        return 'green'; 
      case 'canceled':
        return 'red';
      default:
        return 'gray';
    }
  }

}
