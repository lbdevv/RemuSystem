import React from "react";
import axios from "axios";
import Global from "../../../../Global";
import { useForm } from "react-hook-form";

const IndicadoresEconomicosUpdateModule = () => {
  const { register, errors, handleSubmit } = useForm()

  const EnviarIE = async(data) => {
      console.log(data)

     const request = await axios.post(Global.url + "Configuracion/InsertarNuevosIE", data)
    console.log(request.data)
  }

  return (
    <div className="col-md-12 my-5">
      <form onSubmit={handleSubmit(EnviarIE)}>
        <div className="form-group row">
          <div className="col-md-4">
            <label>UF</label>
            <input
              type="text"
              className="form-control form-control-sm"
              name="MontoUF"
              ref={register}
              required
            />
          </div>
          <div className="col-md-4">
            <label>Fecha</label>
            <input
              type="text"
              className="form-control form-control-sm n-date"
              name="FechaUF"
              ref={register}
              required
            />
          </div>
        </div>
        <div className="form-group  row">
          <div className="col-md-4">
            <label>UTM</label>
            <input
              type="text"
              className="form-control form-control-sm"
              name="MontoUTM"
              ref={register}
              required
            />
          </div>
          <div className="col-md-4">
            <label>Fecha</label>
            <input
              type="text"
              className="form-control form-control-sm n-date"
              name="FechaUTM"
              ref={register}
              required
            />
          </div>
        </div>
        <div className="form-group row">
          <div className="col-md-4">
            <label>IMM</label>
            <input
              type="text"
              className="form-control form-control-sm"
              name="MontoIMM"
              ref={register}
              required
            />
          </div>
          <div className="col-md-4">
            <label>Fecha</label>
            <input
              className="form-control form-control-sm n-date"
              name="FechaIMM"
              ref={register}
              required
            />
          </div>
        </div>

        <div className="form-group row">
          <div className="col-md-4">
            <button
              type="submit"
              className="btn btn-block btn-outline-success btn-sm"
            >
              Actualizar
            </button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default IndicadoresEconomicosUpdateModule;
