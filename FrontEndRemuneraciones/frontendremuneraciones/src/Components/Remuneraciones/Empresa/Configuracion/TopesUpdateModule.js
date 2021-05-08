import React,{useState, useEffect} from 'react'
import Global from '../../../../Global'
import axios from 'axios'
import { useForm } from "react-hook-form";

const TopesUpdateModule = () =>{

    const { register, errors, handleSubmit } = useForm()
    const [lstTiposTopes, setLstTiposTopes]  = useState([])
    const [infoTopes, setInfoTopes] = useState([])
    const [respuesta, setRespuesta] = useState(false)

    useEffect(() => {
        ObtenerNombreTopes()
        ObtenerInfoTopes()
    },[])

    const ObtenerInfoTopes = async() => {
        const request = await axios.get(Global.url + 'Configuracion/GetTopesActivos')
        if(request !== null){
            setInfoTopes(request.data)
        }
    }
    const ObtenerNombreTopes = async() =>{
        const request = await axios.get(Global.url + 'Configuracion/GetTipoTopes')
        if(request !== null){
            console.log(request.data)
            setLstTiposTopes(request.data)
        }
    }
    const EnviarDatos = async(data) => {
        const request = await axios.post(Global.url + 'Configuracion/InsertarNuevosTopes', data)
        setRespuesta(request.data)
        alert('datos enviados')
        ObtenerInfoTopes()
    }

    return(
        <div className="col-md-12 my-5">
            <form method="POST" onSubmit={handleSubmit(EnviarDatos)}>
            <div className="form-group row">
                <div className="col-md-3">
                    <label>Tipo Tope</label>
                    <select className="form-control form-control-sm" name="NombreTope" ref={register} required>
                        <option>Selecciona</option>
                        {lstTiposTopes.length > 0 &&
                            lstTiposTopes.map(tope => (
                                <option key={tope}>{tope}</option>
                            ))
                        }
                    </select>
                </div>
                <div className="col-md-3">
                    <label>Monto</label>
                    <input type="number" className="form-control form-control-sm"  name="MontoTope" ref={register} required/>
                </div>
                <div className="col-md-3">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date" name="FechaTope" ref={register} required/>
                </div>
                <div className="col-md-4 my-5">
                    <button type="submit" className="btn btn-block btn-outline-success btn-sm">Actualizar</button>
                </div>
            </div>
            </form>

            <div className="table table-responsive">
                <table className="table">
                    <thead>
                        <tr>
                            <th>FECHA</th>
                            <th>TIPO TOPE</th>
                            <th>MONTO</th>
                        </tr>
                    </thead>
                    <tbody>
                        {infoTopes.length > 0 &&
                            infoTopes.map(info  => (
                                <tr key={info.id}>
                                    <td>{info.fecha}</td>
                                    <td>{info.nombreTipoRenta}</td>
                                    <td>{info.ufclp}</td>
                                </tr>
                            ))
                        }
                    </tbody>

                </table>
            </div>

        </div>
    )
}

export default TopesUpdateModule