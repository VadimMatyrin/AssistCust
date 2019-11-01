import authService from '../api-authorization/AuthorizeService'

export class FetchDataService {
    async getAllUserCompaniesAsync() {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/GetAllCompaniesByUser', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.companies;
    }

    async createCompany(company) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/Create', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(company),
        });
        const companyId = await response.json();
        return companyId;
    }
}

const fetchDataService = new FetchDataService();

export default fetchDataService;