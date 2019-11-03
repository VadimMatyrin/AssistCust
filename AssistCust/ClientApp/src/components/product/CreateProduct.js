import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class CreateProduct extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            description: '',
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
        const product = {
            "name": this.state.name,
            "description": this.state.description,
            "companyId": this.props.location.companyId,
        }
        const createdId = await fetchDataService.createProduct(product);
        if (createdId) {
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
                            <label for="name">
                                Product name:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="name"
                                type="text"
                                class="form-control"
                                id="name"
                                value={this.state.shopName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="description">
                                Description:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="description"
                                type="text"
                                class="form-control"
                                id="description"
                                value={this.state.state}
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