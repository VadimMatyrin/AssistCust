import authService from '../api-authorization/AuthorizeService';

export class FetchDataService {
    async getAllUserCompaniesAsync() {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/GetAllCompaniesByUser', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.companies;
    }

    async getCompany(companyId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Companies/Get/' + companyId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json;
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

    async getShop(shopId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/CompanyShops/Get/' + shopId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json;
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
        const shopId = await response.json();
        return shopId;
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

    async getAllProductsByCompany(companyId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Products/GetAllProductsByCompany/' + companyId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.products;
    }

    async getProduct(productId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Products/Get/' + productId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json;
    }

    async createProduct(product) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Products/Create', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(product),
        });
        const productId = await response.json();
        return productId;
    }

    async updateProduct(product) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Products/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(product),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deleteProduct(productId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Products/Delete/' + productId, {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`
            },
            method: 'DELETE'
        });
        const responseCode = response.status;
        return responseCode;
    }

    async getAllShopAttentionRequests(shopId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/AttentionRequest/GetAllShopAttentionRequests/' + shopId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.attentionRequests;
    }

    async updateAttRequest(attRequest) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/AttentionRequest/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(attRequest),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deleteAttRequest(attRequestId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/AttentionRequest/Delete/' + attRequestId, {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`
            },
            method: 'DELETE'
        });
        const responseCode = response.status;
        return responseCode;
    }

    async getAllPurchasesByShop(shopId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Purchases/GetAllPurchasesByShop/' + shopId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.purchases;
    }

    async getPurchase(purchaseId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Purchases/Get/' + purchaseId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json;
    }

    async createPurchase(purchase) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Purchases/Create', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(purchase),
        });
        const purchaseId = await response.json();
        return purchaseId;
    }

    async updatePurchase(purchase) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Purchases/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(purchase),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deletePurchase(purchaseId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/Purchases/Delete/' + purchaseId, {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`
            },
            method: 'DELETE'
        });
        const responseCode = response.status;
        return responseCode;
    }

    async getAllPurchaseDetailsByPurchase(purchaseId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/PurchaseDetails/GetAllPurchaseDetailsByPurchase/' + purchaseId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json.purchaseDetails;
    }

    async getPurchaseDetail(purchaseDetailId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/PurchaseDetails/Get/' + purchaseDetailId, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const json = await response.json();
        return json;
    }

    async createPurchaseDetail(purchaseDetail) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/PurchaseDetails/Create', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'POST',
            body: JSON.stringify(purchaseDetail),
        });
        const purchaseId = await response.json();
        return purchaseId;
    }

    async updatePurchaseDetail(purchaseDetail) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/PurchaseDetails/Update', {
            headers: !token ? {} : {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            method: 'PUT',
            body: JSON.stringify(purchaseDetail),
        });
        const responseCode = response.status;
        return responseCode;
    }

    async deletePurchaseDetail(purchaseDetailId) {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/PurchaseDetails/Delete/' + purchaseDetailId, {
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