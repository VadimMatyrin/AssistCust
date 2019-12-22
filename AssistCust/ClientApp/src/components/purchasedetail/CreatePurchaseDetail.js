import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class CreatePurchaseDetail extends Component {

    constructor(props) {
        super(props);
        const { id } = this.props.match.params;
        const purchaseId = this.props.location.purchaseId ? this.props.location.purchaseId : id;
        this.state = {
            purchaseId: purchaseId,
            productId: '',
            amount: 0,
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
        const purchaseDetail = {
            productId: parseInt(this.state.productId),
            amount: parseInt(this.state.amount),
            purchaseId: parseInt(this.state.purchaseId)
        }
        debugger;
        const purchaseDetailId = await fetchDataService.createPurchaseDetail(purchaseDetail);
        if (purchaseDetailId) {
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
            return (<Redirect to={`/purchasedetails/${this.state.purchaseId}`} />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="productId">
                                {strings.product}:
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="productId"
                                type="number"
                                class="form-control"
                                id="productId"
                                value={this.state.productId}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="amount">
                                {strings.amount}:
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="amount"
                                type="number"
                                class="form-control"
                                id="amount"
                                value={this.state.amount}
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