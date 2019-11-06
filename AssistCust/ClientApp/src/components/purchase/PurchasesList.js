import React, { Component } from 'react';
import { Purchase } from './Purchase';

export class PurchasesList extends Component {
    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-3">Created by</div>
                        <div className="col-lg-3">Start purchase time</div>
                        <div className="col-lg-3">Finish time</div>
                        <div className="col-lg-3"><b>Actions</b></div>
                    </div>
                </li>
                {this.props.purchases.map((purchase) => {
                    return (<Purchase purchase={purchase} triggerPurchasesFetch={this.props.triggerPurchasesFetch} />);
                })}
            </ul>
        );
    }
}