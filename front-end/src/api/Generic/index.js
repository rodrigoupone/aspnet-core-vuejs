import constantes from '../../constantes'

let apiResponse = {
    success: false,
    data: [],
    status: null
}


export const PostRest = async (data, route, instanteVue) => {
    const config = { headers: { 'Content-Type': 'application/json' } };
    return instanteVue.$http.post(constantes.URLAPI + route, data, config)
        .then((response) => {
            apiResponse.data = response.data.data;
            apiResponse.success = true;
            apiResponse.status = response.data.status;
            return apiResponse;

        })
        .catch((erro) => {
            apiResponse.success = false;
            apiResponse.data = erro;
            apiResponse.status = erro.status;
            return apiResponse;
        });
}

export const PutRest = async (data, route, instanteVue) => {
    const config = { headers: { 'Content-Type': 'application/json' } };
    return instanteVue.$http.put(constantes.URLAPI + route, data, config)
        .then((response) => {
            apiResponse.data = response.data;
            apiResponse.success = true;
            return apiResponse;

        })
        .catch((erro) => {
            apiResponse.success = false;
            apiResponse.data = erro;
            apiResponse.status = erro.status;
            return apiResponse;
        });
}

export const DelRest = async (route, instanteVue) => {
    const config = { headers: { 'Content-Type': 'application/json'} };
    return instanteVue.$http.delete(constantes.URLAPI + route, config)
        .then((response) => {
            apiResponse.data = response.data.data;
            apiResponse.success = true;
            apiResponse.status = response.data.status;
            return apiResponse;

        })
        .catch((erro) => {
            apiResponse.success = false;
            apiResponse.data = erro;
            apiResponse.status = erro.status;
            return apiResponse;
        });
}



export const GetRest = async (route, instanteVue) => {

    return instanteVue.$http.get(constantes.URLAPI + route)
        .then((response) => {
            apiResponse.data = response.data.data;
            apiResponse.success = true;
            apiResponse.status = response.data.status;
            return apiResponse;

        })
        .catch((erro) => {
            apiResponse.success = false;
            apiResponse.data = erro;
            apiResponse.status = erro.status;
            return apiResponse;
        });
}
