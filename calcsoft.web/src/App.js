import React, { Component } from 'react';
import './App.css';
import { Card, CardContent, CardHeader } from "@material-ui/core";
import Navbar from './components/Navbar';
import FormCalc from './components/FormCalc';
import FormResult from './components/FormResult';
import swal from "@sweetalert/with-react";

class App extends Component {
  state = {
    process: false,
    edicao: true,
    resultado: 0.0,
    valorInicial: 0.0,
    mes: 0,
  }

  async callCalcApi(params) {
    var url = new URL(process.env.URL_API + "/Juros/calculajuros");
    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    const response = await fetch(url);
    const body = await response.json();
    if (response.status !== 200) throw Error(body.message);

    return body;
  }

  message(type, title, menssage){
    swal({
      title: title,
      text: menssage,
      buttons: {
        ok: true,
      },
      icon: type,
      timer: 6000
    });
  }

  onCalcular(valorInicial, mes){
    if (!this.state.process){
      if (!valorInicial || valorInicial <= 0.00){
        this.message("warning", 'Aviso', 'Informe um Valor Inicial maior que 0.00!');
        return;
      }

      if (!mes || mes <= 0){
        this.message("warning", 'Aviso','Informe um mês maior que 0!');
        return;
      }
      
      var params = { valorInicial: valorInicial, meses: mes };

      this.setState({
        process: true,
      });

      this.callCalcApi(params)
        .then(res => this.setState({
          resultado: res.resultado,
          edicao: false,
        }))
        .catch(err => {
          this.message('error', 'Erro', `Erro de conexão com a Api: ${err.message}`);
        })
        .finally(() =>{
          this.setState({
            process: false,
          });
        });
    }
  }

  onNovoCalculo(e){
    this.setState({
      edicao: true,
      resultado: 1.0,
    })
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
            <CardHeader className="CardTitle" title="Calculo de juros composto" />
            <CardContent className="CardContent">
              <If
                condition= { this.state.edicao }
                then={ <FormCalc
                          onCalcular={this.onCalcular.bind(this)}
                          process={this.state.process} /> }
                else={ <FormResult
                          result={this.state.resultado} 
                          onNovoCalculo={this.onNovoCalculo.bind(this)} />  }
              />
                          
            </CardContent>
          </Card>      
        </header>
      </div>
    );
  }
}

export default App;
