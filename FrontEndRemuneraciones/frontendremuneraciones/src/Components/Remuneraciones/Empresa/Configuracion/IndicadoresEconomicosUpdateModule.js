import React from 'react'

const IndicadoresEconomicosUpdateModule = () => {
    return (
        <div className="col-md-12 my-5">
            <div className="form-group row">
                <div className="col-md-4">
                    <label>UF</label>
                    <input type="number" className="form-control form-control-sm" name="UF" required/>
                </div>
                <div className="col-md-4">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date" required/>
                </div>

            </div>
            <div className="form-group  row">


                <div className="col-md-4">
                    <label>UTM</label>
                    <input type="number" className="form-control form-control-sm" name="UTM" required/>

                </div>
                <div className="col-md-4">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date" required/>
                </div>

            </div>
            <div className="form-group row">
                <div className="col-md-4">
                    <label>IMM</label>
                    <input type="number" className="form-control form-control-sm" name="IMM" required/>
                </div>
                <div className="col-md-4">
                    <label>Fecha</label>
                    <input className="form-control form-control-sm n-date" name="FechaCambio" required/>
                </div>
            </div>

            <div className="form-group row">
                <div className="col-md-4">
                    <button type="submit" className="btn btn-block btn-outline-success btn-sm">Guardar</button>
                </div>
            </div>
        </div>
    )
}

export default IndicadoresEconomicosUpdateModule