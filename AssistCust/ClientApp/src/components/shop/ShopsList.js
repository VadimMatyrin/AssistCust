import React, { Component } from 'react';
import { Shop } from './Shop';

export class ShopsList extends Component {

    render() {
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-2">Shop name</div>
                        <div className="col-lg-2">State</div>
                        <div className="col-lg-2">City</div>
                        <div className="col-lg-2">Address 1</div>
                        <div className="col-lg-2">Address 2</div>
                        <div className="col-lg-2"><b>Actions</b></div>
                    </div>
                </li>
                {this.props.shops.map((shop) => {
                    return (<Shop shop={shop} triggerShopsFetch={this.props.triggerShopsFetch}></Shop>);
                })}
            </ul>
        );
    }
}
