import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { LoadingScreen } from '../LoadingScreen';
import { AttRequestsPage } from '../attentionRequest/AttRequestsPage';
import { PurchasesPage } from '../purchase/PurchasesPage';

export class ShopDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            shop: this.props.location.shop
        };
        this.fetchForShop = this.fetchForShop.bind(this);
    };

    componentDidMount() {
        this.fetchForShop();
    }

    render() {
        const shop = this.state.shop;
        if (!shop) {
            return (<LoadingScreen />);
        }
        return (
            <div className="row">
                <div className="col-lg-12">
                    <h1>{shop.shopName}</h1>
                    <h3>State: {shop.state}</h3>
                    <h3>City: {shop.city}</h3>
                    <h3>Address1: {shop.addressField1}</h3>
                    <h3>Address2: {shop.addressField2}</h3>
                    <h3>Manager: {shop.userId}</h3>
                </div>
                <div className="col-lg-12">
                    <AttRequestsPage shop={this.state.shop} />
                </div>
                <div className="col-lg-12">
                    <PurchasesPage shop={this.state.shop} />
                </div>
            </div>
        );
    }

    async fetchForShop() {
        const { id } = this.props.match.params
        const shop = await fetchDataService.getShop(id);
        this.setState({
            shop: shop
        });
    }
}