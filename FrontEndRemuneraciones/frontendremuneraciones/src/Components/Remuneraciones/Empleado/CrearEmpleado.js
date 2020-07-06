import React, { useEffect } from 'react';
import $ from 'jquery';
import { useForm } from 'react-hook-form';
import Global from '../../../Global';
import axios from 'axios';

const CrearEmpleado = () => {
    
    useEffect(() => {
        $(".n-date").datepicker({
            format: "dd-mm-yyyy"
        });
    }, [])

    const { register, errors, handleSubmit } = useForm();

    const onSubmit = (data, e) => {

        e.target.reset();

        axios.post(Global.url + 'Empleado/AgregarEmpleado', data)
            .then(res => {
                console.log(res.data);
            })
    }

    return (
        <div className="card card-info">
            <div className="card-header">
                <h3 className="card-title">Ficha Empleado</h3>
            </div>
            <div className="card-body">
                <form method="post" onSubmit={handleSubmit(onSubmit)}>

                    <div className="form-group col-md-6">
                        <label>Rut</label>
                        <input name="Rut" type="text" className="form-control form-control-sm" ref={register()} />

                    </div>

                    <div className="form-group col-md-6">
                        <label>Nombre</label>
                        <input name="Nombre" type="text" className="form-control form-control-sm"
                            ref={
                                register({
                                    required: { value: true, message: 'Nombre Obligatorio' }
                                })
                            }
                        />
                        <span className="text-danger text-small d-block mb-2">
                            {errors?.Nombre?.message}
                        </span>

                    </div>

                    <div className="form-group col-md-6">
                        <label>Apellido</label>
                        <input name="Apellido" type="text" className="form-control form-control-sm" ref={register()} />

                    </div>

                    <div className="form-group col-md-6">
                        <label>Fecha de Nacimiento</label>
                        <input name="FechaNacimiento" className="form-control n-date" type="text" />
                    </div>

                    <div className="form-group col-md-3" >
                        <label>Sexo</label>
                        <select className="form-control" name="Sexo">
                            <option>Hombre</option>
                            <option>Mujer</option>
                            <option>Otro</option>
                        </select>
                    </div>

                    <div className="form-group col-md-3">
                        <select className="form-control" name="Nacionalidad" >
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
    );
}

export default CrearEmpleado;