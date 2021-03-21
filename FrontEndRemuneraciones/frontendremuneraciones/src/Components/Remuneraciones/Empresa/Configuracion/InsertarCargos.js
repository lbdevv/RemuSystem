import React from 'react'
import { useForm } from 'react-hook-form';
import Global from '../../../../Global'
import axios from 'axios'

const InsertarCargos = () => {

    const { register, errors, handleSubmit } = useForm()
    const AgregarCargo = (data, e) =>{
        e.target.reset()
        axios.post(Global.url + 'Empresa/CargoAgregar',JSON.stringify(data),{
            headers:{
                'Content-Type':'application/json'
            }
        })
             .then(res => console.log(res))
             .catch(err => console.log(err))
    }


    return(
        <div className="col-lg-12 col-md-12 col-xs-12">
            <div className="card">
                <div className="card-header">
                    <h3><strong>Agregar Cargo</strong></h3>
                </div>
                <div className="card-body">
                    <form method="post" onSubmit={handleSubmit(AgregarCargo)}>
                        <div className="form-group row">
                            <div className="col-md-2">
                                    <label>Añadir Cargo:</label>
                            </div>
                            <div className="col-md-4">
                                    <input className="form-control form-control-sm" name="Nombre"                            
                                    ref={
                                        register({
                                            required: { value: true, message: 'El Campo es obligatorio' }
                                        })
                                    } />
                                    <span className="text-danger text-small d-block mb-2">
                                        {errors?.Nombre?.message}
                                    </span>
                        </div>
                            <div className="col-md-2">
                                <button type="submit" className="btn btn-block btn-outline-success btn-sm">Agregar</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default InsertarCargos

