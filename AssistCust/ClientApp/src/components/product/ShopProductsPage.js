import React, { Component } from 'react';
import { ProductsList } from './ProductsList'
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService'
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import strings from '../../localization/localization';

export class ShopProductsPage extends Component {

    constructor(props) {
        super(props);
        this.state = { products: [], };
        this.triggerProductsFetch = this.triggerProductsFetch.bind(this);
    }

    componentDidMount() {
        this.getAllProductsByCompany();
    }

    triggerProductsFetch() {
        this.getAllProductsByCompany();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px" }}>
                <div className="row">
                    <div className="col-lg-10">
                        <h3> {this.props.shop.name} {strings.products}:</h3>
                    </div>
                </div>
                <div>
                    <ProductsList products={this.state.products} triggerProductsFetch={this.triggerProductsFetch} readonly={true}></ProductsList>
                </div>
            </div>
        );
    }

    async getAllProductsByCompany() {
        const products = await fetchDataService.getAllProductsByCompany(this.props.shop.companyId);
        this.setState({ products });
        console.log(products);
    }
}
