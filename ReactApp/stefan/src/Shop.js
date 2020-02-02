import React from 'react';
import './App.css';
import Image from 'react-bootstrap/Image'
import MyClassComponent from './MýClassComponent';

function Shop() {
  return (
    <div>
      <h1>Shop</h1>
      <Image src="Nice.png" fluid/>
      <MyClassComponent/>
    </div>
  );
}

export default Shop;
