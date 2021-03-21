import React,{useState, useEffect} from 'react'
import Global from '../../../../Global'
import axios from 'axios'

const TopesUpdateModule = () =>{

    const [respuesta, setRespuesta] = useState(false)

    useEffect(() => {
        ObtenerNombreTopes()
    },[])

    const ObtenerNombreTopes = async() =>{
        const request = await axios.get(Global.url + 'Configuracion/InsertarNuevosTopes')
        setRespuesta(request.data)
    }

    const EnviarDatos = () => {
        alert('datos enviados')
    }

    return(
        <div className="col-md-12 my-5">
            <form method="POST" onSubmit={EnviarDatos}>
            <div className="form-group row">
                <div className="col-md-3">
                    <label>Tipo Tope</label>
                    <select className="form-control form-control-sm" required>
                        <option>Selecciona</option>
                    </select>
                </div>
                <div className="col-md-3">
                    <label>Monto</label>
                    <input type="number" className="form-control form-control-sm" required/>
                </div>
                <div className="col-md-3">
                    <label>Fecha</label>
                    <input type="text" className="form-control form-control-sm n-date" required/>
                </div>
                <div className="col-md-4 my-5">
                    <button className="btn btn-block btn-outline-success btn-sm">Guardar</button>
                </div>
            </div>
            </form>
        </div>
    )
}

export default TopesUpdateModule