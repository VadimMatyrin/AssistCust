import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class CreateProduct extends Component {

    constructor(props) {
        super(props);
        const { id } = this.props.match.params;
        const companyId = this.props.location.companyId ? this.props.location.companyId : parseInt(id);
        this.state = {
            name: '',
            description: '',
            price: 0,
            companyId: companyId,
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
            name: this.state.name,
            description: this.state.description,
            price: parseFloat(this.state.price),
            companyId: this.state.companyId,
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
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="name">
                                {strings.name}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="name"
                                type="text"
                                className="form-control"
                                id="name"
                                value={this.state.shopName}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="description">
                                {strings.description}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="description"
                                type="text"
                                className="form-control"
                                id="description"
                                value={this.state.state}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="price">
                                {strings.price}:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="price"
                                type="number"
                                min="0"
                                step="0.01"
                                className="form-control"
                                id="price"
                                value={this.state.price}
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