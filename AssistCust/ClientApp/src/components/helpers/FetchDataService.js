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

    async updateCompany(company) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(company),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deleteCompany(companyId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/Delete/' + companyId, {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`
            },
            method: 'DELETE'
        });
        const responseCode = response.status;
        return responseCode;
    }

    async getAllCompanyShopsByCompany(companyId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/CompanyShops/GetAllCompanyShopsByCompany/' + companyId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.companyShops;
    }

    async createShop(shop) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/CompanyShops/Create', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(shop),
        });
        const companyId = await response.json();
        return companyId;
    }

    async updateShop(shop) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/CompanyShops/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(shop),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deleteShop(shopId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/CompanyShops/Delete/' + shopId, {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`
            },
            method: 'DELETE'
        });
        const responseCode = response.status;
        return responseCode;
    }

}

const fetchDataService = new FetchDataService();

export default fetchDataService;