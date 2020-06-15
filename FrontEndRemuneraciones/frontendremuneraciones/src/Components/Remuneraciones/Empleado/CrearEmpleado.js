import React from 'react';
import {NavLink} from 'react-router-dom';

const CrearEmpleado = () => {
    let Nav = "Agregar Empleado";
    let Inicio = "Página de inicio";
    return (
        
        <div className="content-wrapper">

            <div className="content-header">
                <div className="container-fluid">
                    <div className="row mb-2">
                        <div className="col-md-6"> </div>
                        <div className="col-sm-6">
                            <ol className="breadcrumb float-sm-right">
                                <li className="breadcrumb-item">{Nav}</li>
                                <li className="breadcrumb-item active"><NavLink to="/">{Inicio}</NavLink></li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div className="content">
                <div className="card card-info">
                    <div className="card-header">
                        <h3 className="card-title">Ficha Empleado</h3>
                    </div>
                    <div className="card-body">
                        <form method="post">

                            <div className="form-group col-md-6">
                                <label>Rut</label>
                                <input name="Rut" type="text" className="form-control form-control-sm"  required />

                            </div>

                            <div className="form-group col-md-6">
                                <label>Nombre</label>
                                <input name="Nombre" type="text" className="form-control form-control-sm"   required />

                            </div>

                            <div className="form-group col-md-6">
                                <label>Apellido</label>
                                <input name="Apellido" type="text" className="form-control form-control-sm"   required />

                            </div>

                            <div className="form-group col-md-6">
                                <label>Fecha de Nacimiento</label>
                                <input name="" className="form-control n-date" type="text"  required />
                            </div>

                            <div className="form-group col-md-3" >
                                <label>Sexo</label>
                                <select className="form-control" required>
                                    <option>Hombre</option>
                                    <option>Mujer</option>
                                    <option>Otro</option>
                                </select>
                            </div>

                            <div className="form-group col-md-3">
                                <select className="form-control" name="Nacionalidad" required>
                                    <option value="0">Chile</option>
                                    <option value="1">Mongolia</option>
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

export default CrearEmpleado;