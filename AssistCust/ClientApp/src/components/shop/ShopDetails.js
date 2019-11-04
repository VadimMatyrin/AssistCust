import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { LoadingScreen } from '../LoadingScreen';

export class ShopDetails extends Component {
    constructor(props) {
        super(props);
        debugger;
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
                    <h1>{shop.shopName}: Shop</h1>
                </div>
                <div></div>
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