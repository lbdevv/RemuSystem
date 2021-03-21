import React, { useState } from 'react'
import Global from '../../../../Global'
import axios from 'axios'

const CrearHaberesYdescuentos = () => {

    const [dataHaber, setDataHaber] = useState({
        TipoHaber: '',
        NombreHaber: '',
        MontoHaber: ''
    })

    const [dataDescuento, setDataDescuento] = useState({
        NombreDescuento: '',
        MontoDescuento: ''
    })

    const handleInputChangeHaber = (e) => {
        setDataHaber({
            ...dataHaber,
            [e.target.name]: e.target.value
        })
    }

    const handleInputChangeDescuento = (e) => {
        setDataDescuento({
            ...dataDescuento,
            [e.target.name]: e.target.value
        })
    }

    const EnviarDatosHaber = (e) => {
        e.preventDefault()
        if (dataHaber !== null && dataHaber.NombreHaber !== '' && dataHaber.MontoHaber !== '' && dataHaber.TipoHaber !== '') {
            axios.post(Global.url + 'Empresa/AgregarHaber', dataHaber)
                .then(res => console.log(res))
                .catch(err => console.log(err))
        }else{
            alert('Debes llenar los campos de Haber')
        }
    }


    const EnviarDatosDescuento = (e) => {

        e.preventDefault()
        if(dataDescuento !== null && dataDescuento.NombreDescuento !== '' && dataDescuento.MontoDescuento !== ''){
            axios.post(Global.url + 'Empresa/AgregarDescuento', dataDescuento)
            .then(res => console.log(res))
            .catch(err => console.log(err))
        }else{
            alert('Debes llenar los campos de Descuentos')
        }

    }

    return (
        <div className="col-lg-12 col-md-12 col-xs-12">

                    <div className="row">
                        <form id="haberesForm" className="col-md-12" onSubmit={EnviarDatosHaber}>
                            <h5>Crear Haber</h5>
                            <div className="row form-group">
                                <div className="col-md-3">
                                    <label>Tipo Haber</label>
                                    <select id="TipoHaber" name="TipoHaber" className="form-control form-control-sm" onChange={handleInputChangeHaber} >
                                        <option value="0">Selecciona</option>
                                        <option value="1">Imponible</option>
                                        <option value="2">No Imponible</option>
                                        <option value="3">Variable</option>
                                    </select>
                                </div>

                                <div className="col-md-3">
                                    <label>Nombre</label>
                                    <input type="text" className="form-control form-control-sm" name="NombreHaber" onChange={handleInputChangeHaber} />
                                </div>
                                <div className="col-md-3">
                                    <label>Monto</label>
                                    <input type="number" className="form-control form-control-sm" name="MontoHaber" onChange={handleInputChangeHaber} />
                                </div>
                                <div className="col-md-3">
                                    <label className="esconderLabel">BotonCentrado</label>
                                    <button type="submit" className="btn btn-block btn-outline-success btn-sm">Agregar Haber</button>
                                </div>
                            </div>
                        </form>
                    </div>

                    <div className="row">
                        <form id="descuentosForm" className="col-md-12" onSubmit={EnviarDatosDescuento}>
                            <h5>Crear Descuento</h5>
                            <div className="row form-group">
                                <div className="col-md-3">
                                    <label>Nombre</label>
                                    <input type="text" className="form-control form-control-sm" name="NombreDescuento" onChange={handleInputChangeDescuento} />
                                </div>
                                <div className="col-md-3">
                                    <label>Monto</label>
                                    <input type="number" className="form-control form-control-sm" name="MontoDescuento" onChange={handleInputChangeDescuento} />
                                </div>
                                <div className="col-md-3">
                                    <label className="esconderLabel">BotonCentrado</label>
                                    <button type="submit" className="btn btn-block btn-outline-success btn-sm">Agregar Descuento</button>
                                </div>
                            </div>

                        </form>
                    </div>

        </div>
    )
}

export default CrearHaberesYdescuentos