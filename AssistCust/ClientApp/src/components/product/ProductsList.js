import React, { Component } from 'react';
import { Product } from './Product';

export class ProductsList extends Component {

    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-2">Name</div>
                        <div className="col-lg-6">Description</div>
                        <div className="col-lg-2">Price</div>
                        <div className="col-lg-2"><b>Actions</b></div>
                    </div>
                </li>
                {this.props.products.map((product) => {
                    return (<Product product={product} triggerProductsFetch={this.props.triggerProductsFetch}></Product>);
                })}
            </ul>
        );
    }
}
