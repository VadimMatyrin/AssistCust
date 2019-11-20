import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faStore } from '@fortawesome/free-solid-svg-icons';
import { faTags } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';
import { ShopsPage } from '../shop/ShopsPage';
import { ProductsPage } from '../product/ProductsPage';
import strings from '../../localization/localization';

export class Company extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: false,
            showShops: false,
            showProducts: false,
        };
        this.submit = this.submit.bind(this);
        this.deleteCompany = this.deleteCompany.bind(this);
    }

    async deleteCompany(companyId) {
        this.setState({
            loading: true
        });
        //await new Promise((resolve) => { setTimeout(() => { resolve() }, 2000); });
        const responseCode = await fetchDataService.deleteCompany(companyId);
        if (responseCode === 204) {
            this.props.triggerCompaniesFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(companyId) {
        confirmAlert({
            title: strings.confirmToSubmit,
            message: strings.deleteCompanyMessage,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => this.deleteCompany(companyId)
                },
                {
                    label: strings.no
                }
            ]
        });
    };
    render() {
        const company = this.props.company;
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6">{company.name}</div>
                        <div className="col-lg-3">{company.country}</div>
                        <div className="col-lg-3">
                            <div className="row">
                                <div className="col-lg-3">
                                    <Link to={{
                                        pathname: '/editcompany/' + company.id,
                                        company: company
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.company.id)}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-warning" onClick={(e) => this.setState({
                                        showShops: !this.state.showShops,
                                        showProducts: false
                                    })}>
                                        <FontAwesomeIcon icon={faStore} />
                                    </button>
                                </div>
                                <div className="col-lg-3">
                                    <button type="button" className="btn btn-info" onClick={(e) => this.setState({
                                        showProducts: !this.state.showProducts,
                                        showShops: false,
                                    })}>
                                        <FontAwesomeIcon icon={faTags} />
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                {this.state.showShops && <ShopsPage company={this.props.company} />}
                {this.state.showProducts && <ProductsPage company={this.props.company} />}
                {this.state.loading && <LoadingScreen />}
            </>
        );
    }
}
