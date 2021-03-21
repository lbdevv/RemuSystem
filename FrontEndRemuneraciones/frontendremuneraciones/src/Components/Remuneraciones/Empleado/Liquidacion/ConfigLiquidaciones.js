import React, { useEffect, Fragment } from 'react';
import '../../../../assets/css/ConfigLiquidaciones/ConfigLiquidaciones.css'
import AsignarHoDEmpleado from './../../Empresa/Configuracion/AsignarHoDEmpleado'
import IndicadoresEconomicosUpdateModule from './../../Empresa/Configuracion/IndicadoresEconomicosUpdateModule'
import TopesUpdateModule from './../../Empresa/Configuracion/TopesUpdateModule'
import AFPUpdateModule from  './../../Empresa/Configuracion/AFPUpdateModule'
import APVUpdateModule from  './../../Empresa/Configuracion/APVUpdateModule'
import SaludUpdateModule from './../../Empresa/Configuracion/SaludUpdateModule'
import CrearHaberesYDescuentos from './../../Empresa/Configuracion/CrearHaberesYdescuentos'
import $ from 'jquery';

const ConfigLiquidaciones = () => {

    useEffect(() => {
        $(".n-date").datepicker({
            format: "dd-mm-yyyy"
        });
    }, [])


    return (

        <Fragment>
            <div className="card">
                <ul className="nav nav-tabs c-margin">
                    <li className="nav-item">
                        <a className="nav-link active" href="#Ieconomicos" role="tab" data-toggle="tab">Indicadores Economicos</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#Topes" role="tab" data-toggle="tab">Topes</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#Salud" role="tab" data-toggle="tab">Salud</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#Afp" role="tab" data-toggle="tab">AFP</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#Apv" role="tab" data-toggle="tab">APV</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#CrearHoD" role="tab" data-toggle="tab">Crear Haberes o Descuentos</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#HyD" role="tab" data-toggle="tab">Asignar Haberes o Descuentos</a>
                    </li>
                </ul>


                <div className="tab-content">
                    <div role="tabpanel" className="tab-pane active" id="Ieconomicos">
                        <IndicadoresEconomicosUpdateModule />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="Topes">
                        <TopesUpdateModule />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="Salud">
                        <SaludUpdateModule />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="Afp">
                        <AFPUpdateModule />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="Apv">
                        <APVUpdateModule />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="CrearHoD">
                        <CrearHaberesYDescuentos  />
                    </div>
                    <div role="tabpanel" className="tab-pane" id="HyD">
                        <AsignarHoDEmpleado />
                    </div>
                </div>
            </div>
        </Fragment>

    )
}

export default ConfigLiquidaciones;


