import React from 'react'
import { useForm } from 'react-hook-form'
import { useHistory } from 'react-router-dom'
import Global from '../../../Global'
import axios from 'axios'
import '../../../assets/css/EstilosGenerales/EstilosGenerales.css'
import '../../../assets/css/Login/login.css'

const Login = () => {


    const history = useHistory()
    const { register, errors, handleSubmit } = useForm()

    const Ingresar = (data, e) =>{
        debugger
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
          <div className="row justify-content-center">
                <div className="col-12 col-xs-8 col-md-6 col-xl-4 card">
                <h3 className="text-center">Login</h3>
                    <form id="containerForm" onSubmit={handleSubmit(Ingresar)}>
                        <div className="form-group">
                            <label className="text-white">Email</label>
                            <input className="form-control form-control-sm" type="text" name="Email" id="Email" placeholder="E-mail" required  ref={register}/>
                        </div>

                        <div className="form-group">
                            <label className="text-white">Contraseña</label>
                            <input className="form-control form-control-sm" type="password" name="Password" id="Password" placeholder="Contraseña" required ref={register}/>
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