import React, {Component} from 'react';
import Form from 'react-bootstrap/Form'



/*
In this example I learned that a class component must be used if I
want to use state. With the function notation this is not possible.
*/
class MyClassComponent extends Component{


state = {
  stringInsideState: "State A",
  number: 0
}

  //When I want to change the state I need to use the setState function.
  //It is not allowed to set the state directly.
  //With setState React uses the virtual-DOM to make the changes.
  //SetState is a async function.
  handleClick = () => {
    if(this.state.stringInsideState === "State A")
      this.setState({stringInsideState: "State B"})
      else
      this.setState({stringInsideState: "State A"})
  }

  increaseNumber = () => {
    this.setState({number: this.state.number + 1})
  }



  render()
  {
    return(
      <div>
        <br/>
        <button onClick={this.handleClick}>Change the state with this button!</button>
        <div>Text from state: {this.state.stringInsideState}</div>
        <br/>
        <button onClick={this.increaseNumber}>Increase the number with this button!</button>
        <div>Number from state: {this.state.number}</div>
      </div>
    ) 
  }

}

export default MyClassComponent;
