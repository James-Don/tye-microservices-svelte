// API helper functions
// Remark - to use do: npm i axios svelte-routing 

import axios from 'axios';
import { navigate } from 'svelte-routing';
import { baseUrlUserSearch, baseUrlUserSignup } from './stores';

export class API 
{

    constructor()
    {
    }

    async userSearchGet(uri) {
        try {
            const response = await axios.get(baseUrlUserSearch + uri);
            this.lastError = '';
            return response.data;
        }
        catch (error) {
            this.checkError(error);
        }
    }

    async userSignupPost(uri, formData) {
        try {
            const response = await axios.post(baseUrlUserSignup + uri, formData); //, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.checkError(error);
        }
    }


    async getFile(uri)
    {
        try
        {
            const response = await axios.get(this.baseurl + uri, { responseType: 'blob' });
            let fileName = "1000.pdf";
            if (response.headers["content-disposition"])
            {
                fileName = response.headers["content-disposition"].split(';')[1];
                fileName = fileName.replace("filename=", "").trim();
            }

            this.lastError = '';
            return { data: response.data, filename: fileName, contentType: "application/binary" };
        } 
        catch (error)
        {
            this.checkError(error);
        }
    }

    async getRaw(uri)
    {
        let response = {};
        try {
            response = await axios.get(this.baseurl + uri); //, { withCredentials: true })
            this.lastError = '';
        } 
        catch (error)
        {
            this.checkError(error);
        }
        return response;
    }


    checkError(error) {
        this.lastError = error.message;
        if (error.response.status === 401 || error.response.status === 403) {
            authToken.set(null);
            navigate('/login');
        } else if (error.response.status === 404) {
            navigate('/notfound');
        }
    }
}