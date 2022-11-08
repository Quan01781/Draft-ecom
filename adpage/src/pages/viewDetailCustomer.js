import React, {useEffect, useState} from "react";
import Card from 'react-bootstrap/Card';
import {GetCustomerByID} from '../services/CustomerAPI'

export default function DetailCustomer(){

const [customer,setCustomer] = useState([]);
var customerID = localStorage.getItem("customerID");

useEffect( ()=>{
loadCustomer(customerID)
} 
,[]);
const loadCustomer = async (customerID) => {
const result = await GetCustomerByID(customerID);
console.log(result.data)
setCustomer(result.data);}

return (
    <>
    <Card className="detail-category" style={{width: '60%'}}>
    <Card.Header>{customer.first_Name} {customer.last_Name}</Card.Header>
      <Card.Body>
        <Card.Text>Address: {customer.address}</Card.Text>
        <Card.Text>Email: {customer.email}</Card.Text>
        <Card.Text>Phone: {customer.phone}</Card.Text>
        <Card.Text>Created Date:</Card.Text>
      </Card.Body>
    </Card>
    </>
);
}