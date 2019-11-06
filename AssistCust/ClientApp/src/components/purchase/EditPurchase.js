import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService';
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class EditPurchase extends Component {

    constructor(props) {
        super(props);
        this.state = {
            purchaseTime: this.props.location.purchase.purchaseTime,
            finishTime: this.props.location.purchase.finishTime,
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
            "id": this.props.location.purchase.id,
            "purchaseTime": `${this.state.purchaseTime}Z`,
            "finishTime": `${this.state.finishTime}:00Z`,
        }
        const responseCode = await fetchDataService.updatePurchase(purchase);
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
            return (<Redirect to={`/shopdetails/${this.props.location.purchase.companyShopId}`} />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
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
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="finishTime">
                                Finish time:
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="finishTime"
                                type="datetime-local"
                                class="form-control"
                                id="finishTime"
                                value={this.state.finishTime}
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