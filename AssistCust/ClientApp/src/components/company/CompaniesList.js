import React, { Component } from 'react';
import { Company } from './Company';
import strings from '../../localization/localization';

export class CompaniesList extends Component {

    render() {
        return (
            <ul className="list-group">
                <li className="list-group-item">
                    <div className="row">
                        <div className="col-lg-6"><b>{strings.companyName}</b></div>
                        <div className="col-lg-4"><b>{strings.country}</b></div>
                        <div className="col-lg-2"><b>{strings.actions}</b></div>
                    </div>
                </li>
                {this.props.companies.map((company) => {
                    return (<Company company={company} triggerCompaniesFetch={this.props.triggerCompaniesFetch} key={company.id}></Company>);
                })}
            </ul>
        );
    }
}
