﻿import React, { Component } from 'react';
import { ShopsList } from './ShopsList'
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService'
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class ShopsPage extends Component {

    constructor(props) {
        super(props);
        this.state = { shops: [], };
        this.triggerShopsFetch = this.triggerShopsFetch.bind(this);
    }

    componentDidMount() {
        this.getAllCompanyShopsByCompany();
    }

    triggerShopsFetch() {
        this.getAllCompanyShopsByCompany();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px" }}>
                <div className="row">
                    <div className="col-lg-10">
                        <h3> {this.props.company.name} shops:</h3>
                    </div>
                    <div className="col-lg-2">
                        <Link to={{
                            pathname: '/createshop',
                            companyId: this.props.company.id
                        }}>
                            <button type="button" className="btn btn-success">
                                <FontAwesomeIcon icon={faPlus} />
                            </button>
                        </Link>
                    </div>
                </div>
                <div>
                    <ShopsList shops={this.state.shops} triggerShopsFetch={this.triggerShopsFetch}></ShopsList>
                </div>
            </div>
        );
    }

    async getAllCompanyShopsByCompany() {
        const shops = await fetchDataService.getAllCompanyShopsByCompany(this.props.company.id);
        this.setState({ shops });
        console.log(shops);
    }
}