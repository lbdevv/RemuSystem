import React from 'react';
import axios from 'axios';
import Global from '../../../Global';
import { useForm } from 'react-hook-form';



const FichaEmpresa = () => {

    const {register,handleSubmit} = useForm();

    const onSubmit = (data,e) => {
        console.log(data);
        
        e.target.reset();

        axios.post(Global.url + 'Empresa/AgregarEmpresa',JSON.stringify(data),{
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json'
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
    return(

             <div className="card card-warning">
                    <div className="card-header">
                        <h3 className="card-title">Ficha Empresa</h3>   
                    </div>
                    <div className="card-body">
                        <form method="post" onSubmit={handleSubmit(onSubmit)}>

                            <div className="form-group col-md-6">
                                <label>Rut</label>
                                <input name="Rut" type="text" className="form-control form-control-sm"  ref={register()}/>
                            </div>
                            <div className="form-group col-md-6">
                                <label>Principal</label><br></br>
                                <input type="checkbox" name="Principal" ref={register()}/>
                            </div>
                            <div className="form-group col-md-6">
                                <label>Tipo Empresa</label>
                                <select className="form-control" name="TipoEmpresa" ref={register()}>
                                    <option value="1">Empresa con fines de lucro</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Razon Social</label>
                                <input type="text" name="RazonSocial" className="form-control" ref={register()}/>
                                <input type="number" name="MutualPorcentajeDescuento" ref={register()} />
                            </div>
                            <div className="form-group col-md-6">
                                <label>Giro</label>
                                <input type="text" name="Giro" className="form-control" ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Dirección</label>
                                <input type="text" name="Direccion" className="form-control" ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Representante Legal</label>
                                <input type="text" name="RepresentanteLegal" className="form-control" ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Rut Representante Legal</label>
                                <input type="text" name="RutRepresentanteLegal" className="form-control" ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Caja de compensación</label>
                                <select className="form-control" name="CajaCompensacion" ref={register()}>
                                    <option value="1">Caja1</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Comuna</label>
                                <select className="form-control" name="Comuna" ref={register()}>
                                    <option value="1">Comuna1</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Telefono</label>
                                <input type="number" name="Telefono" className="form-control"  ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Banco pago nomina</label>
                                <select className="form-control" name="BancoPagoNomina" ref={register()}>
                                    <option value="1">Banco1</option>
                                </select>
                            </div>



                            <div className="form-group col-md-6">
                                <label>Vigente</label><br/>
                                <input type="checkbox" name="Vigente" ref={register()}/>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Forma de pago gratificación</label>
                                <select className="form-control" name="FormaPagoGratif" ref={register()}>
                                    <option value="1">Forma1</option>
                                </select>
                            </div>

                            <div className="form-group col-md-6">
                                <label>Forma de pago movilización/Colación</label>
                                <select className="form-control" name="FormPagoMoviColacion" ref={register()}>
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