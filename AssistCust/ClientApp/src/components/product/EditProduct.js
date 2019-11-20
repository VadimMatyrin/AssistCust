import React, { Component } from 'react';
import fetchDataService from '../helpers/FetchDataService'
import { Redirect } from 'react-router-dom';
import { LoadingScreen } from '../LoadingScreen';

export class EditProduct extends Component {

    constructor(props) {
        super(props);
        this.state = {
            product: null,
            name: null,
            price: null,
            description: null,
            loading: false,
            redirect: false
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fetchForProduct = this.fetchForProduct.bind(this);
    }

    componentDidMount() {
        if (this.props.location.product) {
            const product = this.props.location.product;
            this.setState({
                product: product,
                name: product.name,
                price: product.price,
                description: product.description,
            });
        } else {
            this.fetchForProduct();
        }

    }

    async fetchForProduct() {
        const { id } = this.props.match.params
        const product = await fetchDataService.getProduct(id);
        this.setState({
            product: product,
            name: product.name,
            price: product.price,
            description: product.description,
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
        const product = {
            id: this.state.product.id,
            name: this.state.name,
            price: parseFloat(this.state.price),
            description: this.state.description
        }
        const createdId = await fetchDataService.updateProduct(product);
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
            return (<Redirect to="/companies" />);
        }
        const { product } = this.state;
        if (!product) {
            return (<LoadingScreen />);
        }
        return (
            <fieldset disabled={this.state.loading}>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="name">
                                Product name:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="name"
                                type="text"
                                className="form-control"
                                id="name"
                                value={this.state.name}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="description">
                                Description:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="description"
                                type="text"
                                className="form-control"
                                id="description"
                                value={this.state.description}
                                onChange={this.handleInputChange} />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2">
                            <label for="price">
                                Price:
                        </label>
                        </div>
                        <div className="col-sm-6">
                            <input
                                name="price"
                                type="number"
                                min="0"
                                step="0.01"
                                className="form-control"
                                id="price"
                                value={this.state.price}
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