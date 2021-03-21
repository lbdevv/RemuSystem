import React from 'react'
import {NavLink} from  'react-router-dom'
const Reportes = () => {
    return (
        <div className="col-lg-12 col-md-12 col-xs-12">
            <div className="card">
                <div className="card-header">
                    <h3 className="card-title"><strong>Reportes</strong></h3>
                </div>
                <div className="card-body">
                    <ul>
                        <li><NavLink to="/Reportes/LibroRemuneraciones">Libro de Remuneraciones</NavLink></li>
                    </ul>
                    
                </div>
            </div>
        </div>
    )
}

export default Reportes