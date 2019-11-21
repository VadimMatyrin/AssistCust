import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { LoadingScreen } from '../LoadingScreen';
import { PurchaseDetailsPage } from '../purchasedetail/PurchaseDetailsPage'
import strings from '../../localization/localization';

export class PurchaseDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            purchase: this.props.location.purchase
        };
        this.fetchForPurchase = this.fetchForPurchase.bind(this);
    };

    componentDidMount() {
        this.fetchForPurchase();
    }

    render() {
        const purchase = this.state.purchase;
        if (!purchase) {
            return (<LoadingScreen />);
        }
        return (
            <div className="row">
                <div className="col-lg-12">
                    <h1>{strings.purchase}: {purchase.id}</h1>
                    <h3>{strings.createdBy}: {purchase.userId}</h3>
                    <h3>{strings.startPurchaseTime}: {purchase.purchaseTime}</h3>
                    <h3>{strings.finishPurchaseTime}: {purchase.finishTime}</h3>
                    <h3>{strings.shop}: {purchase.companyShopId}</h3>
                </div>
                <div className="col-lg-12">
                    <PurchaseDetailsPage purchase={purchase} />
                </div>
            </div>
        );
    }

    async fetchForPurchase() {
        const { id } = this.props.match.params
        const purchase = await fetchDataService.getPurchase(id);
        this.setState({
            purchase: purchase
        });
    }
}