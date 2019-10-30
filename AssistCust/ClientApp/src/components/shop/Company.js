import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

export class Company extends Component {
    render() {
        const company = this.props.company;
        return (
            <li className="list-group-item">
                <div className="row">
                    <div className="col-lg-6">{company.name}</div>
                    <div className="col-lg-4">{company.country}</div>
                    <div className="col-lg-2">
                        <div className="row">
                            <div className="col-lg-4">
                                <button type="button" className="btn btn-info">
                                    <FontAwesomeIcon icon={faWrench} />
                                </button>
                            </div>
                            <div className="col-lg-4">
                                <button type="button" className="btn btn-danger">
                                    <FontAwesomeIcon icon={faTrash} />
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        );
    }
}
