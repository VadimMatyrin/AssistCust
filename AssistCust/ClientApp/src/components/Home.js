import React, { Component } from 'react';
import { MainCarousel } from './MainCarousel.js';
import authService from './api-authorization/AuthorizeService';
import strings from '../localization/localization';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            token: null,
            userInfo: null
        }
        this.getUserInfo = this.getUserInfo.bind(this);
        this.getAuthenticationState = this.getAuthenticationState.bind(this);
    }

    componentDidMount() {
        this.getUserInfo();
    }

    render() {
        return (
            <>
                < MainCarousel>
                </ MainCarousel>
                <div id="userInfo" style={{ display: 'none' }} >
                    {JSON.stringify({ token: this.state.token, userInfo: this.state.userInfo })}
                </div>
                <h2>{strings.advantages}:</h2>
                <ul>
                    <li>{strings.fastResponse}</li>
                    <li>{strings.deployment}</li>
                    <li>{strings.scalability}</li>
                </ul>
            </>
        );
    }

    async getAuthenticationState() {
        const authenticated = await authService.isAuthenticated();
        return authenticated;
    }

    async getUserInfo() {
        const authenticated = await this.getAuthenticationState();
        if (authenticated) {
            const token = await authService.getAccessToken();
            const userInfo = await authService.getUser();
            this.setState({ token, userInfo });
        }
    }
}
