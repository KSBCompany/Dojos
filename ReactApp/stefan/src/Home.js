import React from 'react';
import './App.css';
import Table from 'react-bootstrap/Table'

function Home() {
  return (
    <div>
        <Table striped bordered hover variant="dark">
          <thead>
            <tr>
              <th>#</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Username</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>Stefan</td>
              <td>Weinschütz</td>
              <td>King</td>
            </tr>
            <tr>
              <td>2</td>
              <td>Eve</td>
              <td>Weinschütz</td>
              <td>evelknievel</td>
            </tr>
            <tr>
              <td>3</td>
              <td>Cleo</td>
              <td>Weinschütz</td>
              <td>meckerkatze</td>
            </tr>
          </tbody>
        </Table>
    </div>
  );
}

export default Home;
