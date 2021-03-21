import React, {Fragment, useEffect, useState } from 'react';
import $ from 'jquery';
import { useForm } from 'react-hook-form';
import Global from '../../../Global';
import axios from 'axios';

const CrearEmpleado = () => {

    const { register, errors, handleSubmit } = useForm()
    const [bancos, setBancos] = useState([])
    const [afps, setAfp] = useState([])
    const [isapres, setIsapres] = useState([])
    const [tipoContratos, setTipoContrato] = useState([])
    const [regiones, setRegiones] = useState([])
    const [comunas, setComunas] = useState([])
    const [cargos, setCargos] = useState([])
    const [tramosFa, setTramosFa] = useState([])
    const [iApv, setIApv] = useState([])
    const [esIndefinido, setEsIndefinido] = useState(false)
    const [tieneFonasa, setTieneFonasa] = useState(true)
    const [empresas, setEmpresas] = useState([])


    useEffect(() => {
        $(".n-date").datepicker({
            format: "dd-mm-yyyy"
        });
        ObtenerEmpresas()
        ObtenerBancos()
        ObtenerAfp()
        ObtenerIsapres()
        ObtenerTipoContrato()
        ObtenerRegiones()
        ObtenerCargos()
        ObtenerTramosFa()
        ObtenerIApv()
    }, [])

    const ObtenerEmpresas = async() => {
        const request = await axios.get(Global.url + 'Empresa/lstEmpresas')
        if(request != null){
            setEmpresas(request.data)
        }
    }
    const ObtenerBancos = () => {
        axios.get(Global.url + 'Empresa/GetBancos')
            .then(res => setBancos(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerAfp = () => {
        axios.get(Global.url + 'Empresa/LstAfps')
            .then(res => setAfp(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerIsapres = () => {
        axios.get(Global.url + 'Empresa/LstIsapres')
            .then(res => setIsapres(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerTipoContrato = () => {
        axios.get(Global.url + 'Empresa/LstContratos')
            .then(res => setTipoContrato(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerRegiones = () => {
        axios.get(Global.url + 'Empresa/LstRegiones')
            .then(res => setRegiones(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerCargos = () => {
        axios.get(Global.url + 'Empresa/ObtenerCargos')
            .then(res => setCargos(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerTramosFa = () => {
        axios.get(Global.url + 'Empresa/ObtenerTramosFamiliares')
            .then(res => setTramosFa(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerIApv = () => {
        axios.get(Global.url + 'Empresa/ObtenerIApv')
            .then(res => setIApv(res.data))
            .catch(err => console.log(err))
    }

    const ObtenerComunasRegion = (e) => {
        const id = e
        axios.get(Global.url + 'Empresa/RegionesYComunas/' + id)
            .then(res => setComunas(res.data))
            .catch(err => console.log(err))
    }

    const VerificarTipoContrato = (e) => {
        const id = e
        console.log(id)
        axios.get(Global.url + 'Empresa/VerificaTipoContrato/' + id)
            .then(res => setEsIndefinido(res.data))
            .catch(err => console.log(err))
    }

    const TipoSalud = e => {
        console.log(e)
        if (e === "Isapre") {
            setTieneFonasa(false)
        }
        else if (e === "Fonasa") {
            setTieneFonasa(true)
        }
    }

    const onSubmit = (data, e) => {
        axios.post(Global.url + 'Empleado/AgregarEmpleado', JSON.stringify(data), {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(res => {
                console.log(res.data)
            })
    }

    return (
        <div className="card">

            <div className="alert alert-info"><p>Completa todos los campos para poder crear al empleado.</p> </div>

            <ul className="nav nav-tabs">
                <li className="nav-item">
                    <a className="nav-link active" href="#Ficha" role="tab" data-toggle="tab">Ficha</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#Condiciones" role="tab" data-toggle="tab">Condiciones</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#Prevision" role="tab" data-toggle="tab">Previsión</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link disabled" role="tab" href="#3">Grupo Familiar</a>
                </li>
            </ul>

            <form className="my-4" method="post" onSubmit={handleSubmit(onSubmit)}>
                <div className="form-group col-md-6">
                    <button type="submit" className="btn btn-block btn-outline-primary btn-sm">Guardar</button>
                </div>
                <div className="tab-content">
                    <div role="tabpanel" className="tab-pane active" id="Ficha">

                        <div className="form-group col-md-3">
                            <label>Selecciona Empresa</label>
                            <select className="form-control form-control-sm" name="empresaId">
                                <option>Selecciona</option>
                                {empresas !== null &&
                                    empresas.map(emp => (
                                        <option key={emp.id}>{emp.nombre}</option>
                                    ))
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Está vigente?</label>
                            <input type="checkbox" className="form-group form-group-sm" />
                        </div>

                        <div className="form-group col-md-3">
                            <label>Razón Social</label>
                            <input name="RazonSocial" className="form-control form-control-sm" type="text" />
                        </div>

                        <div className="form-group col-md-6">
                            <label>Rut</label>
                            <input name="Rut" type="text" className="form-control form-control-sm" ref={register()} />

                        </div>

                        <div className="form-group col-md-6">
                            <label>Nombre</label>
                            <input name="Nombre" id="Nombre" type="text" className="form-control form-control-sm"
                                ref={
                                    register({
                                        required: { value: true, message: 'Nombre Obligatorio' }
                                    })
                                }
                            />
                            <span className="text-danger text-small d-block mb-2">
                                {errors?.Nombre?.message}
                            </span>

                        </div>

                        <div className="form-group col-md-6">
                            <label>Apellido</label>
                            <input name="Apellido" type="text" className="form-control form-control-sm" ref={register()} />

                        </div>

                        <div className="form-group col-md-6">
                            <label>Fecha de Nacimiento</label>
                            <input name="FechaNacimiento" id="FechaNacimiento" className="form-control form-control-sm n-date" type="text" ref={register()} />
                        </div>

                        <div className="form-group col-md-3" >
                            <label>Sexo</label>
                            <select className="form-control form-control-sm" name="Sexo" id="Sexo" ref={register()}>
                                <option>Selecciona</option>
                                <option value="1">Hombre</option>
                                <option value="2">Mujer</option>
                                <option value="3">Otro</option>
                            </select>
                        </div>
                        <div className="form-group col-md-3">
                            <label>Estado Civil</label>
                            <select className="form-control form-control-sm" name="EstadoCivil" id="EstadoCivil" ref={register()}>
                                <option>Selecciona</option>
                                <option value="1">Soltero/a</option>
                                <option value="2">Casado/a</option>
                                <option value="3">Viudo/a</option>
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Nacionalidad</label>
                            <input type="text" className="form-control form-control-sm" name="Nacionalidad" id="Nacionalidad" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Email Corporativo</label>
                            <input type="email" className="form-control form-control-sm" name="EmailCorporativo" id="EmailCorporativo" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Email Personal</label>
                            <input type="email" className="form-control form-control-sm" name="EmailPersonal" id="EmailPersonal" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Telefono</label>
                            <input type="number" className="form-control form-control-sm" name="Telefono" id="Telefono" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Calle</label>
                            <input className="form-control form-control-sm" type="text" name="Calle" id="Calle" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Número</label>
                            <input className="form-control form-control-sm" type="number" name="NumCasa" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Departamento o Casa</label>
                            <input className="form-control form-control-sm" type="number" name="Departamento" ref={register()} />
                        </div>

                        <div className="form-group col-md-3">
                            <label>Region</label>
                            <select onChange={e => ObtenerComunasRegion(e.target.value)} className="form-control form-control-sm" name="RegionId" id="RegionId" ref={register()}>
                                <option>Selecciona</option>
                                {regiones.length > 0 &&
                                    regiones.map(region => (
                                        <option
                                            key={region.id}
                                            value={region.id}>
                                            {region.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Comuna</label>
                            <select className="form-control form-control-sm" name="ComunaId" id="ComunaId" ref={register()}>
                                <option>Selecciona</option>
                                {comunas.length > 0 &&
                                    comunas.map(comuna => (
                                        <option
                                            key={comuna.id}
                                            value={comuna.id}
                                        >
                                            {comuna.nombre}
                                        </option>
                                    ))

                                }
                            </select>
                        </div>

                    </div>
                    <div role="tabpanel" className="tab-pane" id="Condiciones">
                        <div className="form-group col-md-3">
                            <label>Cargo</label>
                            <select className="form-control form-control-sm" name="Cargo" ref={register()}>
                                <option>Selecciona</option>
                                {cargos.length > 0 &&
                                    cargos.map(cargo => (
                                        <option
                                            key={cargo.id}
                                            value={cargo.id}>
                                            {cargo.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Unidad</label>
                            <select className="form-control form-control-sm" name="UnidadId" id="UnidadId">
                                <option>Selecciona</option>
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Centro de costo</label>
                            <select className="form-control form-control-sm" name="CentroCosto" ref={register()}>
                                <option>Selecciona</option>
                                <option value="1">Administracion</option>
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Tipo Contrato</label>
                            <select onChange={e => VerificarTipoContrato(e.target.value)} className="form-control form-control-sm" name="TipoContrato" ref={register()}>
                                <option>Selecciona</option>
                                {tipoContratos.length > 0 &&
                                    tipoContratos.map(tipoContrato => (
                                        <option
                                            key={tipoContrato.id}
                                            value={tipoContrato.id}>
                                            {tipoContrato.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Contratación Desde</label>
                            <input className="form-control form-control-sm n-date" type="text" name="ContratoDesde" id="ContratoDesde" ref={register()} autocomplete="off" />

                            {esIndefinido === true &&
                                <Fragment>
                                    <label>Contratación Hasta</label>
                                    <input className="form-control form-control-sm n-date" type="text" name="ContratoHasta" id="ContratoHasta" ref={register()} />
                                </Fragment>
                            }

                        </div>

                        <div className="form-group col-md-3">
                            <label>Sueldo Base</label>
                            <input type="number" className="form-control form-control-sm" name="SueldoBase" id="SueldoBase" ref={register()} />
                        </div>

                        <div className="form-group col-md-3">
                            <label>Asignación de movilización</label>
                            <input type="number" className="form-control form-control-sm" name="AsignMovilizacion" id="AsignMovilizacion" ref={register()} />
                        </div>
                        <div className="form-group col-md-3">
                            <label>Asignación de colación</label>
                            <input type="number" className="form-control form-control-sm" name="AsignColacion" id="AsignColacion" ref={register()} />
                        </div>

                        <div className="form-group col-md-3">
                            <label>Banco</label>
                            <select className="form-control form-control-sm" name="BancoId" ref={register()}>
                                <option>Selecciona</option>
                                {bancos.length > 0 &&
                                    bancos.map(banco => (
                                        <option
                                            key={banco.id}
                                            value={banco.id}>
                                            {banco.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Tipo de cuenta</label>
                            <select className="form-control form-control-sm" name="TipoCuentaId">
                                <option>Selecciona</option>
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Numero de Cuenta</label>
                            <input type="number" className="form-control form-control-sm" name="NumeroCuenta" ref={register()} />
                        </div>
                    </div>
                    <div role="tabpanel" className="tab-pane" id="Prevision">

                        <div className="form-group col-md-3">
                            <label>AFP</label>
                            <select className="form-control form-control-sm" name="AFPId" id="AFPId" ref={register()}>
                                <option>Selecciona</option>
                                {afps.length > 0 &&

                                    afps.map(afp => (
                                        <option
                                            key={afp.id}
                                            value={afp.id}>
                                            {afp.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>Tipo Salud</label>
                            <select onChange={e => TipoSalud(e.target.value)} name="tipoSalud" id="tipoSalud" className="form-control form-control-sm" ref={register}>
                                <option>Selecciona</option>
                                <option value="Fonasa">Fonasa</option>
                                <option value="Isapre">Isapre</option>
                            </select>
                        </div>

                        {tieneFonasa === false &&
                            <div id="isapreContent">
                                <div className="form-group col-md-3">
                                    <label>Isapre</label>
                                    <select className="form-control form-control-sm" name="IsapreId" id="IsapreId" ref={register()}>
                                        <option>Selecciona</option>
                                        {isapres.length > 0 &&
                                            isapres.map(isapre => (
                                                <option
                                                    key={isapre.id}
                                                    value={isapre.id}>
                                                    {isapre.nombre}
                                                </option>
                                            )
                                            )
                                        }
                                    </select>
                                </div>


                                <div className="form-group col-md-3">
                                    <label>Monto pactado c/Isapre</label>
                                    <select className="form-control form-control-sm" id="IsapreTipoMonto" name="IsapreTipoMonto" ref={register()}>
                                        <option>Selecciona</option>
                                        <option value="1">$</option>
                                        <option value="2">UF</option>
                                        <option value="3">%</option>
                                    </select>
                                    <input type="number" id="IsapreMonto" name="IsapreMonto" ref={register()} />
                                </div>
                            </div>
                        }



                        <div className="form-group col-md-3">
                            <label>Tramo de Asignación Familiar</label>
                            <select className="form-control form-control-sm" id="TramoId" name="TramoId" ref={register()}>
                                <option>Selecciona</option>
                                {tramosFa.length > 0 &&
                                    tramosFa.map(tramo => (
                                        <option
                                            key={tramo.id}
                                            value={tramo.id}>
                                            {tramo.tramo}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>

                        <div className="form-group col-md-3">
                            <label>¿Tiene APV?</label>
                            <input type="checkbox" />
                        </div>
                        <div className="form-group col-md-6">
                            <div className="col-md-3">
                                <label>APV</label>
                                <select className="form-control form-control-sm" id="ApvTipoMonto" name="ApvTipoMonto" ref={register()}>
                                    <option value="0">$</option>
                                    <option value="1">UF</option>
                                    <option value="2">%</option>
                                </select>
                            </div>
                            <div className="col-md-3">
                                <input className="form-control" type="number" id="ApvMonto" name="ApvMonto" ref={register()} />
                            </div>

                        </div>

                        <div className="form-group col-md-3">
                            <label>Institucion APV</label>
                            <select className="form-control form-control-sm" id="IApv" name="IApv" ref={register()}>
                                <option>Selecciona</option>
                                {iApv.length > 0 &&
                                    iApv.map(apv => (
                                        <option
                                            key={apv.id}
                                            value={apv.id}>
                                            {apv.nombre}
                                        </option>
                                    )
                                    )
                                }
                            </select>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default CrearEmpleado;