import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';

export class AttRequest extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: false };
        this.submit = this.submit.bind(this);
        this.deleteAttRequest = this.deleteAttRequest.bind(this);
    }

    async deleteAttRequest(attRequestId) {
        this.setState({
            loading: true
        });
        const responseCode = await fetchDataService.deleteAttRequest(attRequestId);
        if (responseCode === 204) {
            this.props.triggerAttRequestsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submit(productId) {
        confirmAlert({
            title: 'Confirm to submit',
            message: `Are you sure you want to delete this attention request?`,
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.deleteAttRequest(productId)
                },
                {
                    label: 'No'
                }
            ]
        });
    };
    render() {
        const attRequest = this.props.attRequest;
        return (
            <>
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6">{attRequest.message}</div>
                        <div className="col-lg-2"><input className="form-control" type="checkbox" checked={attRequest.isResolved} disabled /></div>
                        <div className="col-lg-2">{attRequest.creationDate}</div>
                        <div className="col-lg-2">
                            <div className="row">
                                <div className="col-lg-6">
                                    <Link to={{
                                        pathname: '/editattRequest',
                                        attRequest: attRequest
                                    }}
                                    >
                                        <button type="button" className="btn btn-primary">
                                            <FontAwesomeIcon icon={faWrench} />
                                        </button>
                                    </Link >
                                </div>
                                <div className="col-lg-6">
                                    <button type="button" className="btn btn-danger" onClick={(e) => this.submit(this.props.attRequest.id)}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                {this.state.loading && <LoadingScreen />}
            </>
        );
    }
}
