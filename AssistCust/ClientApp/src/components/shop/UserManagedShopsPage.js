import React, { Component } from 'react';
import { ShopsList } from './ShopsList'
import fetchDataService from '../helpers/FetchDataService'
import strings from '../../localization/localization';

export class UserManagedShopsPage extends Component {

    constructor(props) {
        super(props);
        this.state = { shops: [], };
        this.triggerShopsFetch = this.triggerShopsFetch.bind(this);
    }

    componentDidMount() {
        this.getAllUserManagedShops();
    }

    triggerShopsFetch() {
        this.getAllUserManagedShops();
    }

    render() {
        return (
            <div className="container rounded border border-secondary" style={{ marginTop: "20px", marginBottom: "20px", padding: "10px", backgroundColor: "white" }}>
                <div className="row">
                    <div className="col-lg-10">
                        <h3> {strings.userManagedShops}:</h3>
                    </div>
                </div>
                <div>
                    <ShopsList shops={this.state.shops} triggerShopsFetch={this.triggerShopsFetch} redirectTo="/usermanagedshops" showProducts={true}></ShopsList>
                </div>
            </div>
        );
    }

    async getAllUserManagedShops() {
        const shops = await fetchDataService.getAllUserManagedShops();
        this.setState({ shops });
        console.log(shops);
    }
}
