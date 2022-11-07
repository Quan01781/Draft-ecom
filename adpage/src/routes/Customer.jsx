import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import Table from 'react-bootstrap/Table';
import React, { useEffect, useState } from 'react';
import {GetCustomer} from '../services/CustomerAPI';
import '../App.css';

const AllCustomer= ()=>{

    const [customers,setCustomers] = useState([]);
    const [query,setQuery] = useState("")



    useEffect( ()=>{
        loadCustomers()
        } 
        ,[]);
        const loadCustomers = async () => {
        const result = await GetCustomer();
        console.log(result.data)
        setCustomers(result.data);}


    let table = [];
    if(customers != null){
        table = customers.filter((customers)=>customers.first_Name.toLowerCase().includes(query))
        .map((customer) => (
        <tr key={customer.id}>
            <td>{customer.id}</td>
            <td>{customer.first_Name}</td>
            <td>{customer.last_Name}</td>
            <td>{customer.address}</td>
            <td>{customer.email}</td>
            <td>{customer.phone}</td>
            <td><Button>Detail</Button></td>
        </tr>    
    
    ));}

    return(
<div>
        <input 
        type="text"
        placeholder='Search'
        className='search'
        onChange={(e) => setQuery(e.target.value)}
      />
        <Table striped hover> 
        <thead>
          <tr>
            <th>ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Address</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {table}
        </tbody>
      
      </Table>
</div>
    )
}

export default AllCustomer;