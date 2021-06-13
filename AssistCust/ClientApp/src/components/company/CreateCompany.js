import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class CreateCompany extends Component {

    constructor(props) {
        super(props);
        this.state = {
            companyName: '',
            countryName: '',
            loading: false,
            redirect: false,
            errorMessage: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value,
            errorMessage: null
        });
    }

    async handleSubmit(event) {
        this.setState({
            loading: true
        });
        event.preventDefault();
        const company = {
            name: this.state.companyName,
            country: this.state.countryName
        }
        try {
            if (company.name.length < 3) {
                throw "Validation error";
            }
            const createdId = await fetchDataService.createCompany(company);
            //await new Promise((resolve) => { setTimeout(() => { resolve() }, 2000); });
            if (createdId) {
                this.setState({
                    redirect: true
                });
            }
            this.setState({
                loading: false
            });
        }
        catch (e) {
            this.setState({
                loading: false,
                errorMessage: strings.errorMessage
            });
        }
    }

    render() {
        const { redirect } = this.state;
        if (redirect) {
            return (<Redirect to="/companies" />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                {this.state.errorMessage && <span style={{color: "red" }}>{this.state.errorMessage}</span>}
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="companyName">
                                {strings.name}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="companyName"
                                type="text"
                                className="form-control"
                                id="companyName"
                                value={this.state.companyName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="countryName">
                                {strings.country}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="countryName"
                                type="text"
                                className="form-control"
                                id="countryName"
                                value={this.state.countryName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <button type="submit" className="btn btn-primary">{strings.submit}</button>
                    {this.state.loading && <LoadingScreen />}
                </form>
            </fieldset>
        );
    }

}