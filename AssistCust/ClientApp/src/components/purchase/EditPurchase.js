import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';
import strings from '../../localization/localization';

export class EditPurchase extends Component {

    constructor(props) {
        super(props);
        this.state = {
            shopId: null,
            purchase: null,
            purchaseTime: null,
            finishTime: null,
            loading: false,
            redirect: false,
            errorMessage: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fetchForPurchase = this.fetchForPurchase.bind(this);
    }

    componentDidMount() {
        if (this.props.location.purchase) {
            const purchase = this.props.location.purchase;
            this.setState({
                purchase: purchase,
                purchaseTime: purchase.purchaseTime,
                finishTime: purchase.finishTime,
            });
        } else {
            this.fetchForPurchase();
        }

    }

    async fetchForPurchase() {
        const { id } = this.props.match.params
        const purchase = await fetchDataService.getPurchase(id);
        this.setState({
            purchase: purchase,
            purchaseTime: purchase.purchaseTime,
            finishTime: purchase.finishTime,
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
        const purchase = {
            id: this.state.purchase.id,
            purchaseTime: `${this.state.purchaseTime}Z`,
            finishTime: `${this.state.finishTime}:00Z`,
        }
        try {
            const responseCode = await fetchDataService.updatePurchase(purchase);
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
            return (<Redirect to={`/shopdetails/${this.state.purchase.companyShopId}`} />);
        }
        const { purchase } = this.state;
        if (!purchase) {
            return (<LoadingScreen />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                {this.state.errorMessage && <span style={{ color: "red" }}>{this.state.errorMessage}</span>}
                <form onSubmit={this.handleSubmit}>
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
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="finishTime">
                                {strings.finishPurchaseTime}:
                            </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="finishTime"
                                type="datetime-local"
                                className="form-control"
                                id="finishTime"
                                value={this.state.finishTime}
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