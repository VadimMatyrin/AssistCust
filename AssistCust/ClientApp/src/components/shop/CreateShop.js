import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class CreateShop extends Component {

    constructor(props) {
        super(props);
        this.state = {
            shopName: '',
            state: '',
            city: '',
            addressField1: '',
            addressField2: '',
            userId: '',
            loading: false,
            redirect: false,
            errorMessage: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value,
            errorMessage: null
        });
    }

    async handleSubmit(event) {
        this.setState({
            loading: true
        });
        event.preventDefault();
        const { id } = this.props.match.params;
        const companyId = this.props.location.companyId ? this.props.location.companyId : id;
        const shop = {
            shopName: this.state.shopName,
            state: this.state.state,
            city: this.state.city,
            addressField1: this.state.addressField1,
            addressField2: this.state.addressField2,
            userId: this.state.userId,
            companyId: companyId,
        }
        try {
            if (shop.shopName.length < 3) {
                throw "Validation error";
            }
            const createdId = await fetchDataService.createShop(shop);
            if (createdId) {
                this.setState({
                    redirect: true
                });
            }
            this.setState({
                loading: false
            });
        } catch (e) {
            this.setState({
                loading: false,
                errorMessage: strings.errorMessage
            });
        }

    }

    render() {
        const { redirect } = this.state;
        if (redirect) {
            return (<Redirect to="/companies" />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                {this.state.errorMessage && <span style={{ color: "red" }}>{this.state.errorMessage}</span>}
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="shopName">
                                {strings.shopName}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="shopName"
                                type="text"
                                className="form-control"
                                id="shopName"
                                value={this.state.shopName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="state">
                                {strings.state}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="state"
                                type="text"
                                className="form-control"
                                id="state"
                                value={this.state.state}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="city">
                                {strings.city}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="city"
                                type="text"
                                className="form-control"
                                id="city"
                                value={this.state.city}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="state">
                                {strings.address1}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="addressField1"
                                type="text"
                                className="form-control"
                                id="addressField1"
                                value={this.state.addressField1}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="addressField2">
                                {strings.address2}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="addressField2"
                                type="text"
                                className="form-control"
                                id="addressField2"
                                value={this.state.addressField2}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="addressField2">
                                {strings.shopManagerId}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="userId"
                                type="text"
                                className="form-control"
                                id="userId"
                                value={this.state.userId}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <button type="submit" className="btn btn-primary">Submit</button>
                    {this.state.loading && <LoadingScreen />}
                </form>
            </fieldset>
        );
    }

}