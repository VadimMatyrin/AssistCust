import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class UserProfile extends Component {

    constructor(props) {
        super(props);
        this.state = {
            userId: null
        };
        this.loadUser = this.loadUser.bind(this);
    }

    componentDidMount() {
        this.loadUser();
    }

    render() {
        if (!this.state.userId) {
            return <LoadingScreen></LoadingScreen>
        }
        return (
            <div className="row">
                <div className="col-lg-12"><h1>{strings.userProfile}</h1></div>
                <div className="col-lg-12">{strings.userId}: {this.state.userId}</div>
            </div>
        );
    }

    async loadUser() {
        const user = await authService.getUser();
        console.log(user);
        this.setState({ userId: user.sub });
    }
}