import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { productsAPiResponse } from './productDataType';
@Injectable({
  providedIn: 'root',
})
export class Products {
  apiURL = 'https://dummyjson.com/products';
  constructor(private http: HttpClient) {
    console.log('Products service loaded');
  }
  getProducts(){
     return this.http.get<productsAPiResponse>(this.apiURL);
  }
}

