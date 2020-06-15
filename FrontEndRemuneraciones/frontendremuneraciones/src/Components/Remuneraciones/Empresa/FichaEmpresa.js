import React from 'react';

const FichaEmpresa = () => {
    return(
        <div className="content-wrapper">

        <div className="content-header">
            <div className="container-fluid">
                <div className="row mb-2">
                    <div className="col-md-6"> </div>
                    <div className="col-sm-6">
                        <ol className="breadcrumb float-sm-right">
                            <li className="breadcrumb-item"><a href="#">Home</a></li>
                            <li className="breadcrumb-item active">Starter Page</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div className="content">
             <div className="card card-warning">
                    <div className="card-header">
                        <h3 className="card-title">Ficha Empresa</h3>   
                    </div>
                    <div className="card-body">
                        <form method="post">

                            <div className="form-group col-md-6">
                                <label>Rut</label>
                                <input name="Rut" type="text" className="form-control form-control-sm"  required />
                            </div>
                            <div className="form-group col-md-6">
                                <label>Principal</label><br></br>
                                <input type="checkbox"/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Razon Social</label>
                                <input type="text" className="form-control"/>
                            </div>
                            <div className="form-group col-md-6">
                                <label>Giro</label>
                                <input type="text" className="form-control"/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Dirección</label>
                                <input type="text" className="form-control"/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Representante Legal</label>
                                <input type="text" className="form-control"/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Rut Representante Legal</label>
                                <input type="text" className="form-control"/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Caja de compensación</label>
                                <select className="form-control">
                                    <option>(Falta por rellenar)</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Comuna</label>
                                <select className="form-control">
                                    <option>(Falta por rellenar)</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Telefono</label>
                                <input type="number" className="form-control" />
                            </div>

                            <div className="form-group col-md-6">
                                <label>Banco pago nomina</label>
                                <select className="form-control">
                                    <option>(Falta por rellenar)</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Cuenta corriente pago nomina</label>
                                <input type="text" className="form-control" />
                            </div>

                            <div className="form-group col-md-6">
                                <label>Vigente</label><br/>
                                <input type="checkbox" />
                            </div>

                            <div className="form-group col-md-6">
                                <label>Forma de pago gratificación</label>
                                <select className="form-control">
                                    <option>(Falta por rellenar)</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Forma de pago movilización/Colación</label>
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
        </div>

    </div>
        
    );
}

export default FichaEmpresa;