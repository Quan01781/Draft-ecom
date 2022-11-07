import React from 'react';
import Button from 'react-bootstrap/Button';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form';
import {UpdateProduct} from '../services/ProductAPI';

export default function UpdateProductPage(){

    const productID=localStorage.getItem("productID");
    
    const update_product = async(productID, productName, productQuantity, productPrice, productCategoryID, productDescription) => {
        const result = await UpdateProduct(productID, productName, productQuantity, productPrice, productCategoryID, productDescription);
        console.log(result)
      }

      const handleUpdate = (e)=>{
        e.preventDefault();
        const ID = productID;
        const name = e.target.name.value;
        const quantity = e.target.quantity.value;
        const price = e.target.price.value;
        const categoryID = e.target.categoryID.value;
        const description = e.target.description.value;
        if(update_product(ID, name, quantity, price, categoryID, description)){
          alert("added success")
        }else{ alert("failed")}
      }

    return(
        <>
        <h2>Update Product</h2>
        <Form className='add-category-form' onSubmit={handleUpdate}>
            <FloatingLabel controlId="floatingInput" label="Product name" className="mb-3">
                <Form.Control type="text" placeholder="Product name"  style={{width: '50%'}} name="name"/>
            </FloatingLabel>

            <FloatingLabel controlId="floatingInput" label="Product quantity" className="mb-3">
                <Form.Control type="number" placeholder="Quantity" style={{width: '50%'}} name="quantity"/>
            </FloatingLabel>

            <FloatingLabel controlId="floatingInput" label="Product price" className="mb-3">
                <Form.Control type="number" placeholder="Price" style={{width: '50%'}} name="price"/>
            </FloatingLabel>

            <FloatingLabel controlId="floatingInput" label="CategoryID" className="mb-3">
                <Form.Control type="number" placeholder="CategoryID" style={{width: '50%'}} name="categoryID"/>
            </FloatingLabel>

            <FloatingLabel controlId="floatingTextarea2" label="Description"  className='mb-3' >
                <Form.Control
                as="textarea"
                placeholder="Description"
                style={{ height: '100px', width: '50%'}}
                name="description"
                />
            </FloatingLabel>

            <Button type="submit">
                Add
            </Button>
        </Form>
        </>
    )
}