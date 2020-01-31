import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import 'bootstrap/dist/css/bootstrap.min.css';





//https://react-bootstrap.github.io/getting-started/introduction/

//https://mdbootstrap.com/education/react/agenda-1-hello-world/



//ReactDOM.render(<h1>Hello World</h1>, document.getElementById('dynamic'));

//ReactDOM.render(<GetLogin />, document.getElementById('root'));

ReactDOM.render(<App />, document.getElementById('root'));

/* function AlertDismissible() {
    const [show, setShow] = useState(true);
  
    return (
      <>
        <Alert show={show} variant="success">
          <Alert.Heading>How's it going?!</Alert.Heading>
          <p>
            Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget
            lacinia odio sem nec elit. Cras mattis consectetur purus sit amet
            fermentum.
          </p>
          <hr />
          <div className="d-flex justify-content-end">
            <Button onClick={() => setShow(false)} variant="outline-success">
              Close me ya'll!
            </Button>
          </div>
        </Alert>
  
        {!show && <Button onClick={() => setShow(true)}>Show Alert</Button>}
      </>
    );
  }
 */  

/* function GetNav(){
  return (<Nav
    activeKey="/home"
    onSelect={selectedKey => alert(`selected ${selectedKey}`)}
  >
    <Nav.Item>
      <Nav.Link href="/home">Home</Nav.Link>
    </Nav.Item>
    <Nav.Item>
      <Nav.Link eventKey="link-1">About me</Nav.Link>
    </Nav.Item>
    <Nav.Item>
      <Nav.Link eventKey="link-2">Nice pictures</Nav.Link>
    </Nav.Item>
  </Nav>);
} */

/* function GetLogin(){
  return(
    <Form>
  <Form.Group controlId="formGroupEmail">
    <Form.Label>Email address</Form.Label>
    <Form.Control type="email" placeholder="Enter email" />
  </Form.Group>
  <Form.Group controlId="formGroupPassword">
    <Form.Label>Password</Form.Label>
    <Form.Control type="password" placeholder="Password" />
  </Form.Group>
  <Button variant="primary">Primary</Button>
</Form>

  )
} */









// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
