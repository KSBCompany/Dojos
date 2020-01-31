import React from 'react';
import './App.css';
import {Link} from 'react-router-dom';

function MyNav() {
  const navStyle = {
    color: 'white'
  };


  return (
    <nav>
      <Link style={navStyle} to='/'>
        <h3>This is the page of Stefan Weinschütz</h3>
      </Link>
        <ul className="nav-links">
          <Link style={navStyle} to='/about'>
            <li>About</li>
          </Link>
          <Link style={navStyle} to='/shop'>
            <li>Shop</li>
          </Link>
          <Link style={navStyle} to='/misc'>
            <li>Misc</li>
          </Link>
          <Link style={navStyle} to='/charting'>
          <li>Charting</li>
          </Link>
        </ul>
    </nav>
  );
}

export default MyNav;
