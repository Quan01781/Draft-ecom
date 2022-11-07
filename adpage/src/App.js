// import logo from './logo.svg';
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Sidebar from './components/Sidebar';
import AllCategory from './routes/Category';
import AllProduct from './routes/Product';
import AllCustomer from './routes/Customer';
import AddProductPage from './pages/addProduct';
import UpdateProductPage from './pages/updateProduct';
import { BrowserRouter, Routes, Route } from "react-router-dom";


function App() {

  return (
    <div className="App">
      
      
      <Sidebar />
      <div className='main'>
      <BrowserRouter >  
      <Routes>
        <Route path="/" exact element={<AllCategory />}></Route>
        <Route path="/category" element={<AllCategory />}></Route>
        <Route path="/product" element={<AllProduct />}></Route>
        <Route path="/customer" element={<AllCustomer />}></Route>
        <Route path="/add-product" element={<AddProductPage/>}></Route>
        <Route path="/update-product" element={<UpdateProductPage/>}></Route>
      </Routes>
    </BrowserRouter>
    </div>

    </div>
  );
  }
export default App;