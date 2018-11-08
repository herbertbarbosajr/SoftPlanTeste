import React, { Component } from 'react';
import { Button } from '@material-ui/core';

class FormResult extends Component {

  render(){
    return(
      <div>
        <p>Resultado</p>
        <p>{this.props.result}</p>
        <Button
          variant="outlined" 
          color="primary"
          onClick={this.props.onNovoCalculo}>
          Novo Calculo
        </Button>
      </div>
    );
  }

}

export default FormResult;