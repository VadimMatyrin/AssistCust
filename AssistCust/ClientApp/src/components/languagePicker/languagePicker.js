import React, { Component } from 'react';
import { NavItem } from 'reactstrap';
import strings from '../../localization/localization';


export class LanguagePicker extends Component {

    constructor(props) {
        super(props);
        const [value, setValue] = this.useStateWithLocalStorage(
            'AssistCustLang'
        );
        let language = value;
        if (language === null || language === "null") {
            language = "en";
            setValue(language);
        }
        this.state = {
            language: language,
            cacheLang: setValue,
            strings: strings,
        };
        this.changeLanguageFromSelect = this.changeLanguageFromSelect.bind(this);
        this.changeLanguage = this.changeLanguage.bind(this);
        this.changeLanguage(language);
    }

    useStateWithLocalStorage(localStorageKey) {
        const setValue = function (value) {
            localStorage.setItem(localStorageKey, value);
        };
        const retrievedValue = localStorage.getItem(localStorageKey) || null;
        return [retrievedValue, setValue];
    };

    changeLanguageFromSelect(e) {
        const newLanguage = e.target.value;
        this.changeLanguage(newLanguage);
    }

    changeLanguage(newLanguage) {
        this.state.cacheLang(newLanguage);
        strings.setLanguage(newLanguage);
        this.props.changeSiteLanguage();
    }

    render() {
        return (
            <NavItem>
                <select className="form-control" onChange={this.changeLanguageFromSelect} defaultValue={this.state.language}>
                    {this.state.strings.getAvailableLanguages().map((l) => {
                        return <option value={l} key={l}>{l.toUpperCase()}</option>
                    })}
                </select>
            </NavItem>
        );
    }
}
