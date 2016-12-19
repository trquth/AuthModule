class FetchHelper {
    constructor() {
        this.defaultHeaders = {
            'Content-Type': 'application/json'
        }
    }
    fetch(input, init = {}) {
        let initWithDefaultHeaders = {
            ...init,
            headers: this.defaultHeaders
        }

        return new Promise((resolve, reject) => {
            fetch.apply(null, [input, initWithDefaultHeaders])
                .then(response => {
                    resolve(response.json)
                }, response => {
                    reject(response)
                })
        })
    }
}

const fetchHelperInstance = new FetchHelper()

export default fetchHelperInstance