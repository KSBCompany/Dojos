import React, {Component} from 'react';
import './App.css';

import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official'
import Form from 'react-bootstrap/Form'



class Charting extends Component{


  state = {
    series: [
      {
        name: 'Curve1',
        data: [500, 490, 450, 420, 350, 200]
      },
      {
        name: 'Curve2',
        data: [600, 550, 490, 400, 200, 50]
      }
    ]
  }


  render(){
    return (
      <div>
        <br/>
        <Form>
          <Form.Group controlId="exampleForm.ControlTextarea1">
            <Form.Label>Change the curve here (Not implemented):</Form.Label>
            <Form.Control ref={this.textInput} as="textarea" rows="10" />
          </Form.Group>
        </Form>
        <HighchartsReact highcharts={Highcharts} options={this.state} />
      </div>
    );
  }
  

}


export default Charting;
