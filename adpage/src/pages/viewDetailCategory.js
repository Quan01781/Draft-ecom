import React, {useEffect, useState} from "react";
import Card from 'react-bootstrap/Card';
import {GetCategoryByID} from '../services/CategoryAPI'

export default function DetailCategory(){

const [category,setCategory] = useState([]);
var productID = localStorage.getItem("categoryID");

useEffect( ()=>{
loadCategory(productID)
} 
,[]);
const loadCategory = async (productID) => {
const result = await GetCategoryByID(productID);
console.log(result.data)
setCategory(result.data);}

return (
    <>
    <Card className="detail-category" style={{width: '60%'}}>
    <Card.Header>{category.name}</Card.Header>
      <Card.Body>
        <Card.Text>Description: {category.description}</Card.Text>
        <Card.Text>Created Date: {category.created_at}</Card.Text>
        <Card.Text>Updated Date: {category.updated_at}</Card.Text>
      </Card.Body>
    </Card>
    </>
);
}