import React, { Fragment } from 'react';
import '../src/assets/css/EstilosGenerales/EstilosGenerales.css'
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './Components/Remuneraciones/LoginApp/Registrar.css';
import PrivateRoute from './Components/Remuneraciones/LoginApp/Auth';
import Header from './Components/AdminTemplate/Header';
import Sidebar from './Components/AdminTemplate/Sidebar';
import Home from './Components/Remuneraciones/Home';
import ContentSidebar from './Components/AdminTemplate/ContentSidebar';
import Footer from './Components/AdminTemplate/Footer';
import Login from './Components/Remuneraciones/LoginApp/Login';
// import Registrar from './Components/Remuneraciones/LoginApp/Registrar';
import FichaEmpresa from './Components/Remuneraciones/Empresa/FichaEmpresa';
import InsertarCargo from './Components/Remuneraciones/Empresa/Configuracion/InsertarCargos'
import ListarEmpleados from './Components/Remuneraciones/Empleado/ListarEmpleado';
import CrearEmpleado from './Components/Remuneraciones/Empleado/CrearEmpleado';
import PrevisionEmpleado from './Components/Remuneraciones/Empleado/Prevision';
import SueldoLiquidacion from './Components/Remuneraciones/Empleado/Liquidacion/SueldoLiquidacion';
import ConfigLiquidaciones from './Components/Remuneraciones/Empleado/Liquidacion/ConfigLiquidaciones';
import CrearHaberesYdescuentos from './Components/Remuneraciones/Empresa/Configuracion/CrearHaberesYdescuentos';
import AsignarHoDEmpleado from './Components/Remuneraciones/Empresa/Configuracion/AsignarHoDEmpleado';
import ListadoHyDemp from './Components/Remuneraciones/Empresa/Configuracion/ListadoHyDemp';
import LibroRemuneraciones from './Components/Remuneraciones/Empresa/Reportes/LibroRemuneraciones';
import Reportes from './Components/Remuneraciones/Empresa/Reportes/Reportes';



const Router = () => {


    return (
        <BrowserRouter forceRefresh={true}>
            {
                localStorage.getItem('token') !== null ?
                    (
                        <Fragment>
                            <Header />
                            <Sidebar />
                            <Switch>
                                <div className="content-wrapper">
                                    <div className="content-header">
                                        <div className="container-fluid">
                                            <div className="row mb-2">
                                                <div className="col-md-6"> </div>
                                                <div className="col-sm-6">
                                                    <ol className="breadcrumb float-sm-right">
                                                        <li className="breadcrumb-item"><a href="#">Home</a></li>
                                                        <li className="breadcrumb-item active">Starter Page</li>
                                                    </ol>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="content container">
                                        <PrivateRoute exact path="/Home" component={Home} />
                                        <PrivateRoute exact path="/Empresa" component={FichaEmpresa} />
                                        <PrivateRoute exact path="/LstEmpleado" component={ListarEmpleados} />
                                        <PrivateRoute exact path="/AgregarEmpleado" component={CrearEmpleado} />
                                        <PrivateRoute exact path="/AgregarEmpleado/Prevision" component={PrevisionEmpleado} />
                                        <PrivateRoute exact path="/Liquidacion/:id" component={SueldoLiquidacion} />
                                        <PrivateRoute exact path="/Configuracion" component={ConfigLiquidaciones} />
                                        <PrivateRoute exact path="/AgregarCargo" component={InsertarCargo} />
                                        <PrivateRoute exact path="/AgregarHyD" component={CrearHaberesYdescuentos} />
                                        <PrivateRoute exact path="/AsigHyD" component={AsignarHoDEmpleado} />
                                        <PrivateRoute exact path="/HyDemp" component={ListadoHyDemp} />
                                        <PrivateRoute exact path="/Reportes/LibroRemuneraciones" component={LibroRemuneraciones} />
                                        <PrivateRoute exact path="/Reportes" component={Reportes} />
                                    </div>
                                </div>
                            </Switch>

                            <ContentSidebar />
                            <Footer />
                        </Fragment>)

                    : (<Route exact path="/" component={Login} />)
            }
        </BrowserRouter>
    );
}

export default Router;
