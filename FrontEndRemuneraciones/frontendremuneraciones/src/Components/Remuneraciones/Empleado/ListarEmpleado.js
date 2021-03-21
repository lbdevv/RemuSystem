import React, { useState, useEffect, Fragment } from 'react'
import { NavLink } from 'react-router-dom'
import Global from '../../../Global'
import axios from 'axios'
import LoadSpinner from '../../../assets/LoadSpinner/LoadSpinner'

const ListarEmpleado = () => {

    const [EmpLst, SetEmpleados] = useState([])
    const [file, setFile] = useState('')
    const [filename, setFilename] = useState('Selecciona un archivo')
    // const [isLoaded, setIsLoaded] = useState(false)

    const onChange = e => {
        setFile(e.target.files[0]);
        setFilename(e.target.files[0].name);
    }

    const onSubmit = async e => {
        e.preventDefault();
        const formData = new FormData()
        formData.append('lstEmpleados', file)

        const res = await axios.post(Global.url + 'Empleado/CargarEmpleadosExcel', formData, {
            headers: {
                'Content-type': 'multipart/form-data'
            }
        });
    }

    useEffect(() => {
        GetLstEmpleados()
    }, [])

    const GetLstEmpleados = async () => {
        const data = await fetch(Global.url + 'Empleado/LstEmpleados')
        const Empleados = await data.json()

        SetEmpleados(Empleados)
    }

    return (
        <Fragment>
            <form onSubmit={onSubmit}>
                <div className="form-group col-md-3">

                    <input
                        type="file"
                        className='custom-file-input'
                        name="lstEmpleados"
                        id="lstEmpleados"
                        onChange={onChange} />
                    <label className="custom-file-label" htmlFor="customFile">{filename}</label>
                </div>
                <div className="form-group col-md-3">
                    <button type="submit" className="btn btn-block btn-outline-success btn-sm" >Cargar</button>
                </div>
            </form>
            <br />

            <div className="col-md-12 col-lg-12 col-xs-12">
                <NavLink to="/AgregarEmpleado"> <button className="btn btn-block btn-outline-primary btn-sm">Agregar Empleado </button></NavLink>
            </div>

            <div className="col-lg-12 col-md-12 col-xs-12">
                <div className="card">
                    <div className="card-header">
                        <h3 className="card-title"><strong>Empleados</strong></h3>
                    </div>
                    {EmpLst.length === 0 ?
                        (
                            <LoadSpinner />
                        ) : (
                            <div className="card-body table-responsive p-0">
                                <table className="table table-hover text-nowrap">
                                    <thead>
                                        <tr>
                                            <th>Rut</th>
                                            <th>Nombre</th>
                                            <th>Apellido</th>
                                            <th>Fecha Nacimiento</th>
                                            <th>Editar</th>
                                            <th>Liquidacion</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {EmpLst.map(Emp => (
                                            <tr key={Emp.id}>
                                                <td>{Emp.rut}</td>
                                                <td>{Emp.nombre}</td>
                                                <td>{Emp.apellido}</td>
                                                <td>{Emp.fechaNacimiento}</td>
                                                <td><a className="btn btn-sm btn-primary" href="#">Editar</a></td>
                                                <td><NavLink className="btn btn-sm btn-success" to={"/Liquidacion/" + Emp.id}>Generar</NavLink></td>
                                            </tr>
                                        ))
                                        }
                                    </tbody>
                                </table>
                            </div>
                        )
                    }

                </div>
            </div>
        </Fragment>
    );
}

export default ListarEmpleado;