import React from 'react';
import './App.css';
import Shop from './Shop';
import About from './About';
import MyNav from './Nav';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import Home from './Home';

function App() {
  return (
    <Router>
      <div className="App">
        <MyNav/>
        <Switch>
          <Route path="/" exact component={Home}/>
          <Route path="/about" component={About} />
          <Route path="/shop" component={Shop} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
