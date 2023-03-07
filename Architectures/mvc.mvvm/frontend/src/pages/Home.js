import React, { useEffect, useState } from 'react';
import { createUserMvc, getUserByIdMvc, createUserMvvm, getUserByIdMvvm } from '../api';

export default function HomeMvc() {
    const [pageTitle, setPageTitle] = useState('MVC');
    const [changePageTitle, setChangePageTitle] = useState('MVVM');
    const [nameToSend, setNameToSend] = useState('');
    const [emailToSend, setEmailToSend] = useState('');
    const [passwordToSend, setPasswordToSend] = useState('');
    const [getCreatedUserButtonDisabled, setGetCreatedUserButtonDisabled] = useState(true);
    const [createUserButtonDisabled, setCreateUserButtonDisabled] = useState(true);

    const [createdUserId, setCreatedUserId] = useState('');

    const [apiResponseData, setApiResponseData] = useState('');

    const inputHandler = {
        nameToSend: (value) => { setNameToSend(value) },
        emailToSend: (value) => { setEmailToSend(value) },
        passwordToSend: (value) => { setPasswordToSend(value) }
    }

    const genericHandler = ({ target: { value, name } }) => {
        inputHandler[name](value);
    }

    const createUser = async () => {
        if (pageTitle === 'MVC') {
            setCreatedUserId(await createUserMvc({ nameToSend, emailToSend, passwordToSend }));
        } else {
            setCreatedUserId(await createUserMvvm({ nameToSend, emailToSend, passwordToSend }));
        }

        setGetCreatedUserButtonDisabled(false);
    }

    const getUserById = async () => {
        if (pageTitle === 'MVC') {
            setApiResponseData(await getUserByIdMvc(createdUserId));
        } else {
            setApiResponseData(await getUserByIdMvvm(createdUserId));
        }
    }

    const resetFlow = () => {
        window.location.reload(false);
    }

    const switchPage = () => {
        let tempPageTitle = pageTitle;
        setPageTitle(changePageTitle)
        setChangePageTitle(tempPageTitle)

        setNameToSend('')
        setEmailToSend('')
        setPasswordToSend('')
        setGetCreatedUserButtonDisabled(true)
        setCreateUserButtonDisabled(true)
        setCreatedUserId('')
        setApiResponseData('')
    }


    useEffect(() => {
        if (nameToSend.length > 0 &&
            emailToSend.length > 0 &&
            passwordToSend.length > 0) {
            setCreateUserButtonDisabled(false);
        } else {
            setCreateUserButtonDisabled(true);
        }
    }, [nameToSend,
        emailToSend,
        passwordToSend,
        createdUserId,
        apiResponseData]);

    return (
        <div>
            <h1 className="page-title">{pageTitle}</h1>
            <div className="container text-center all-inputs">
                <div class="container col">
                    <div className="mb-3">
                        <label
                            for="NameInput"
                            className="form-label input">
                            Name
                        </label>
                        <input
                            name="nameToSend"
                            className="form-control"
                            id="NameInput"
                            onChange={(event) => { genericHandler(event) }} />
                    </div>
                    <div className="mb-3">
                        <label
                            for="EmailInput"
                            className="form-label input">
                            Email address
                        </label>
                        <input
                            name="emailToSend"
                            className="form-control"
                            id="EmailInput"
                            onChange={(event) => { genericHandler(event) }} />
                    </div>
                    <div className="mb-3">
                        <label
                            for="PasswordInput"
                            className="form-label input">
                            Password
                        </label>
                        <input
                            name="passwordToSend"
                            type="password"
                            className="form-control"
                            id="PasswordInput"
                            onChange={(event) => { genericHandler(event) }} />
                    </div>
                    <button
                        type="button"
                        className="btn btn-primary"
                        onClick={createUser}
                        disabled={createUserButtonDisabled}>
                        Create User
                    </button>
                </div>
                <div class="container col">
                    <div>
                        <div className="mb-3">
                            <label
                                for="NameFromResponse"
                                className="form-label input">
                                Name
                            </label>
                            <input
                                name="NameFromResponse"
                                className="form-control"
                                id="NameFromResponse"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.name} />
                        </div>
                        <div className="mb-3">
                            <label
                                for="emailFromResponse"
                                className="form-label input">
                                Email address
                            </label>
                            <input
                                name="emailFromResponse"
                                className="form-control"
                                id="emailFromResponse"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.email} />
                        </div>
                        <button
                            type="button"
                            className="btn btn-success"
                            onClick={getUserById}
                            disabled={getCreatedUserButtonDisabled}>
                            Get Created User
                        </button>
                    </div>
                </div>
                <div className="container col">
                    <label
                        for="DataFromResponse"
                        className="form-label input">
                        Data returned from the API when the created user name and email were requested:
                    </label>
                    {apiResponseData.id ?
                        <div class="input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Id</span>
                            <input
                                className="form-control"
                                id="DataFromResponse"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.id} />
                        </div> : null}
                    {apiResponseData.name ?
                        <div class="input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Name</span>
                            <input
                                className="form-control"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.name} />
                        </div> : null}
                    {apiResponseData.email ?
                        <div class="input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Email</span>
                            <input
                                className="form-control"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.email} />
                        </div> : null}
                    {apiResponseData.password ?
                        <div class="input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Password</span>
                            <input
                                className="form-control"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.password} />
                        </div> : null}
                    {apiResponseData.createdAt ?
                        <div class="input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Creation Date</span>
                            <input
                                className="form-control"
                                readonly="readonly"
                                onChange={(event) => { genericHandler(event) }}
                                defaultValue={apiResponseData.createdAt} />
                        </div> : null}
                </div>
            </div>
            <div className="container container-bottom">
                <div>
                    <button
                        type="button"
                        className="btn btn-danger"
                        onClick={resetFlow}>
                        Reset Flow
                    </button>
                </div>
                <div>
                    <button
                        type="button"
                        className="btn btn-primary"
                        onClick={switchPage}>
                        Go to {changePageTitle} Page
                    </button>
                </div>
            </div>
        </div>
    )
}