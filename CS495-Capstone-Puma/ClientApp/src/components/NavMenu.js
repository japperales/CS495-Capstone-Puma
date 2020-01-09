﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';
import M from 'materialize-css/dist/js/materialize.min.js';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
        <Navbar inverse fixedTop fluid collapseOnSelect>
          <Navbar.Header>
            <Navbar.Brand>
              <Link to={'/'}>CS495_Capstone_Puma</Link>
            </Navbar.Brand>
            <Navbar.Toggle />
          </Navbar.Header>
          <Navbar.Collapse>
            <Nav>
              <LinkContainer to={'/tabspage'}>
                <NavItem>
                  <Glyphicon glyph='save-file' /> Puma - Tabs
                </NavItem>
              </LinkContainer>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
    );
  }
}
