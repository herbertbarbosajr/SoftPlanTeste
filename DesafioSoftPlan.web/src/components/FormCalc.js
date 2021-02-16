/* eslint-disable react/prefer-stateless-function */

import React from 'react';
import NumberFormat from 'react-number-format';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import FormControl from '@material-ui/core/FormControl';
import { Button, CircularProgress } from '@material-ui/core';

const styles = theme => ({
  formControl: {
    margin: theme.spacing.unit,
  },
  buttonCalc: {
    marginTop: 10,
  },
  buttonProgress: {
    //color: green[500],
    position: 'absolute',
    top: '50%',
    left: '50%',
    marginTop: -12,
    marginLeft: -12,
  },
  buttonContent: {
    margin: theme.spacing.unit,
    position: 'relative',
    alignItems: 'center',
  }
});

function NumberFormatCustom(props) {
  const { inputRef, onChange, ...other } = props;
  return (
    <NumberFormat
      {...other}
      getInputRef={inputRef}
      onValueChange={values => {
        onChange({
          target: {
            value: values.value,
          },
        });
      }}      
    />
  );
}

NumberFormatCustom.propTypes = {
  inputRef: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
};

class FormCalc extends React.Component {
 
  state = {
    valorIncial: '0.00',
    mes: '0',
  };

  handleChange = name => event => {
    this.setState({
      [name]: event.target.value,
    });
  };

  render() {  
    const { classes } = this.props;
    const { valorIncial, mes } = this.state;

    return (
      <div>
        <FormControl className={classes.formControl}>
          <TextField
            className={classes.formControl}
            label="Valor Inicial"
            value={valorIncial}
            onChange={this.handleChange('valorIncial')}
            id="valorInicial"
            variant="outlined"            
            InputProps={{
              inputComponent: NumberFormatCustom,
            }}
          /> 

          <TextField
            className={classes.formControl}
            label="Mês"
            id="mes"
            value={mes}
            onChange={this.handleChange('mes')}
            variant="outlined"
            InputProps={{
              inputComponent: NumberFormatCustom,
            }}
          />
          <div className={classes.buttonContent}>
            <Button 
              className={classes.buttonCalc} 
              variant="outlined" 
              color="primary"
              disabled={this.props.isRequest}
              onClick={() => this.props.onCalcular(this.state.valorIncial, this.state.mes)}>
              Calcular              
            </Button>
            {this.props.isRequest && <CircularProgress size={24} className={classes.buttonProgress} />}
          </div>
        </FormControl>               
      </div>
    );
  }
}

FormCalc.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(FormCalc);