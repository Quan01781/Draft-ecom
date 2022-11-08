import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Table from 'react-bootstrap/Table';
import {useNavigate} from 'react-router-dom';
import React, { useEffect, useState } from 'react';
import {GetProduct} from '../services/ProductAPI';
import {DeleteProduct} from '../services/ProductAPI';
import '../App.css';

const AllProduct = () => {

    const [products,setProducts] = useState([]);
    const [query,setQuery] = useState("")
    const [deleteShow, setDeleteShow] = useState(false);

    const handleClose = () => {setDeleteShow(false)}
    const handleDeleteShow = () => setDeleteShow(true);

    const navigate =useNavigate();

    useEffect( ()=>{
        loadProducts()
        } 
        ,[]);
        const loadProducts = async () => {
        const result = await GetProduct();
        console.log(result.data)
        setProducts(result.data);}

    const delete_product = async(categoryID)=>{
        const result = await DeleteProduct(categoryID);
        console.log(result)
        }

    const handleDelete = (e)=>{
        const ID = GetProductID();
        if(delete_product(ID)){
            alert("deleted success")
        }else{ alert("failed")}
        }
    
        function setProductID(ID){
        localStorage.setItem("productID",ID);
        }
    
        function GetProductID(){
        var x = localStorage.getItem("productID");
        return x;
        }

        let table = [];
        if(products != null){
         table = products.filter((products)=>products.name.toLowerCase().includes(query)
         )
         .map((product) => (
           <tr key={product.id}>
             <td>{product.id}</td>
             <td>{product.name}</td>
             <td>{product.quantity}</td>
             <td>{product.price}</td>
             <td>{product.categoryID}</td> 
             <td>
                <Button className='edit-button me-2' variant="primary"  onClick={()=>{navigate("/detail-product");setProductID(product.id);}}>Detail</Button>
                <Button className='edit-button me-2' variant="primary" onClick={()=>{navigate("/update-product");setProductID(product.id);}}>Edit</Button>
                <Button className='delete-button' style={{backgroundColor:"red"}} onClick={()=>{handleDeleteShow();setProductID(product.id);}}>Delete</Button>
             </td>
           </tr>    
       
        ));}

        return(
            <>
             <Button variant="primary" onClick={()=>{navigate("/add-product")}}>
                Add Product
            </Button>
            <>  
            <Modal show={deleteShow} onHide={handleClose}>
                <Modal.Header closeButton>
                <Modal.Title>Delete Product</Modal.Title>
                </Modal.Header>
                <Modal.Body>Are you sure want to delete this product</Modal.Body>
                <Modal.Footer>
                <Button variant="secondary" onClick={()=>{handleClose();handleDelete();}}>
                    Yes
                </Button>
                <Button variant="primary" onClick={handleClose}>
                    No
                </Button>
                </Modal.Footer>
            </Modal>
            </>

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
                <th>Name</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>CategoryID</th>
                <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {table}
            </tbody>

            </Table>
            </>
        )
}

export default AllProduct;