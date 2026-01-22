import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Products } from '../../services/products';
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';
import { Product } from '../../services/productDataType';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './products.html',
  styleUrl: './products.css'
})
export class ProductsComponent implements OnInit {

  productsData= signal< Product[] | undefined>(undefined);

  constructor(private productsService: Products, private cdr: ChangeDetectorRef) {
    console.log('ProductsComponent loaded');
  }
    ngOnInit(): void {
      
      this.productsService.getProducts().subscribe((data) => {
        console.log(data);
        this.productsData.set(data.products);
      });
  }
 }
