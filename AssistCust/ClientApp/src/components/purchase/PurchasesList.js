import React, { Component } from 'react';
import { Purchase } from './Purchase';
import strings from '../../localization/localization';

export class PurchasesList extends Component {
    render() {
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-3">{strings.createdBy}</div>
                        <div className="col-lg-3">{strings.startPurchaseTime}</div>
                        <div className="col-lg-3">{strings.finishPurchaseTime}</div>
                        <div className="col-lg-3"><b>{strings.actions}</b></div>
                    </div>
                </li>
                {this.props.purchases.map((purchase) => {
                    return (<Purchase purchase={purchase} triggerPurchasesFetch={this.props.triggerPurchasesFetch} key={purchase.id} />);
                })}
            </ul>
        );
    }
}