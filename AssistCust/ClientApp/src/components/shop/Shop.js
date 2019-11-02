﻿import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';

export class Shop extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: false };
        this.submit = this.submit.bind(this);
        this.deleteShop = this.deleteShop.bind(this);
    }

    async deleteShop(shopId) {
        this.setState({
            loading: true
        });
        const responseCode = await fetchDataService.deleteShop(shopId);
        if (responseCode === 204) {
            this.props.triggerShopsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(shopId) {
        confirmAlert({
            title: 'Confirm to submit',
            message: `Are you sure you want to delete this shop?`,
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.deleteShop(shopId)
                },
                {
                    label: 'No'
                }
            ]
        });
    };
    render() {
        const shop = this.props.shop;
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-2">{shop.shopName}</div>
                        <div className="col-lg-2">{shop.state}</div>
                        <div className="col-lg-2">{shop.city}</div>
                        <div className="col-lg-2">{shop.addressField1}</div>
                        <div className="col-lg-2">{shop.addressField2}</div>
                        <div className="col-lg-2">
                            <div className="row">
                                <div className="col-lg-3">
                                    <Link to={{
                                        pathname: '/editshop',
                                        shop: shop
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.shop.id)}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-info" onClick={(e) => this.submit(this.props.shop.id)}>
                                        <FontAwesomeIcon icon={faInfoCircle} />
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                {this.state.loading && <LoadingScreen />}
            </>
        );
    }
}