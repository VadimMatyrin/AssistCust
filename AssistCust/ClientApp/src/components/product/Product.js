import React, { Component } from 'react';
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

export class Product extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: false };
        this.submit = this.submit.bind(this);
        this.deleteProduct = this.deleteProduct.bind(this);
    }

    async deleteProduct(productId) {
        this.setState({
            loading: true
        });
        const responseCode = await fetchDataService.deleteProduct(productId);
        if (responseCode === 204) {
            this.props.triggerProductsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(productId) {
        confirmAlert({
            title: strings.confirmToSubmit,
            message: strings.deleteProductMessage,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => this.deleteProduct(productId)
                },
                {
                    label: strings.no
                }
            ]
        });
    };
    render() {
        const product = this.props.product;
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-1">{product.id}</div>
                        <div className="col-lg-2">{product.name}</div>
                        <div className="col-lg-5">{product.description}</div>
                        <div className="col-lg-2">{product.price}</div>
                        <div className="col-lg-2">
                            <div className="row">
                                <div className="col-lg-6">
                                    <Link to={{
                                        pathname: '/editproduct/' + product.id,
                                        product: product
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-6">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.product.id)}>
                                        <FontAwesomeIcon icon={faTrash} />
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
