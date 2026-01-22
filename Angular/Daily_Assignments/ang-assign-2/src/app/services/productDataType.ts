export interface productsAPiResponse {
    products: Product[];
}

export  interface Product {
  id: number;
  title: string;
  description: string;
  category: string;
  price: number;
  discountPercentage: number;
  rating: number;
  stock: number;
  tags: string[];
  brand?: string; // optional (not present in groceries)
  sku: string;
  weight: number;
  dimensions: object;
  warrantyInformation: string;
  shippingInformation: string;
  availabilityStatus: string;
  reviews: [];
  returnPolicy: string;
  minimumOrderQuantity: number;
  meta: object;
  images: string[];
  thumbnail: string;
}
export interface Dimensions {
  width: number;
  height: number;
  depth: number;
}
