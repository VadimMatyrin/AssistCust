import React, { Component } from 'react';
import { CompaniesList } from './CompaniesList'
import fetchDataService from '../helpers/FetchDataService'

export class CompaniesPage extends Component {

    constructor(props) {
        super(props);
        this.state = { companies: [], };
    }

    componentDidMount() {
        this.getUserCompanies();
    }

    render() {
        return (
            <div className="container">
                <div className="row">
                    <div className="col-lg-10">
                        <h1>Your companies:</h1>
                    </div>
                    <div className="col-lg-2">
                        <button type="button" className="btn btn-success">Create new</button>
                    </div>
                </div>
                <div>
                    <CompaniesList companies={this.state.companies}></CompaniesList>
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
