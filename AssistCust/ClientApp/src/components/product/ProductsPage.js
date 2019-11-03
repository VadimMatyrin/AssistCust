import React, { Component } from 'react';
import { ProductsList } from './ProductsList'
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService'
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class ProductsPage extends Component {

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
                        <h3> {this.props.company.name} products:</h3>
                    </div>
                    <div className="col-lg-2">
                        <Link to={{
                            pathname: '/createproduct',
                            companyId: this.props.company.id
                        }}>
                            <button type="button" className="btn btn-success">
                                <FontAwesomeIcon icon={faPlus} />
                            </button>
                        </Link>
                    </div>
                </div>
                <div>
                    <ProductsList products={this.state.products} triggerProductsFetch={this.triggerProductsFetch}></ProductsList>
                </div>
            </div>
        );
    }

    async getAllProductsByCompany() {
        const products = await fetchDataService.getAllProductsByCompany(this.props.company.id);
        this.setState({ products });
        console.log(products);
    }
}
