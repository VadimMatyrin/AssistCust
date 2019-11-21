import React, { Component } from 'react';
import { AttRequest } from './AttRequest';
import strings from '../../localization/localization';

export class AttRequestsList extends Component {

    render() {
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-4">{strings.message}</div>
                        <div className="col-lg-2">{strings.isResolved}</div>
                        <div className="col-lg-2">{strings.createdDate}</div>
                        <div className="col-lg-2">{strings.resolveDate}</div>
                        <div className="col-lg-2"><b>{strings.actions}</b></div>
                    </div>
                </li>
                {this.props.attRequests.map((attRequest) => {
                    return (<AttRequest attRequest={attRequest} triggerAttRequestsFetch={this.props.triggerAttRequestsFetch}></AttRequest>);
                })}
            </ul>
        );
    }
}
