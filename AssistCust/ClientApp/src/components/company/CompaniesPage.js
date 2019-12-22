import React, { Component } from 'react';
import { CompaniesList } from './CompaniesList'
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService'
import strings from '../../localization/localization';

export class CompaniesPage extends Component {

    constructor(props) {
        super(props);
        this.state = { companies: [], };
        this.triggerCompaniesFetch = this.triggerCompaniesFetch.bind(this);
    }

    componentDidMount() {
        this.getUserCompanies();
    }

    triggerCompaniesFetch() {
        this.getUserCompanies();
    }

    render() {
        return (
            <div className="container">
                <div className="row">
                    <div className="col-lg-10">
                        <h1>{strings.yourCompanies}:</h1>
                    </div>
                    <div className="col-lg-2">
                        <Link to="/createcompany">
                            <button type="button" className="btn btn-success">
                                {strings.createNew}
                            </button>
                        </Link>
                    </div>
                </div>
                <div>
                    <CompaniesList companies={this.state.companies} triggerCompaniesFetch={this.triggerCompaniesFetch}></CompaniesList>
                </div>
            </div>
        );
    }

    async getUserCompanies() {
        const companies = await fetchDataService.getAllUserCompaniesAsync();
        this.setState({ companies });
        console.log(companies);
    }
}
