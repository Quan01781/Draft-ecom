import React, {useEffect, useState} from "react";
import Card from 'react-bootstrap/Card';
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

return (
    <>
    <Card className="detail-category" style={{width: '60%'}}>
    <Card.Header>{product.name}</Card.Header>
      <Card.Body>
        <Card.Text>Price: {product.price}</Card.Text>
        <Card.Text>Description: {product.description}</Card.Text>
        <Card.Text>Created Date: {product.created_at}</Card.Text>
        <Card.Text>Updated Date: {product.updated_at}</Card.Text>
      </Card.Body>
    </Card>
    </>
);
}