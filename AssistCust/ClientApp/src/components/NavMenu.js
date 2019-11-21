import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import authService from './api-authorization/AuthorizeService';
import strings from '../localization/localization';
import { LanguagePicker } from './languagePicker/languagePicker';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
            authenticated: false,
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.authenticationChanged());
        this.populateAuthenticationState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        const { authenticated } = this.state;
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">AssistCust</NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">{strings.home}</NavLink>
                                </NavItem>
                                {
                                    authenticated &&
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/userprofile">{strings.userProfile}</NavLink>
                                    </NavItem>
                                }
                                {
                                    authenticated &&
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/companies">{strings.companies}</NavLink>
                                    </NavItem>
                                }
                                {
                                    authenticated &&
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/usermanagedshops">{strings.userManagedShops}</NavLink>
                                    </NavItem>
                                }
                                <LoginMenu>
                                </LoginMenu>
                                <LanguagePicker changeSiteLanguage={this.props.changeSiteLanguage}></LanguagePicker>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    async populateAuthenticationState() {
        const authenticated = await authService.isAuthenticated();
        this.setState({ ready: true, authenticated });
    }

    async authenticationChanged() {
        this.setState({ ready: false, authenticated: false });
        await this.populateAuthenticationState();
    }
}
