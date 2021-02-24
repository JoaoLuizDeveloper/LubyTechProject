import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { Logo } from '../../image/home.png';
import './NavMenu.css';
const style = {
    color: 'white',
    fontSize: 200,
    width: '7%',
    float: 'left'
};

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);
      
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
            <Navbar className="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-success mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">
                        <a href="#"><img src={"../../image/home.png"} style={style} /></a>
                    </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                        <NavLink tag={Link} className="nav-link text-white" to="/">Home</NavLink>
                </NavItem>

                <NavItem>
                        <NavLink tag={Link} className="nav-link text-white" to="/developer">Developer</NavLink>
                </NavItem>

                <NavItem>
                        <NavLink tag={Link} className="nav-link text-white" to="/project">Project</NavLink>
                </NavItem>

                <NavItem>
                        <NavLink tag={Link} className="nav-link text-white" to="/ranking">Ranking</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
