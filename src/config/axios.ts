import axios from 'axios'

const instance = axios.create({
    baseURL: 'http://localhost:5090'
});

instance.defaults.withCredentials = false

// // Alter defaults after instance has been created
if (typeof window !== 'undefined') {
    instance.defaults.headers.common['Authorization'] = "*";
}

// Add a request interceptor
instance.interceptors.request.use(function (config) {
    // Do something before request is sent

    instance.defaults.headers.common['Content-Type'] = "application/json";
    return config;
}, function (error) {
    // Do something with request error
    return Promise.reject(error);
});

// Add a response interceptor
instance.interceptors.response.use(function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    instance.defaults.headers.common['Authorization'] = localStorage.getItem('accessToken') ? localStorage.getItem('accessToken') : "*";
    return response.data;
}, function (err) {
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    const status = err.response?.status || 500
    switch (status) {
        // authentication (token related issues)
        // case 401: {

        //     return {
        //         err
        //     }
        // }

        // forbidden (permission related issues)
        // case 403: {
        //     return Promise.reject(err)
        // }

        // // bad request
        // case 400: {
        //     return Promise.reject(err)
        // }

        // // not found
        // case 404: {
        //     return Promise.reject(err)
        // }

        // // conflict
        // case 409: {
        //     return Promise.reject(err)
        // }

        // // unprocessable
        // case 422: {
        //     return Promise.reject(err)
        // }

        // generic api error (server related) unexpected
        default: {
            return Promise.reject(err)
        }
    }
}

);

export default instance