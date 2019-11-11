import React, { Component } from 'react';
import { PurchaseDetail } from './PurchaseDetail';

export class PurchaseDetailsList extends Component {
    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6">Product</div>
                        <div className="col-lg-6">Amount</div>
                    </div>
                </li>
                {this.props.purchaseDetails.map((purchaseDetail) => {
                    return (<PurchaseDetail purchaseDetail={purchaseDetail} triggerPurchaseDetailsFetch={this.props.triggerPurchaseDetailsFetch} />);
                })}
            </ul>
        );
    }
}