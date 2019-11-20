import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

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
            redirect: false
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
        });
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
            id: this.state.shop.id,
            shopName: this.state.shopName,
            state: this.state.state,
            city: this.state.city,
            addressField1: this.state.addressField1,
            addressField2: this.state.addressField2,
            userId: this.state.userId,
        }
        const responseCode = await fetchDataService.updateShop(shop);
        if (responseCode === 204) {
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
        const { shop } = this.state;
        if (!shop) {
            return (<LoadingScreen />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="shopName">
                                Shop name:
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
                                Shop state:
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
                                Shop city:
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
                                Address field 1
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
                                Address field 2
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
                                Shop manager id
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