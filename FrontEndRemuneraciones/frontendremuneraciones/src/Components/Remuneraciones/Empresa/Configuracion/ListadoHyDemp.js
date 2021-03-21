import React,{useEffect, useState} from 'react'
import Global from '../../../../Global'
import axios from 'axios'

const ListadoHyDemp = () => {

    const[HyDemp, setHyDemp] = useState({
        haberes:[],
        descuentos:[]
    })

    useEffect(()=> {
        ObtenerLstEmp()
    },[])

    const ObtenerLstEmp = async() => {
        const request = await axios.get(Global.url + 'Empleado/EmpleadoLstHyD')
        
        if(request !== null && request !== undefined){
            setHyDemp({
                haberes: request.data.item1,
                descuentos: request.data.item2
            })
        }
        console.log(request)
    }

    let correlativo = 0

    return( 
        <div className="col-lg-12 col-md-12 col-xs-12">
            <div className="card">
                <div className="card-body">
                    <div className="row">
                        <div className="table table-responsive">
                            <table className="table">
                                <thead>
                                    <tr>#</tr>
                                    <tr>Tipo</tr>
                                    <tr>Tipo Haber</tr>
                                    <tr>Nombre</tr>
                                    <tr>Monto/Calculo</tr>
                                </thead>
                                <tbody>
                                    {/* {hydEmp.length > 0 &&
                                        hydEmp.map(hyd => (
                                            <tr key={correlativo++}>
                                                <td>{hyd.}</td>
                                            </tr>
                                        ))

                                    } */}

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     )
}

export default ListadoHyDemp