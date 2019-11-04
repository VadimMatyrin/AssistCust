import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class EditAttRequest extends Component {

    constructor(props) {
        super(props);
        const attRequest = this.props.location.attRequest;
        this.state = {
            message: attRequest.message,
            isResolved: attRequest.isResolved,
            loading: false,
            redirect: false
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
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
        debugger;
        const resolveDate = this.state.isResolved ? new Date().toISOString() : null;
        debugger;
        const attRequest = {
            "id": this.props.location.attRequest.id,
            "message": this.state.message,
            "isResolved": this.state.isResolved,
            "resolveDate": resolveDate
        }
        const createdId = await fetchDataService.updateAttRequest(attRequest);
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
            return (<Redirect to={`/shopdetails/${this.props.location.attRequest.companyShopId}`} />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="name">
                                Message:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="message"
                                type="text"
                                class="form-control"
                                id="message"
                                value={this.state.message}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-2">
                            <label for="description">
                                Is resolved:
                        </label>
                        </div>
                        <div class="col-sm-6">
                            <input
                                name="isResolved"
                                type="checkbox"
                                class="form-control"
                                id="isResolved"
                                checked={this.state.isResolved}
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