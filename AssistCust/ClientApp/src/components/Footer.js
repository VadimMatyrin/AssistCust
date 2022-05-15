import React, { Component } from 'react';
import { Navbar, NavbarBrand } from 'reactstrap';

export class Footer extends Component {

    render() {
        return (
            <footer>
                <Navbar className="navbar fixed-bottom navbar-toggleable-sm ng-white border-top box-shadow text-center" light>
                    <NavbarBrand>AssistCust 2021</NavbarBrand>
                </Navbar>
            </footer>
        );
    }
}
