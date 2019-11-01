import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';

export class Company extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: false };
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

    submit(event) {
        let target
        if (event.target.dataset.id) {
            target = event.target
        } else if (event.target.parentElement.dataset.id) {
            target = event.target.parentElement;
        } else {
            target = event.target.parentElement.parentElement;
        }
        const companyId = parseInt(target.dataset.id);
        confirmAlert({
            title: 'Confirm to submit',
            message: `Are you sure you want to delete ${target.name}?`,
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.deleteCompany(companyId)
                },
                {
                    label: 'No'
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
                        <div className="col-lg-4">{company.country}</div>
                        <div className="col-lg-2">
                            <div className="row">
                                <div className="col-lg-4">
                                    <button type="button" className="btn btn-info">
                                        <FontAwesomeIcon icon={faWrench} />
                                    </button>
                                </div>
                                <div className="col-lg-4">
                                    <button data-id={this.props.company.id} name={company.name} type="button" className="btn btn-danger" onClick={this.submit}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                {this.state.loading && <LoadingScreen />}
            </>
        );
    }
}
