import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:5001',
    headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
    }
});

export const createUserMvc = async (request) => {
    const { data } = await api.post(
        "mvc/user",
        {
            name: request.nameToSend,
            email: request.emailToSend,
            password: request.passwordToSend
        }
    ).catch((e) => e.response);

    return data;
};

export const getUserByIdMvc = async (userId) => {
    const { data } = await api.get(`mvc/user/${userId}`).catch((e) => e.response);
    
    return data;
}

export const createUserMvvm = async (request) => {
    const { data } = await api.post(
        "mvvm/user",
        {
            name: request.nameToSend,
            email: request.emailToSend,
            password: request.passwordToSend
        }
    ).catch((e) => e.response);

    return data;
};

export const getUserByIdMvvm = async (userId) => {
    const { data } = await api.get(`mvvm/user/${userId}`).catch((e) => e.response);
    
    return data;
}