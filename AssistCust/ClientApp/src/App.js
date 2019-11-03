import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';

import { CompaniesPage } from './components/company/CompaniesPage';
import { CreateCompany } from './components/company/CreateCompany';
import { EditCompany } from './components/company/EditCompany';

import { ShopsPage } from './components/shop/ShopsPage';
import { CreateShop } from './components/shop/CreateShop';
import { EditShop } from './components/shop/EditShop';

import { ProductsPage } from './components/product/ProductsPage';
import { CreateProduct } from './components/product/CreateProduct';
import { EditProduct } from './components/product/EditProduct';

import { Counter } from './components/Counter';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />

                <AuthorizeRoute path='/companies' component={CompaniesPage} />
                <AuthorizeRoute path='/createcompany' component={CreateCompany} />
                <AuthorizeRoute path='/editcompany' component={EditCompany} />

                <AuthorizeRoute path='/shops' component={ShopsPage} />
                <AuthorizeRoute path='/createshop' component={CreateShop} />
                <AuthorizeRoute path='/editshop' component={EditShop} />

                <AuthorizeRoute path='/products' component={ProductsPage} />
                <AuthorizeRoute path='/createproduct' component={CreateProduct} />
                <AuthorizeRoute path='/editproduct' component={EditProduct} />

                <AuthorizeRoute path='/fetch-data' component={FetchData} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            </Layout>
        );
    }
}
