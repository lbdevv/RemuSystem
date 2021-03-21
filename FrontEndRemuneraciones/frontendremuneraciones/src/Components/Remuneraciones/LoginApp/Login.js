import React from 'react'
import { useForm } from 'react-hook-form'
import { useHistory } from 'react-router-dom'
import Global from '../../../Global'
import axios from 'axios'
import '../../../assets/css/EstilosGenerales/EstilosGenerales.css'

const Login = () => {


    const history = useHistory()
    const { register, errors, handleSubmit } = useForm()

    const Ingresar = (data, e) =>{
        console.log(data)
        e.target.reset()

        axios.post(Global.url + 'Usuario/Login', data)
        .then(res => {
            console.log(res)
             localStorage.setItem('token',res.data.data.token)

             if(localStorage.getItem('token')){
               history.push('/Home')
             }
        })
        .catch(err => {
            console.log(err)
        })
    }
    
    return (
      <div id="Login" className="fade-in Espaciado-header">
          <h3 className="text-center">Login</h3>
          <div className="row justify-content-center">
                <div className="col-12 col-xs-8 col-md-6 col-xl-4">
                    <form id="containerForm" onSubmit={handleSubmit(Ingresar)}>
                        <div className="form-group">
                            <label>Email</label>
                            <input className="form-control form-control-sm" type="text" name="Email" id="Email"  ref={register}/>
                        </div>

                        <div className="form-group">
                            <label>Contraseña</label>
                            <input className="form-control form-control-sm" type="password" name="Password" id="Password"  ref={register}/>
                        </div>
                        <div className="form-group">
                            <button type="submit" className="btn btn-success">Iniciar Sesión</button>
                        </div>

                    </form>
                </div>
          </div>
      </div>
    )
}

export default Login;