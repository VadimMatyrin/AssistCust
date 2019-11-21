import React, { Component } from 'react';
import { PurchaseDetail } from './PurchaseDetail';
import strings from '../../localization/localization';

export class PurchaseDetailsList extends Component {
    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6">{strings.product}</div>
                        <div className="col-lg-6">{strings.amount}</div>
                    </div>
                </li>
                {this.props.purchaseDetails.map((purchaseDetail) => {
                    return (<PurchaseDetail purchaseDetail={purchaseDetail} triggerPurchaseDetailsFetch={this.props.triggerPurchaseDetailsFetch} />);
                })}
            </ul>
        );
    }
}