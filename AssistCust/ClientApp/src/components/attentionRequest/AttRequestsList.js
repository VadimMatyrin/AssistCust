import React, { Component } from 'react';
import { AttRequest } from './AttRequest';

export class AttRequestsList extends Component {

    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6">Message</div>
                        <div className="col-lg-2">isResolved</div>
                        <div className="col-lg-2">creationDate</div>
                        <div className="col-lg-2"><b>Actions</b></div>
                    </div>
                </li>
                {this.props.attRequests.map((attRequest) => {
                    return (<AttRequest attRequest={attRequest} triggerAttRequestsFetch={this.props.triggerAttRequestsFetch}></AttRequest>);
                })}
            </ul>
        );
    }
}
