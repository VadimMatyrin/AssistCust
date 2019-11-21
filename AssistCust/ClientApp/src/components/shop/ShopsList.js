import React, { Component } from 'react';
import { Shop } from './Shop';
import strings from '../../localization/localization';

export class ShopsList extends Component {

    render() {
        if (this.props.shops.length === 0) {
            return (
                <h2>{strings.noShops}</h2>
            );
        }
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-2">{strings.shopName}</div>
                        <div className="col-lg-2">{strings.state}</div>
                        <div className="col-lg-2">{strings.city}</div>
                        <div className="col-lg-2">{strings.address1}</div>
                        <div className="col-lg-1">{strings.address2}</div>
                        <div className="col-lg-3"><b>{strings.actions}</b></div>
                    </div>
                </li>
                {this.props.shops.map((shop) => {
                    return (<Shop shop={shop} triggerShopsFetch={this.props.triggerShopsFetch} redirectTo={this.props.redirectTo} showProducts={this.props.showProducts}></Shop>);
                })}
            </ul>
        );
    }
}
