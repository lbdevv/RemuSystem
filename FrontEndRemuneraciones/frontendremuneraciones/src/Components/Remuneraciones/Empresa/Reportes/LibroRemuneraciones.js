import React, { Fragment, useEffect,useState } from 'react'
import Global from '../../../../Global'
import axios from 'axios'

const LibroRemuneraciones = () => {

    const [libroRemu, setLibroRemu] = useState(null)

    useEffect(() => {
        ObtenerLibroRemuneraciones()
    },[])
    const ObtenerLibroRemuneraciones = async() =>{
        const request = await axios.get(Global.url + 'Empresa/GetLibroRemuneraciones')
        if(request !== null)
        {
            setLibroRemu(request.data)
            console.log(request.data)
        }
    }

    let Count = 0;
    return (
        <Fragment>
            <div className="col-lg-12 col-md-12 col-xs-12">
                <div className="card">
                    <div className="card-header">
                        <h3 className="card-title"><strong>Libro de Remuneraciones</strong></h3>
                    </div>
                    <div class="card-body table-responsive p-0">
                        <table class="table table-hover text-nowrap">
                            <thead>
                                <tr>
                                    <th>Cod</th>
                                    <th>RUT</th>
                                    <th>Nombre</th>
                                    <th>DT</th>
                                    <th>S.Base</th>
                                    <th>H.Extra</th>
                                    <th>Grat.Legal</th>
                                    <th>Otros.Imp</th>
                                    <th>Total.Imp</th>
                                    <th>Asig.Fam</th>
                                    <th>Otr.NoImp</th>
                                    <th>Tot.NoImp</th>
                                    <th>Tot.Haberes</th>
                                    <th>Prevision</th>
                                    <th>Salud</th>
                                    <th>Imp.Unico</th>
                                    <th>Seg.Ces</th>
                                    <th>Otr.Desc.Leg</th>
                                    <th>Tot.Desc.Leg</th>
                                    <th>Desc.Var</th>
                                    <th>Tot.Desc</th>
                                    <th>Liquido</th>
                                </tr>
                            </thead>
                            <tbody>
                                {libroRemu !== null  &&
                                libroRemu.map(libroR => (
                                    <tr key={Count++}>
                                        <td>{Count}</td>
                                        <td>{libroR.empleado.rut}</td>
                                        <td>{libroR.empleado.nombre}</td>
                                        <td>{libroR.empleado.contratoEmp.horasDeJornada}</td>
                                        <td>{libroR.empleado.sueldoEmp.sueldoBase}</td>
                                        <td>{0}</td>
                                        <td>{libroR.gratLegal}</td>
                                        <td>{libroR.otrosImp}</td>
                                        <td>{libroR.totalImp}</td>
                                        <td>{libroR.asigFamiliar}</td>
                                        <td>{libroR.otrosNoImp}</td>
                                        <td>{libroR.totalNoImp}</td>
                                        <td>{libroR.totalHaberes}</td>
                                        <td>{libroR.prevision}</td>
                                        <td>{libroR.salud}</td>
                                        <td>{libroR.impUnico}</td>
                                        <td>{libroR.segCesantia}</td>
                                        <td>{libroR.otrDescuentosLegales}</td>
                                        <td>{libroR.descLegales}</td>
                                        <td>{libroR.descVariables}</td>
                                        <td>{libroR.totalDescuentos}</td>
                                        <td>{libroR.totalLiquido}</td>
                                    </tr>
                                ))

                                }
                            {/* {empleado.lstHaberImponible.map(haberImp => (
                                        <tr key={idCount++}>
                                            <td colSpan="3">{formatNumber.new(haberImp.nombreHaber)}</td>
                                            <td>{haberImp.montoHaber}</td>
                                        </tr>
                                    )
                                    )
                                    } */}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </Fragment>

    )
}

export default LibroRemuneraciones