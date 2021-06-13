import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class EditShop extends Component {

    constructor(props) {
        super(props);
        this.state = {
            shop: null,
            shopName: null,
            state: null,
            city: null,
            addressField1: null,
            addressField2: null,
            userId: null,
            loading: false,
            redirect: false,
            redirectTo: null,
            errorMessage: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fetchForShop = this.fetchForShop.bind(this);
    }


    componentDidMount() {
        if (this.props.location.shop) {
            const shop = this.props.location.shop;
            this.setState({
                shop: shop,
                shopName: shop.shopName,
                state: shop.state,
                city: shop.city,
                addressField1: shop.addressField1,
                addressField2: shop.addressField2,
                userId: shop.userId,
                redirectTo: this.props.location.redirectTo
            });
        } else {
            this.fetchForShop();
        }

    }

    async fetchForShop() {
        const { id } = this.props.match.params
        const shop = await fetchDataService.getShop(id);
        this.setState({
            shop: shop,
            shopName: shop.shopName,
            state: shop.state,
            city: shop.city,
            addressField1: shop.addressField1,
            addressField2: shop.addressField2,
            userId: shop.userId,
            redirectTo: "/companies"
        });
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
        const shop = {
            id: this.state.shop.id,
            shopName: this.state.shopName,
            state: this.state.state,
            city: this.state.city,
            addressField1: this.state.addressField1,
            addressField2: this.state.addressField2,
            userId: this.state.userId,
        }
        try {
            if (shop.shopName.length < 3) {
                throw "Validation error";
            }
            const responseCode = await fetchDataService.updateShop(shop);
            if (responseCode === 204) {
                this.setState({
                    redirect: true
                });
            }
            if (responseCode === 500) {
                this.setState({
                    errorMessage: strings.errorMessage
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
            return (<Redirect to={this.state.redirectTo} />);
        }
        const { shop } = this.state;
        if (!shop) {
            return (<LoadingScreen />);
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