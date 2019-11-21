import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';
import strings from '../../localization/localization';

export class Shop extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: false,
            redirectToShop: false
        };
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
            title: strings.confirmToSubmit,
            message: strings.deleteShopMessage,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => this.deleteShop(shopId)
                },
                {
                    label: strings.no
                }
            ]
        });
    };

    render() {
        const shop = this.props.shop;
        const redirectToShop = this.state.redirectToShop;
        if (redirectToShop) {
            return (<Redirect to={{
                pathname: `/shopdetails/${shop.id}`,
                shop: shop
            }}/>);
        }
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
                                        pathname: '/editshop/' + shop.id,
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
                                    <button type="button" className="btn btn-info" onClick={(e) => this.setState({ redirectToShop: true })}>
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
