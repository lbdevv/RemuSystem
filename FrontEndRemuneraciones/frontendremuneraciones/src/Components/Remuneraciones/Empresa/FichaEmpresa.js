import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Global from '../../../Global';
import { useForm } from 'react-hook-form';



const FichaEmpresa = () => {

    const [cajaComp, setCajaComp] = useState([])
    const [comunas, setComunas] = useState([])
    const [regiones, setRegiones] = useState([])
    const [bancos, setBancos] = useState([])
    const [tipoEmpresas, setTipoEmpresas] = useState([])
    const { register, handleSubmit } = useForm();


    useEffect(() => {
        getLstCajasComp()
        ObtenerRegiones()
        ObtenerBancos()
        ObtenerTipoEmpresas()
    }, [])

    const getLstCajasComp = async () => {
        const request = await axios.get(Global.url + 'Empresa/GetLstCajasCompensacion')
        if (request != null) {
            setCajaComp(request.data)
        }
        console.log(request)
    }
    const ObtenerRegiones = async () => {
        const request = await axios.get(Global.url + 'Empresa/LstRegiones')
        if (request != null) {
            setRegiones(request.data)
        }
    }
    const ObtenerBancos = async() => {
        const request = await axios.get(Global.url + 'Empresa/GetBancos')
        if(request != null){
            setBancos(request.data)
        }
    }
    const ObtenerComunasRegion = async(e) => {
        const id = e
        const request = await axios.get(Global.url + 'Empresa/RegionesYComunas/' + id)
        if(request != null){
            setComunas(request.data)
        }
    }
    const ObtenerTipoEmpresas = async() => {
        const request = await axios.get(Global.url + 'Empresa/lstTipoEmpresas')
        if(request != null){
            setTipoEmpresas(request.data)
        }
    }

    const onSubmit = (data, e) => {
        console.log(data);

        e.target.reset();

        axios.post(Global.url + 'Empresa/AgregarEmpresa', JSON.stringify(data), {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
            .then(res => {
                console.log(res.data);
            })
            .catch(err => {
                alert("Error al Mandar la peticion" + err);
                console.log(err);
            });
    }

    return (

        <div className="card">
            <div className="card-header">
                <h3 className="card-title"><strong>Ficha Empresa</strong></h3>
            </div>
            <div className="card-body">
                <form method="post" onSubmit={handleSubmit(onSubmit)}>

                    <div className="form-group col-md-6">
                        <label>Rut</label>
                        <input name="Rut" type="text" className="form-control form-control-sm" ref={register()} />
                    </div>
                    <div className="form-group col-md-6">
                        <label>Principal</label><br></br>
                        <input type="checkbox" name="Principal" ref={register()} />
                    </div>
                    <div className="form-group col-md-6">
                        <label>Tipo Empresa</label>
                        <select className="form-control form-control-sm" name="TipoEmpresa" ref={register()}>
                            <option>Selecciona</option>
                            {tipoEmpresas !== null &&
                                tipoEmpresas.map(temp => (
                                    <option key={temp.id} value={temp.id}>{temp.nombre}</option>
                                ))
                            }
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Razon Social</label>
                        <input type="text" name="RazonSocial" className="form-control form-control-sm" ref={register()} />
                    </div>
                    <div className="form-group col-md-6">
                        <label>Giro</label>
                        <input type="text" name="Giro" className="form-control form-control-sm" ref={register()} />
                    </div>

                    <div className="form-group col-md-6">
                        <label>Dirección</label>
                        <input type="text" name="Direccion" className="form-control form-control-sm" ref={register()} />
                    </div>

                    <div className="form-group col-md-6">
                        <label>Representante Legal</label>
                        <input type="text" name="RepresentanteLegal" className="form-control form-control-sm" ref={register()} />
                    </div>

                    <div className="form-group col-md-6">
                        <label>Rut Representante Legal</label>
                        <input type="text" name="RutRepresentanteLegal" className="form-control form-control-sm" ref={register()} />
                    </div>

                    <div className="form-group col-md-6">
                        <label>Caja de compensación</label>
                        <select className="form-control form-control-sm" name="CajaCompensacion" ref={register()}>
                            <option>Selecciona</option>
                            {cajaComp !== null &&
                                cajaComp.map(caja => (
                                    <option key={caja.id} value={caja.id}>{caja.nombre}</option>
                                ))
                            }
                        </select>
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

                    <div className="form-group col-md-6">
                        <label>Comuna</label>
                        <select className="form-control form-control-sm" name="Comuna" ref={register()}>
                            <option>Selecciona</option>
                            {comunas !== null &&
                                comunas.map(c => (
                                    <option key={c.id} value={c.id}>{c.nombre}</option>
                                ))
                            }
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Telefono</label>
                        <input type="number" name="Telefono" className="form-control form-control-sm" ref={register()} />
                    </div>
                    <div className="form-group col-md-6">
                        <label>Banco pago nomina</label>
                        <select className="form-control form-control-sm" name="BancoPagoNomina" ref={register()}>
                            <option>Selecciona</option>
                            {bancos !== null &&
                                bancos.map(b => (
                                    <option key={b.id} value={b.id}>{b.nombre}</option>
                                ))
                            }
                        </select>
                    </div>
                    <div className="form-group col-md-6">
                        <label>Vigente</label><br />
                        <input type="checkbox" name="Vigente" ref={register()} />
                    </div>

                    <div className="form-group col-md-6">
                        <label>Forma de pago gratificación</label>
                        <select className="form-control form-control-sm" name="FormaPagoGratif" ref={register()}>
                            <option value="1">Forma1</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <label>Forma de pago movilización/Colación</label>
                        <select className="form-control form-control-sm" name="FormPagoMoviColacion" ref={register()}>
                            <option value="1">FormaPago</option>
                        </select>
                    </div>

                    <div className="form-group col-md-6">
                        <button type="submit" className="btn btn-block btn-outline-primary btn-sm">Guardar</button>
                    </div>

                </form>
            </div>
        </div>


    );
}

export default FichaEmpresa;