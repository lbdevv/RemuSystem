import React, { useState, useEffect } from 'react';
import Global from '../../../../Global';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { Fragment } from 'react';



const SueldoLiquidacion = () => {

    const { id } = useParams();

    const [empleado, setEmpleado] = useState([]);
    const [resultLiquidacion, setResultLiquidacion] = useState(null)

    useEffect(() => {
        getEmpleado()
    }, []);

    var formatNumber = {
        separador: ".", // separador para los miles
        sepDecimal: ',', // separador para los decimales
        formatear: function (num) {
            num += '';
            var splitStr = num.split('.');
            var splitLeft = splitStr[0];
            var splitRight = splitStr.length > 1 ? this.sepDecimal + splitStr[1] : '';
            var regx = /(\d+)(\d{3})/;
            while (regx.test(splitLeft)) {
                splitLeft = splitLeft.replace(regx, '$1' + this.separador + '$2');
            }
            return this.simbol + splitLeft + splitRight;

        },
        new: function (num, simbol) {
            this.simbol = simbol || '';
            return this.formatear(num);
        }
    }

    const getEmpleado = () => {
        axios.get(Global.url + 'Empleado/GetEmpleado/' + id)
            .then(res => {
                setEmpleado(res.data);
                console.log(res.data);
            }).catch(err => {
                console.log(err);
            });
    }

    const GenerarLiquidacion = async() =>{
        const request = await axios.post(Global.url + 'Empleado/CargarLiquidacion/'+ id)
        if(request != null)
        {
            setResultLiquidacion(request.data)
            console.log(request.data)
        }
    }
    console.log(empleado);
    let idCount = 0;
    return (

        <Fragment>
            <div className="card">
                <h2 className="text-center">Vista Previa Liquidación</h2>

                <div className="card-header">
                    <div className="row">
                        <div className="col-md-12">
                            <button onClick={GenerarLiquidacion} className="btn btn-success float-right">Generar Liquidación</button>
                        </div>
                    </div>
                    <h3>Indicadores Economicos</h3>
                </div>
                <div className="card-body">
                    <div className="row">
                        {empleado !== null && empleado !== undefined && empleado.length !== 0 &&
                            <div className="col-md-12">
                                <div className="col-md-4" id="UF">
                                    <label>{empleado.indicadoresEco.uf.nombre}</label>
                                    <b>{empleado.indicadoresEco.uf.valor}</b>
                                </div>
                                <div className="col-md-4" id="UTM">
                                    <label>{empleado.indicadoresEco.utm.nombre}</label>
                                    <b>{empleado.indicadoresEco.utm.valor}</b>
                                </div>

                                <div className="col-md-4">
                                    <label>{empleado.indicadoresEco.sueldoMinimo.nombre}</label>
                                    <b>{empleado.indicadoresEco.sueldoMinimo.valor}</b>
                                </div>

                            </div>
                        }
                    </div>
                </div>
            </div>


            <div className="card">
                <div className="card-header">
                    <h4>Liquidación de Sueldo</h4>
                    {empleado !== null && empleado !== undefined && empleado.length !== 0 &&
                        <h5>Mes: {empleado.mesLiquidacion}</h5>
                    }
                </div>
                <div className="card-body">
                    <div className="col-md-12">
                        <div className="row">
                            <div className="col-md-6">
                                {empleado !== null && empleado !== undefined && empleado.length !== 0 &&
                                    <div id="Info-Personal">
                                        <p className="font-weight-bold">Nombre: <span className="font-weight-normal">{empleado.infoEmpleado.nombreEmpleado}</span></p>
                                        <p className="font-weight-bold">Rut:  <span className="font-weight-normal">{empleado.infoEmpleado.rutEmpleado}</span> </p>
                                        <p className="font-weight-bold">Fecha de ingreso: <span className="font-weight-normal">{empleado.infoEmpleado.fechaIngresoEmpleado}</span></p>
                                        <p className="font-weight-bold">Cargo: <span className="font-weight-normal">{empleado.infoEmpleado.cargoEmpleado}</span> </p>
                                        <p className="font-weight-bold">Centro de costo:</p>
                                    </div>
                                }
                            </div>
                            <div className="col-md-6 float-right">
                                {empleado !== null && empleado !== undefined && empleado.length !== 0 &&

                                    <div id="Info-Empresa">

                                        <h6>Información Empresa</h6>
                                        <p className="font-weight-bold">Razon Social:<span className="font-weight-normal">{empleado.infoEmpleado.razonSocialEmpresa}</span></p>
                                        <p className="font-weight-bold">Rut: <span className="font-weight-normal">{empleado.infoEmpleado.rutEmpresa}</span></p>
                                        <p className="font-weight-bold">Dirección:<span className="font-weight-normal">{empleado.infoEmpleado.direccionEmpresa}</span> </p>
                                    </div>
                                }
                            </div>
                        </div>

                        <hr />
                        <div id="Variables">
                            <div className="row">
                                <div className="col-md-3"><p className="font-weight-bold">Días Trabajados: <span className="font-weight-normal">30</span></p></div>
                                <div className="col-md-3"><p className="font-weight-bold">Días Licencia: <span className="font-weight-normal">0</span></p></div>
                                <div className="col-md-3"><p className="font-weight-bold">Días Ausencia: <span className="font-weight-normal">0</span></p></div>
                                <div className="col-md-3"><p className="font-weight-bold">Horas Base: <span className="font-weight-normal">45</span></p></div>
                            </div>
                            .
                        </div>
                        <hr />

                        <table className="table">
                            <thead>
                                <tr>
                                    <th colSpan="3">Detalle</th>
                                    <th>Haberes</th>
                                    <th>Descuentos</th>
                                </tr>
                            </thead>

                            {empleado.length !== 0 &&
                                <tbody>

                                    <th>Haberes Imponible</th>


                                    {empleado.lstHaberImponible.map(haberImp => (
                                        <tr key={idCount++}>
                                            <td colSpan="3">{formatNumber.new(haberImp.nombreHaber)}</td>
                                            <td>{haberImp.montoHaber}</td>
                                        </tr>
                                    )
                                    )
                                    }
                                    <tr>
                                        <th colSpan="3">Total Haberes Imponibles:</th>
                                        <td><b>{empleado.totalHaberesImp}</b></td>
                                    </tr>

                                    <th>Haberes No Imponibles</th>


                                    {empleado.lstHaberNoImponible.map(haberNoImp => (
                                        <tr key={idCount++}>
                                            <td colSpan="3">{haberNoImp.nombreHaber}</td>
                                            <td>{haberNoImp.montoHaber}</td>
                                        </tr>
                                    )
                                    )
                                    }

                                    <tr>
                                        <th colSpan="3">Total Haberes No Imponibles:</th>
                                        <td><b>{empleado.totalHaberesNoImp}</b></td>
                                    </tr>

                                    <tr>
                                        <th colSpan="3">Total Haberes:</th>
                                        <td><b>{empleado.totalHaberes}</b></td>
                                    </tr>


                                    <tr>
                                        <th>Descuentos</th>
                                    </tr>

                                    {empleado.lstDescuentos.map(descuentos => (
                                        <tr key={idCount++}>
                                            <td colSpan="3">{descuentos.nombreDescuento}</td>
                                            <td></td>
                                            <td>{descuentos.montoDescuento}</td>
                                        </tr>
                                    )
                                    )
                                    }
                                    <tr>
                                        <th colSpan="4">Total Descuentos: </th>
                                        <th>{empleado.totalDescuentos}</th>
                                    </tr>

                                </tbody>
                            }
                        </table>
                        <hr />
                        <div className="my-5"></div>
                        <div className="row m-auto mt-5">
                            <div className="col-md-6"><p className="font-weight-bold">Fecha Liquidación: <span className="font-weight-normal"> {empleado.fechaLiquidacion}</span></p></div>
                            <div className="col-md-6"><p className="font-weight-bold">Alcance Liquido: <span className="font-weight-bold text-success"> {empleado.totalLiquido}</span></p></div>
                        </div>
                        <div className="my-5"></div>
                        <div className="row m-auto">
                            <div className="col-md-6">
                                <label>Firma Empleador</label>
                                <p className="my-3">______________________________</p>
                            </div>
                            <div className="col-md-6">
                                <label>Firma Trabajador</label>
                                <p className="my-3">______________________________</p>
                            </div>
                        </div>
                        <hr />

                        <div className="row">
                            <div className="col-md-12">
                                <button onClick={GenerarLiquidacion} className="btn btn-success float-right">Generar Liquidación</button>
                            </div>
                        </div>

                        <div className="row my-5 m-auto">
                            <div className="col-md-6">
                                Liquidación generada automaticamente por GeoRemu.com
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    );

}

export default SueldoLiquidacion;
