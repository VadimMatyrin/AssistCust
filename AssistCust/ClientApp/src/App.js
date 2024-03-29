import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { CompaniesPage } from './components/company/CompaniesPage';
import { CreateCompany } from './components/company/CreateCompany';
import { EditCompany } from './components/company/EditCompany';

import { ShopsPage } from './components/shop/ShopsPage';
import { UserManagedShopsPage } from './components/shop/UserManagedShopsPage';
import { CreateShop } from './components/shop/CreateShop';
import { EditShop } from './components/shop/EditShop';
import { ShopDetails } from './components/shop/ShopDetails';

import { ProductsPage } from './components/product/ProductsPage';
import { ShopProductsPage } from './components/product/ShopProductsPage';
import { CreateProduct } from './components/product/CreateProduct';
import { EditProduct } from './components/product/EditProduct';

import { CreatePurchase } from './components/purchase/CreatePurchase';
import { EditPurchase } from './components/purchase/EditPurchase';
import { PurchaseDetails } from './components/purchase/PurchaseDetails';

import { PurchaseDetailsPage } from './components/purchasedetail/PurchaseDetailsPage';
import { CreatePurchaseDetail } from './components/purchasedetail/CreatePurchaseDetail';
import { EditPurchaseDetail } from './components/purchasedetail/EditPurchaseDetail';

import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import { UserProfile } from './components/profile/UserProfile';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.changeSiteLanguage = this.changeSiteLanguage.bind(this);
    }

    changeSiteLanguage() {
        this.forceUpdate();
    }

    render() {
        return (
            <Layout changeSiteLanguage={this.changeSiteLanguage}>
                <Route exact path='/' component={Home} />

                <AuthorizeRoute path='/companies' component={CompaniesPage} />
                <AuthorizeRoute path='/createcompany' component={CreateCompany} />
                <AuthorizeRoute path='/editcompany/:id' component={EditCompany} />

                <AuthorizeRoute path='/shops/:id' component={ShopsPage} />
                <AuthorizeRoute path='/usermanagedshops' component={UserManagedShopsPage} />
                <AuthorizeRoute path='/createshop/:id' component={CreateShop} />
                <AuthorizeRoute path='/editshop/:id' component={EditShop} />
                <AuthorizeRoute path='/shopdetails/:id' component={ShopDetails} />

                <AuthorizeRoute path='/products' component={ProductsPage} />
                <AuthorizeRoute path='/shopproducts' component={ShopProductsPage} />
                <AuthorizeRoute path='/createproduct/:id' component={CreateProduct} />
                <AuthorizeRoute path='/editproduct/:id' component={EditProduct} />

                <AuthorizeRoute path='/createpurchase/:id' component={CreatePurchase} />
                <AuthorizeRoute path='/editpurchase/:id' component={EditPurchase} />
                <AuthorizeRoute path='/purchasedetails/:id' component={PurchaseDetails} />

                <AuthorizeRoute path='/purchasedetailspage/:id' component={PurchaseDetailsPage} />
                <AuthorizeRoute path='/createpurchasedetail/:id' component={CreatePurchaseDetail} />
                <AuthorizeRoute path='/editpurchasedetail/:id' component={EditPurchaseDetail} />

                <AuthorizeRoute path='/userprofile' component={UserProfile} />

                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            </Layout>
        );
    }
}
