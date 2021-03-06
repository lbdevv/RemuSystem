import React from 'react';

const Prevision = () => {
    return (
        <div className="card card-info">
            <div className="card-header">
                <h3 className="card-title">Previsión</h3>
            </div>
            <div className="card-body">
                <form method="post">
                    <div className="form-group col-md-6">
                        <label>AFP</label>
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>
                    <div className="form-group col-md-6">
                        <label>Isapre</label>
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <div className="row col-md-6">
                            <label>Monto pactado Isapre</label>
                            <select className="form-control">
                                <option>(Falta por rellenar)</option>
                            </select>

                            <input className="form-control" />
                        </div>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Es pensionado?</label>
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Tramo de asignación familiar</label>
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Nivel Sence</label>
                        <input type="text" className="form-control" />
                    </div>

                    <div className="form-group col-md-6">
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Trabajo pesado - Porcentaje de cotización adicional</label>
                        <input type="number" className="form-control" />
                    </div>

                    <div className="form-group col-md-6">
                        <select className="form-control">
                            <option>(Falta por rellenar)</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <button type="submit" className="btn btn-block btn-outline-primary btn-sm">Guardar</button>
                    </div>


                </form>
            </div>
        </div>
    );
}

export default Prevision;