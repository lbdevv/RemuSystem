import React from 'react'

const AFPUpdateModule = () => {
    return(
        <div className="col-md-12 my-5">
            <div className="form-group row">
                <div className="col-md-3">
                    <label>Selecciona AFP</label>
                    <select className="form-control form-control-sm">
                        <option>Selecciona</option>
                    </select>
                </div>
                <div className="col-md-3">
                    <label>Porcentaje Tasa AFP <span className="text-muted">Escribe el valor en decimales</span></label>
                    <input type="number" className="form-control form-control-sm"/>
                </div>

                <div className="col-md-3">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date" />
                </div>

            </div>

            <div className="form-group row">
                <div className="col-md-4">
                <button className="btn btn-block btn-outline-success btn-sm">Guardar</button>
                </div>

            </div>
        </div>
    )
}

export default AFPUpdateModule