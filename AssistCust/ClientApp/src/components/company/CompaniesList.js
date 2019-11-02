import React, { Component } from 'react';
import { Company } from './Company';

export class CompaniesList extends Component {

    render() {
        return (
            <ul class="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6"><b>Shop name</b></div>
                        <div className="col-lg-4"><b>Country</b></div>
                        <div className="col-lg-2"><b>Actions</b></div>
                    </div>
                </li>
                {this.props.companies.map((company) => {
                    return (<Company company={company} triggerCompaniesFetch={this.props.triggerCompaniesFetch}></Company>);
                })}
            </ul>
        );
    }
}
