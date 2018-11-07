import React, { Component } from 'react';
import './App.css';
import { Card, CardContent, CardHeader } from "@material-ui/core";
import Navbar from './components/Navbar';
import FormCalc from './components/FormCalc';

class App extends Component {
  state = {
    edicao: true,
  }

  render() {

    const If = (props) => {
      const condition = props.condition || false;
      const positive = props.then || null;
      const negative = props.else || null;
      
      return condition ? positive : negative;
    };

    return (
      <div className="App">
        <Navbar />
        <header className="App-header">
          <Card>
            <CardHeader title="Calculo de juros composto" />
            <CardContent>
              <If
                condition= { this.state.edicao }
                then={ <FormCalc /> }
                else={ <div>Resultado</div>  }
              />
                          
            </CardContent>
          </Card>      
        </header>
      </div>
    );
  }
}

export default App;
