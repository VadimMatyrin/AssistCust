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

export class PurchaseDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: false
        };
        this.submit = this.submit.bind(this);
        this.deletePurchaseDetail = this.deletePurchaseDetail.bind(this);
    }

    async deletePurchaseDetail(purchaseDetailId) {
        this.setState({
            loading: true
        });
        const responseCode = await fetchDataService.deletePurchaseDetail(purchaseDetailId);
        if (responseCode === 204) {
            this.props.triggerPurchaseDetailsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(purchaseDetailId) {
        confirmAlert({
            title: 'Confirm to submit',
            message: `Are you sure you want to delete this purchase detail?`,
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.deletePurchaseDetail(purchaseDetailId)
                },
                {
                    label: 'No'
                }
            ]
        });
    };

    render() {
        const purchaseDetail = this.props.purchaseDetail;
        const redirectToPurchase = this.state.redirectToPurchase;
        if (redirectToPurchase) {
            return (<Redirect to={{
                pathname: `/purchasedetails/${purchaseDetail.purchaseId}`,
                purchaseId: purchaseDetail.purchaseId
            }} />);
        }
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-4">{purchaseDetail.productId}</div>
                        <div className="col-lg-4">{purchaseDetail.amount}</div>
                        <div className="col-lg-4">
                            <div className="row">
                                <div className="col-lg-3">
                                    <Link to={{
                                        pathname: '/editpurchasedetail/' + purchaseDetail.id,
                                        purchaseDetail: purchaseDetail
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.purchaseDetail.id)}>
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
