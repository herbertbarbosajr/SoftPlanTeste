/* eslint-disable react/prefer-stateless-function */

import React from 'react';
import NumberFormat from 'react-number-format';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import FormControl from '@material-ui/core/FormControl';
import { Button } from '@material-ui/core';

const styles = theme => ({
  formControl: {
    margin: theme.spacing.unit,
  },
  buttonCalc: {
    marginTop: 10,
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
    mes: '1',
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
          <Button className={classes.buttonCalc} variant="outlined" color="primary">
            Calcular
          </Button> 
        </FormControl>               
      </div>
    );
  }
}

FormCalc.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(FormCalc);