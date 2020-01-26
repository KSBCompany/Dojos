import React from 'react';
import './App.css';
import Shop from './Shop';
import About from './About';
import MyNav from './Nav';

function App() {
  return (
    <div className="App">
      <MyNav/>
      <Shop/>
      <About/>
    </div>
  );
}

export default App;
