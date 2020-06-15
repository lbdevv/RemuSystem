import React,{useState,useEffect} from 'react';
import { NavLink } from 'react-router-dom';
import Global from '../../../Global';

const ListarEmpleado = () => {

    

    const [EmpLst, SetEmpleados] = useState([])


    useEffect(() => {
        GetLstEmpleados()
    }, [])

    const GetLstEmpleados = async () => {
        const data = await fetch(Global.url + 'Empleado/LstEmpleados')
        const Empleados = await data.json()

        SetEmpleados(Empleados);
    }

    let Nav = "Empleados"
    return (
        <div className="content-wrapper">

            <div className="content-header">
                <div className="container-fluid">
                    <div className="row mb-2">
                        <div className="col-md-6"> </div>
                        <div className="col-sm-6">
                            <ol className="breadcrumb float-sm-right">
                                <li className="breadcrumb-item"><NavLink to="/LstEmpleado">{Nav}</NavLink></li>
                                <li className="breadcrumb-item active"><NavLink to="/">Página de inicio</NavLink></li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div className="content">
                <form method="post">
                    <div className="form-group col-md-6">
                        <label>Cargar Empleados</label>
                        <input type="file" name="lstEmpleados" id="lstEmpleados" />
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
                        <div className="card-body table-responsive p-0">
                            <table className="table table-hover text-nowrap">
                                <thead>
                                    <tr>
                                        <th>Rut</th>
                                        <th>Nombre</th>
                                        <th>Apellido</th>
                                        <th>Fecha Nacimiento</th>
                                        <th>Editar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                {EmpLst.map(Emp =>(
                                    <tr key={Emp.id}>
                                        <td>{Emp.rut}</td>
                                        <td>{Emp.nombre}</td>
                                        <td>{Emp.apellido}</td>
                                        <td>{Emp.fechaNacimiento}</td>
                                        <td><a href="#">Editar</a></td>
                                    </tr>
                                    ))
                                }
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ListarEmpleado;