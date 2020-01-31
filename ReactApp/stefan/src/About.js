import React from 'react';
import './App.css';
import Button from 'react-bootstrap/Button'




function About() {

  function handleClick(e) {
    e.preventDefault();
    console.log('The link was clicked.');
    document.getElementById('myniceid').innerHTML = 'Changed Text';

    //fetch('api.json').then(response => {
    //  console.log(response);
    //  return response.json();
    //}).then(jsonresponse => {
    //  console.log(jsonresponse);
  //    document.getElementById('myniceid').innerHTML = jsonresponse.response.tex;
    //});
  }

  return (
    <div>
      <Button onClick={handleClick} variant="primary">Primary</Button>
      <h1 id  ="myniceid">About page!</h1>
    </div>
  );
}


export default About;
