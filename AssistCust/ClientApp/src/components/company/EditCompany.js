import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class EditCompany extends Component {

    constructor(props) {
        super(props);
        this.state = {
            company: null,
            companyName: null,
            countryName: null,
            loading: false,
            redirect: false,
            errorMessage: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fetchForCompany = this.fetchForCompany.bind(this);
    }

    componentDidMount() {
        if (this.props.location.company) {
            this.setState({
                company: this.props.location.company,
                companyName: this.props.location.company.name,
                countryName: this.props.location.company.country,
            });
        } else {
            this.fetchForCompany();
        }

    }

    async fetchForCompany() {
        const { id } = this.props.match.params
        const company = await fetchDataService.getCompany(id);
        this.setState({
            company: company,
            companyName: company.name,
            countryName: company.country,
        });
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
            id: this.state.company.id,
            name: this.state.companyName,
            country: this.state.countryName
        }
        try {
            if (company.name.length < 3) {
                throw "Validation error";
            }
            const responseCode = await fetchDataService.updateCompany(company);
            if (responseCode === 204) {
                this.setState({
                    redirect: true
                });
            }
            if (responseCode === 500) {
                this.setState({
                    errorMessage: strings.errorMessage
                });
            }
            this.setState({
                loading: false
            });
        } catch (e) {
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
        const { company } = this.state;
        if (!company) {
            return (<LoadingScreen />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                {this.state.errorMessage && <span style={{ color: "red" }}>{this.state.errorMessage}</span>}
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
                    <button type="submit" className="btn btn-primary">Submit</button>
                    {this.state.loading && <LoadingScreen />}
                </form>
            </fieldset>
        );
    }

}