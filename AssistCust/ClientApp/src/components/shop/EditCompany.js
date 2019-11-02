import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class EditCompany extends Component {

    constructor(props) {
        super(props);
        debugger;
        this.state = {
            companyName: this.props.location.company.name,
            countryName: this.props.location.company.country,
            loading: false,
            redirect: false
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    async handleSubmit(event) {
        this.setState({
            loading: true
        });
        event.preventDefault();
        const company = {
            'Id': this.props.location.company.id,
            'Name': this.state.companyName,
            'Country': this.state.countryName
        }
        const responseCode = await fetchDataService.updateCompany(company);
        //await new Promise((resolve) => { setTimeout(() => { resolve() }, 2000); });
        if (responseCode === 204) {
            this.setState({
                redirect: true
            });
        }
        this.setState({
            loading: false
        });
    }

    render() {
        const { redirect } = this.state;
        if (redirect) {
            return (<Redirect to="/companies" />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="companyName">
                                Company name:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="companyName"
                                type="text"
                                class="form-control"
                                id="companyName"
                                value={this.state.companyName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="countryName">
                                Company country:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="countryName"
                                type="text"
                                class="form-control"
                                id="countryName"
                                value={this.state.countryName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <button type="submit" class="btn btn-primary">Submit</button>
                    {this.state.loading && <LoadingScreen />}
                </form>
            </fieldset>
        );
    }

}