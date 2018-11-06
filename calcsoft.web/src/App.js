import React, { Component } from 'react';
import './App.css';
import { Button, TextField, Card, CardContent } from "@material-ui/core";
import Navbar from './components/Navbar';

class App extends Component {
  render() {
    return (
      <div className="App">
        <Navbar />
        <header className="App-header">
          <p>
            Calculo de Juros, Softplan
          </p>

          <Card>
            <CardContent>
            <form noValidate autoComplete="off">
              <TextField id="valorInicial"
                        label="Valor Inicial"
                        margin="normal"
                        variant="outlined"/>
            </form>
            </CardContent>
          </Card>        

          <Button variant="contained" color="primary">
            Teste
          </Button>
        </header>
      </div>
    );
  }
}

export default App;
