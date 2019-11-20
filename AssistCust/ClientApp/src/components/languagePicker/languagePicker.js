import React, { Component } from 'react';
import { NavItem } from 'reactstrap';
import strings from '../../localization/localization';

export class LanguagePicker extends Component {

    constructor(props) {
        super(props);
        this.state = {
            language: null,
            strings: strings,
        };
        history.push({
            pathname: '/',
            search: '?color=blue'
        }) 
    }

    componentDidMount() {
        const lang  = this.props.location.search("lang");
        this.setState({
            language: lang
        });
    }

    changeLanguage(e) {
        const newLanguage = e.target.value;
        strings.setLanguage(newLanguage);
    }

    render() {
        return (
            <NavItem>
                <select class="form-control" onChange={this.changeLanguage}>
                    {this.state.strings.getAvailableLanguages().map((l) => {
                        if (this.state.language === l)
                            return <option value={l} selected="selected">{l.toUpperCase()}</option>
                        return <option value={l}>{l.toUpperCase()}</option>
                    })}
                </select>
            </NavItem>
        );
    }
}
