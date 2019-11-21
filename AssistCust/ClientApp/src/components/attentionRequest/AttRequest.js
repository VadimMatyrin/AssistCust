import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faCheck } from '@fortawesome/free-solid-svg-icons';
import { confirmAlert } from 'react-confirm-alert';
import fetchDataService from '../helpers/FetchDataService'
import 'react-confirm-alert/src/react-confirm-alert.css';
import { LoadingScreen } from '../LoadingScreen';
import { Link } from 'react-router-dom';
import strings from '../../localization/localization';

export class AttRequest extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: false };
        this.submit = this.submit.bind(this);
        this.submitResolve = this.submitResolve.bind(this);
        this.deleteAttRequest = this.deleteAttRequest.bind(this);
        this.resolveRequest = this.resolveRequest.bind(this);
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

    async resolveRequest() {
        this.setState({
            loading: true
        });
        const updatedRequest = this.props.attRequest;
        updatedRequest.isResolved = true;
        updatedRequest.resolveDate = new Date().toISOString();
        const responseCode = await fetchDataService.updateAttRequest(updatedRequest);
        if (responseCode === 204) {
            this.props.triggerAttRequestsFetch();
        }
        this.setState({
            loading: false
        });
    }

    submitResolve() {
        confirmAlert({
            title: strings.confirmToSubmit,
            message: strings.resolveAttRequestMessage,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => this.resolveRequest()
                },
                {
                    label: strings.no
                }
            ]
        });
    };

    submit(productId) {
        confirmAlert({
            title: strings.confirmToSubmit,
            message: strings.deleteAttRequestMessage,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => this.deleteAttRequest(productId)
                },
                {
                    label: strings.no
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
                        <div className="col-lg-4">{attRequest.message}</div>
                        <div className="col-lg-2"><input className="form-control" type="checkbox" checked={attRequest.isResolved} readOnly={attRequest.isResolved} /></div>
                        <div className="col-lg-2">{attRequest.creationDate}</div>
                        <div className="col-lg-2">{attRequest.resolveDate ? attRequest.resolveDate : ""}</div>
                        <div className="col-lg-2">
                            <div className="row">
                                {!attRequest.isResolved && < div className="col-lg-6">
                                    <button type="button" className="btn btn-primary" onClick={this.submitResolve}>
                                        <FontAwesomeIcon icon={faCheck} />
                                    </button>
                                </div>
                                }
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
