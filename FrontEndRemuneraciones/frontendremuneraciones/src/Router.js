import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Header from './Components/AdminTemplate/Header';
import Sidebar from './Components/AdminTemplate/Sidebar';
import Home from './Components/Remuneraciones/Home';
import ContentSidebar from './Components/AdminTemplate/ContentSidebar';
import Footer from './Components/AdminTemplate/Footer';
import FichaEmpresa from './Components/Remuneraciones/Empresa/FichaEmpresa';
import ListarEmpleados from './Components/Remuneraciones/Empleado/ListarEmpleado';
import CrearEmpleado from './Components/Remuneraciones/Empleado/CrearEmpleado';
import PrevisionEmpleado from './Components/Remuneraciones/Empleado/Prevision';
import SueldoLiquidacion from './Components/Remuneraciones/Empleado/Liquidacion/SueldoLiquidacion';

const Router = () => {
    return (
        <BrowserRouter>
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
                    <div className="content">
                        <Route exact path="/" component={Home} />
                        <Route exact path="/Empresa" component={FichaEmpresa} />
                        <Route exact path="/LstEmpleado" component={ListarEmpleados} />
                        <Route exact path="/AgregarEmpleado" component={CrearEmpleado} />
                        <Route exact path="/AgregarEmpleado/Prevision" component={PrevisionEmpleado} />
                        <Route exact path="/Liquidacion/:id" component={SueldoLiquidacion} />
                    </div>
                </div>
            </Switch>
            {/* <Content/> */}


            <ContentSidebar />
            <Footer />
        </BrowserRouter>
    );
}

export default Router;
