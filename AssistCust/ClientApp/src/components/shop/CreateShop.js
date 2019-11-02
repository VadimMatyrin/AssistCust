import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

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
            redirect: false
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    async handleSubmit(event) {
        this.setState({
            loading: true
        });
        event.preventDefault();
        const shop = {
            "shopName": this.state.shopName,
            "state": this.state.state,
            "city": this.state.city,
            "addressField1": this.state.addressField1,
            "addressField2": this.state.addressField2,
            "userId": this.state.userId,
            "companyId": this.props.location.companyId,
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
    }

    render() {
        const { redirect } = this.state;
        if (redirect) {
            return (<Redirect to="/companies" />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="shopName">
                                Shop name:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="shopName"
                                type="text"
                                class="form-control"
                                id="shopName"
                                value={this.state.shopName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="state">
                                Shop state:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="state"
                                type="text"
                                class="form-control"
                                id="state"
                                value={this.state.state}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="city">
                                Shop city:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="city"
                                type="text"
                                class="form-control"
                                id="city"
                                value={this.state.city}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="state">
                                Address field 1
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="addressField1"
                                type="text"
                                class="form-control"
                                id="addressField1"
                                value={this.state.addressField1}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="addressField2">
                                Address field 2
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="addressField2"
                                type="text"
                                class="form-control"
                                id="addressField2"
                                value={this.state.addressField2}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="addressField2">
                                Shop manager id
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="userId"
                                type="text"
                                class="form-control"
                                id="userId"
                                value={this.state.userId}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <button type="submit" class="btn btn-primary">Submit</button>
                    {this.state.loading && <LoadingScreen />}
                </form>
            </fieldset>
        );
    }

}