﻿import React, { Component } from 'react';
import { PurchasesList } from './PurchasesList';
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class PurchasesPage extends Component {

    constructor(props) {
        super(props);
        this.state = { purchases: [], };
        this.triggerPurchasesFetch = this.triggerPurchasesFetch.bind(this);
    }

    componentDidMount() {
        this.getAllPurchasesByShop();
    }

    triggerPurchasesFetch() {
        this.getAllPurchasesByShop();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px" }}>
                <div className="row">
                    <div className="col-lg-10">
                        <h3> {this.props.shop.shopName} purchases:</h3>
                    </div>
                    <div className="col-lg-2">
                        <Link to={{
                            pathname: '/createpurchase',
                            shop: this.props.shop
                        }}>
                            <button type="button" className="btn btn-success">
                                <FontAwesomeIcon icon={faPlus} />
                            </button>
                        </Link>
                    </div>
                </div>
                <div>
                    <PurchasesList purchases={this.state.purchases} triggerPurchasesFetch={this.triggerPurchasesFetch} />
                </div>
            </div>
        );
    }

    async getAllPurchasesByShop() {
        const purchases = await fetchDataService.getAllPurchasesByShop(this.props.shop.id);
        this.setState({ purchases });
        console.log(purchases);
    }
}
