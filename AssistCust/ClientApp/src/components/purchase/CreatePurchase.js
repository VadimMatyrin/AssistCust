import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class CreatePurchase extends Component {

    constructor(props) {
        super(props);
        const { id } = this.props.match.params;
        const companyShopId = this.props.location.shop && this.props.location.shop.id ? this.props.location.shop.id : id;
        this.state = {
            userId: '',
            purchaseTime: '',
            companyShopId: companyShopId,
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
        const purchase = {
            userId: this.state.userId,
            purchaseTime: `${this.state.purchaseTime}:00Z`,
            companyShopId: this.state.companyShopId,
        }
        try {
            const purchaseId = await fetchDataService.createPurchase(purchase);
            if (purchaseId) {
                this.setState({
                    redirect: true
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
            return (<Redirect to={`/shopdetails/${this.state.companyShopId}`} />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                {this.state.errorMessage && <span style={{ color: "red" }}>{this.state.errorMessage}</span>}
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="userId">
                                {strings.createdBy}:
                            </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="userId"
                                type="text"
                                className="form-control"
                                id="userId"
                                value={this.state.userId}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="purchaseTime">
                                {strings.startPurchaseTime}:
                            </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="purchaseTime"
                                type="datetime-local"
                                className="form-control"
                                id="purchaseTime"
                                value={this.state.purchaseTime}
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