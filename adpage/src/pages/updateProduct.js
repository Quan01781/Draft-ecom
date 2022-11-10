import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form';
import {UpdateProduct} from '../services/ProductAPI';
import {AddImage} from '../services/ProductAPI';

export default function UpdateProductPage(){

    const productID=localStorage.getItem("productID");
    
    const [file, setFile] = useState();
    const [fileName, setFileName] = useState("");

    const update_product = async(productID, productName, productQuantity, productPrice, productCategoryID, productImage, productDescription) => {
        const result = await UpdateProduct(productID, productName, productQuantity, productPrice, productCategoryID, productImage, productDescription);
        console.log(result)
      }

    const add_image = async(ImageFile)=>{
        const result = await AddImage(ImageFile);
        console.log(result)
      }

    const saveFile=(e)=>{
        let file=e.target.files[0].name
        console.log(file);
        if(e.target.files[0]){
        setFile(e.target.files[0]);
        setFileName(e.target.files[0].name);}
      }


      const handleUpdate = (e)=>{
        e.preventDefault();
        const formData = new FormData();
        const ID = productID;
        const name = e.target.name.value;
        const quantity = e.target.quantity.value;
        const price = e.target.price.value;
        const categoryID = e.target.categoryID.value;
        const image = fileName;
        const description = e.target.description.value;
        formData.append("formFile", file);
        formData.append("fileName", fileName);
        update_product(ID, name, quantity, price, categoryID, image, description);
        add_image(formData)
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

            <Form.Group controlId="formFile" label="Image" className="mb-3" >
            <Form.Control type="file" style={{width: '50%'}} onChange={saveFile}/>
            </Form.Group>

            <FloatingLabel controlId="floatingTextarea2" label="Description"  className='mb-3' >
                <Form.Control
                as="textarea"
                placeholder="Description"
                style={{ height: '100px', width: '50%'}}
                name="description"
                />
            </FloatingLabel>

            <Button variant="dark" type="submit">
                Update
            </Button>
        </Form>
        </>
    )
}