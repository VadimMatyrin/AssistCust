import React, { Component } from 'react';
import { Product } from './Product';
import strings from '../../localization/localization';

export class ProductsList extends Component {

    render() {
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-1">ID</div>
                        <div className="col-lg-2">{strings.name}</div>
                        <div className="col-lg-5">{strings.description}</div>
                        <div className="col-lg-2">{strings.price}</div>
                        <div className="col-lg-2"><b>{strings.actions}</b></div>
                    </div>
                </li>
                {this.props.products.map((product) => {
                    return (<Product product={product} triggerProductsFetch={this.props.triggerProductsFetch}></Product>);
                })}
            </ul>
        );
    }
}
