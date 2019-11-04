import React, { Component } from 'react';
import { AttRequestsList } from './AttRequestsList'
import { Link } from 'react-router-dom';
import fetchDataService from '../helpers/FetchDataService'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class AttRequestsPage extends Component {

    constructor(props) {
        super(props);
        this.state = { attRequests: [], };
        this.triggerAttRequestsFetch = this.triggerAttRequestsFetch.bind(this);
    }

    componentDidMount() {
        this.getAllShopAttentionRequests();
    }

    triggerAttRequestsFetch() {
        this.getAllShopAttentionRequests();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px" }}>
                <div className="row">
                    <div className="col-lg-12">
                        <h3> {this.props.shop.shopName} requests:</h3>
                    </div>
                </div>
                <div>
                    <AttRequestsList attRequests={this.state.attRequests} triggerAttRequestsFetch={this.triggerAttRequestsFetch}></AttRequestsList>
                </div>
            </div>
        );
    }

    async getAllShopAttentionRequests() {
        const attRequests = await fetchDataService.getAllShopAttentionRequests(this.props.shop.id);
        this.setState({ attRequests });
        console.log(attRequests);
    }
}
