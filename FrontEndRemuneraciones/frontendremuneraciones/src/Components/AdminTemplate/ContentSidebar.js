import React from 'react';
import { useHistory } from 'react-router-dom'

const ContentSidebar = () => {

    const history = useHistory()
    const logout = () => {
        localStorage.removeItem('token')
        history.push('/')
    }

    return (
        <aside className="control-sidebar control-sidebar-dark">
            <div className="p-3">
                <h5>Opciones</h5>
                <ul>
                    <li><button onClick={logout} className="btn btn-danger">Cerrar Sesion</button></li>
                </ul>
            </div>
        </aside>
    )
}

export default ContentSidebar;