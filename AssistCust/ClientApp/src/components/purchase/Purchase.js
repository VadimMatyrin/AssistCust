import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService';
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';

export class Purchase extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: false
        };
        this.submit = this.submit.bind(this);
        this.deletePurchase = this.deletePurchase.bind(this);
    }

    async deletePurchase(purchaseId) {
        this.setState({
            loading: true
        });
        const responseCode = await fetchDataService.deletePurchase(purchaseId);
        if (responseCode === 204) {
            this.props.triggerProductsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(purchaseId) {
        confirmAlert({
            title: 'Confirm to submit',
            message: `Are you sure you want to delete this purchase?`,
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.deletePurchase(purchaseId)
                },
                {
                    label: 'No'
                }
            ]
        });
    };

    render() {
        const purchase = this.props.purchase;
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-3">{purchase.userId}</div>
                        <div className="col-lg-3">{purchase.purchaseTime}</div>
                        <div className="col-lg-3">{purchase.finishTime}</div>
                        <div className="col-lg-3">
                            <div className="row">
                                <div className="col-lg-3">
                                    <Link to={{
                                        pathname: '/editpurchase/' + purchase.id,
                                        purchase: purchase
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.purchase.id)}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-info">
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
