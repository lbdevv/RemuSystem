import React,{ useState, useEffect } from 'react';
import Global from '../../../../Global';
import axios from 'axios';
import { useParams } from 'react-router-dom';


const SueldoLiquidacion = () => {

    const {id} = useParams();

    const [empleado,setEmpleado] = useState([]);

    useEffect(() => {
        getEmpleado()
    }, []);

    const getEmpleado =  () => {
      axios.get(Global.url + 'Empleado/GetEmpleado/' + id)
           .then(res => {
                setEmpleado(res.data);
            }).catch(err => {
                console.log(err);
            });
    }

    return (


                <div className="card">
                    <div className="card-header">
                        <h4>Liquidacion de Sueldo</h4>
                        <h5>Mes: Julio</h5>
                    </div>
                    <div className="card-body">
                        <div className="col-md-12">
                            <div className="row">
                                <div className="col-md-6">
                                    <div id="Info-Personal">
                                        <h6 className="font-weight-bold">{empleado.nombre}</h6>
                                        <p className="font-weight-bold">Rut: {empleado.rut}</p>
                                        <p className="font-weight-bold">Fecha de ingreso:</p>
                                        <p className="font-weight-bold">Cargo:</p>
                                        <p className="font-weight-bold">Centro de costo:</p>
                                    </div>
                                </div>

                                <div className="col-md-6 float-right">
                                    <div id="Info-Empresa">

                                        <h6>Informacion Empresa</h6>
                                        <p className="font-weight-bold">Razon Social:</p>
                                        <p className="font-weight-bold">Rut:</p>
                                        <p className="font-weight-bold">Dirección:</p>
                                    </div>
                                </div>
                            </div>

                            <hr />
                            <div id="Variables">
                                <div className="row">
                                    <div className="col-md-3"><p className="font-weight-bold">Días Trabajados: 30</p></div>
                                    <div className="col-md-3"><p className="font-weight-bold">Días Licencia: 0</p></div>
                                    <div className="col-md-3"><p className="font-weight-bold">Días Ausencia: 0</p></div>
                                    <div className="col-md-3"><p className="font-weight-bold">Horas Base: 45</p></div>
                                </div>
                            </div>
                            <hr/>

                            <div id="Detalle">
                                <div className="row">
                                    <div className="col-md-8">
                                    <b>Detalle</b>
                                    </div>
                                    <div className="col-md-2"><b>Haberes</b></div>
                                    <div className="col-md-2"><b>Descuentos</b></div>
                                </div>
                            </div>
                            <hr/>
                            <div className="row">
                                <div className="col-md-6">
                                Liquidación generada automaticamente por GeoRemu.com
                                </div>
                            </div>

                        </div>

                    </div>

                </div>




    );

}

export default SueldoLiquidacion;
