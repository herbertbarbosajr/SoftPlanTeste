import React, { Component } from 'react';
import { PropTypes } from "prop-types";
import { AppBar, Toolbar, Typography, withStyles } from "@material-ui/core";

const styles = {
  iconMenu: {
    marginLeft: -12,
    marginRight: 20,
  }
};

class Navbar extends Component {
  render(){
    return (
      <AppBar position="static">
        <Toolbar>
          <Typography variant="title" color="inherit">
            CalcSoft - Calculadora de Juros
          </Typography>
        </Toolbar>
      </AppBar>
    );
  }
}

Navbar.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles) (Navbar);