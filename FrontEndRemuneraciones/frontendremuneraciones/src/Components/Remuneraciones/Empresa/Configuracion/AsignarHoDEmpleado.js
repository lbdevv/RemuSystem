import React, { useEffect, useState } from 'react'
import {useForm} from 'react-hook-form'
import Global from '../../../../Global'
import axios from 'axios'

const AsignarHoDEmpleado = () => {

    const [emp, setEmp] = useState([])
    const [haberes, setHaberes] = useState([])
    const [descuentos, setDescuentos] = useState([])


    const {register, errors, handleSubmit} = useForm();

    useEffect(() => {
        ObtenerLstEmpleados()
        ObtenerLstHyD()
    },[])

    const LlenarEstados = async(data) => {
        const request = await axios.post(Global.url + 'Empresa/AsignarHoD', data)
        console.log(request)
    }
    
    const ObtenerLstEmpleados = async() => {
       const request = await axios.get(Global.url + 'Empleado/LstEmpleados')
       if(request !== null && request !== undefined){
           setEmp(request.data)
       }
    }
    const ObtenerLstHyD = async() => {
       const request =  await axios.get(Global.url + 'Empresa/GetHyDempresa')
       if(request !== null && request !== undefined){
           setHaberes(request.data.item1)
           setDescuentos(request.data.item2)
       }
    }

    let countEmp = 0
    let countHaberes = 0
    let countDescuentos = 0

    return (
        <div className="col-lg-12 col-md-12 col-xs-12">

                    <div className="row">
                        <form id="asignarForm" className="col-12" onSubmit={handleSubmit(LlenarEstados)}>
                            <div className="row form-group">
                                <div className="col-md-3">
                                    <label>Selecciona Empleado</label>
                                    <select className="form-control form-control-sm" name="EmpleadoId" ref={register()} required>
                                        <option>Selecciona</option>
                                        {emp.length > 0 &&
                                            emp.map(e => (
                                                <option
                                                    key={countEmp++}
                                                    value={e.id}>
                                                    {e.rut + " " + e.nombre}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <label>Listado Haberes</label>
                                    <select multiple size="15" className="form-control form-control-sm" name="IdsHaberesAsignados" ref={register()} required>
                                        <option>Selecciona</option>
                                        {haberes.length > 0 &&
                                            haberes.map(hyd => (
                                                <option
                                                    key={countHaberes++}
                                                    value={hyd.id}
                                                >
                                                    {hyd.tipo + "  " + hyd.categoriaHaber + "  " + hyd.nombre + "  " + hyd.monto}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <label>Listado Descuentos</label>
                                    <select multiple size="15" className="form-control form-control-sm" name="IdsDescuentosAsignados" ref={register()}>
                                        <option>Selecciona</option>
                                        { descuentos.length > 0 &&
                                            descuentos.map(hyd => (
                                                <option
                                                    key={countDescuentos++}
                                                    value={hyd.id}
                                                >
                                                    {hyd.tipo + "  " + hyd.categoriaHaber + "  " + hyd.nombre + "  " + hyd.monto}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                                <div className="col-md-3">
                                    <label className="esconderLabel">BotonCentrado</label>
                                    <button className="btn btn-block btn-outline-success btn-sm">Guardar Cambios</button>
                                </div>
                            </div>
                        </form>
                    </div>

        </div>
    )
}

export default AsignarHoDEmpleado