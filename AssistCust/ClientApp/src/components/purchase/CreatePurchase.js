import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class CreatePurchase extends Component {

    constructor(props) {
        super(props);
        this.state = {
            userId: '',
            purchaseTime: '',
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
        const purchase = {
            userId: this.state.userId,
            purchaseTime: `${this.state.purchaseTime}:00Z`,
            companyShopId: this.props.location.shop.id,
        }
        const purchaseId = await fetchDataService.createPurchase(purchase);
        if (purchaseId) {
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
            return (<Redirect to={`/shopdetails/${this.props.location.shop.id}`} />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="userId">
                                Created by:
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="userId"
                                type="text"
                                class="form-control"
                                id="userId"
                                value={this.state.userId}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="purchaseTime">
                                Purchase time:
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="purchaseTime"
                                type="datetime-local"
                                class="form-control"
                                id="purchaseTime"
                                value={this.state.purchaseTime}
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