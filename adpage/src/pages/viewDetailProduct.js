import React, {useEffect, useState} from "react";
import {GetProductByID} from '../services/ProductAPI'

export default function DetailProduct(){

const [product,setProduct] = useState([]);
var productID = localStorage.getItem("productID");

useEffect( ()=>{
loadProduct(productID)
} 
,[]);
const loadProduct = async (productID) => {
const result = await GetProductByID(productID);
console.log(result.data)
setProduct(result.data);}

const url = "https://localhost:7243/wwwroot/upload/image/product/" + product.image;
return (

    <>
    <div className="detail-category card mb-3" style={{width: '60%'}}>
  <div className="row g-0">
    <div className="col-md-4">
      <img src={url} className="img-fluid rounded-start" alt="..."/>
    </div>
    <div className="col-md-8">
      <div className="card-body">
        <h5 className="card-title">{product.name}</h5>
        <p className="card-text">Price: {product.price}</p>
        <p className="card-text"><small class="text-muted"><b>Description:</b> {product.description}</small></p>
        <p className="card-text"><small class="text-muted"><b>Created Date:</b> {product.created_at}</small></p>
        <p className="card-text"><small class="text-muted"><b>Updated Date:</b> {product.updated_at}</small></p>
      </div>
    </div>
  </div>
</div>
    </>
);
}