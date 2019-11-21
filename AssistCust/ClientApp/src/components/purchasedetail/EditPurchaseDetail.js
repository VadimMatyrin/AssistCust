import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class EditPurchaseDetail extends Component {

    constructor(props) {
        super(props);
        this.state = {
            purchaseDetailId: null,
            purchaseDetail: null,
            productId: null,
            amount: null,
            loading: false,
            redirect: false
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fetchForPurchaseDetail = this.fetchForPurchaseDetail.bind(this);
    }

    componentDidMount() {
        if (this.props.location.purchaseDetail) {
            const purchaseDetail = this.props.location.purchaseDetail;
            this.setState({
                purchaseDetail: purchaseDetail,
                productId: purchaseDetail.productId,
                amount: purchaseDetail.amount,
            });
        } else {
            this.fetchForPurchaseDetail();
        }

    }

    async fetchForPurchaseDetail() {
        const { id } = this.props.match.params
        const purchaseDetail = await fetchDataService.getPurchaseDetail(id);
        this.setState({
            purchaseDetail: purchaseDetail,
            productId: purchaseDetail.productId,
            amount: purchaseDetail.amount
        });
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
            id: this.state.purchaseDetail.id,
            productId: parseInt(this.state.productId),
            amount: parseInt(this.state.amount),
            purchaseId: this.state.purchaseDetail.purchaseId
        }
        const responseCode = await fetchDataService.updatePurchaseDetail(purchaseDetail);
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
            return (<Redirect to={`/purchasedetails/${this.state.purchaseDetail.purchaseId}`} />);
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