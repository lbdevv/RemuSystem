import React from 'react'

const APVUpdateModule = () =>{
    return(
        <div className="col-md-12 my-5">
            <div className="form-group row">
                <div className="col-md-3">
                    <label>Monto Tope APV Mensual</label>
                    <input type="number" className="form-control form-control-sm"/>
                </div>
                <div className="col-md-3">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date"/>
                </div>
                <div className="col-md-3">
                    <label className="esconderLabel">1</label>
                    <button className="btn btn-block btn-outline-success btn-sm">Guardar</button>
                </div>
            </div>

            <div className="form-group row">
                <div className="col-md-3">
                    <label>Monto Tope APV Anual</label>
                    <input type="number" className="form-control  form-control-sm"/>
                </div>
                <div className="col-md-3">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date"/>
                </div>
                <div className="col-md-3">
                    <label className="esconderLabel">1</label>
                    <button className="btn btn-block btn-outline-success btn-sm">Guardar</button>
                </div>
                
            </div>

        </div>
    )
}

export default APVUpdateModule