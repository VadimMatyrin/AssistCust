import React, { Component } from 'react';
import { PurchaseDetailsList } from './PurchaseDetailsList';
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import strings from '../../localization/localization';

export class PurchaseDetailsPage extends Component {

    constructor(props) {
        super(props);
        this.state = { purchaseDetails: [], };
        this.triggerPurchaseDetailsFetch = this.triggerPurchaseDetailsFetch.bind(this);
    }

    componentDidMount() {
        this.getAllPurchaseDetailsByPurchase();
    }

    triggerPurchaseDetailsFetch() {
        this.getAllPurchaseDetailsByPurchase();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px", backgroundColor: "white" }}>
                <div className="row">
                    <div className="col-lg-10">
                        <h3> {this.props.purchase.id}: {strings.details}</h3>
                    </div>
                    <div className="col-lg-2">
                        <Link to={{
                            pathname: '/createpurchasedetail/' + this.props.purchase.id,
                            purchase: this.props.purchase
                        }}>
                            <button type="button" className="btn btn-success">
                                <FontAwesomeIcon icon={faPlus} />
                            </button>
                        </Link>
                    </div>
                </div>
                <div>
                    <PurchaseDetailsList purchaseDetails={this.state.purchaseDetails} triggerPurchaseDetailsFetch={this.triggerPurchaseDetailsFetch} />
                </div>
            </div>
        );
    }

    async getAllPurchaseDetailsByPurchase() {
        const purchaseDetails = await fetchDataService.getAllPurchaseDetailsByPurchase(this.props.purchase.id);
        this.setState({ purchaseDetails });
        console.log(purchaseDetails);
    }
}
