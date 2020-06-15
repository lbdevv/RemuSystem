import React from 'react';
import { BrowserRouter,Switch,Route } from 'react-router-dom';
import Header from './Components/AdminTemplate/Header';
import Sidebar from './Components/AdminTemplate/Sidebar';
import Home from './Components/Remuneraciones/Home';
import ContentSidebar from './Components/AdminTemplate/ContentSidebar';
import Footer from './Components/AdminTemplate/Footer';
import FichaEmpresa from './Components/Remuneraciones/Empresa/FichaEmpresa';
import ListarEmpleados from './Components/Remuneraciones/Empleado/ListarEmpleado';
import CrearEmpleado from './Components/Remuneraciones/Empleado/CrearEmpleado';
import PrevisionEmpleado from './Components/Remuneraciones/Empleado/Prevision';

const Router = () => {
   return(
    <BrowserRouter>
        <Header/>

        <Sidebar/>
        <Switch>
                <Route exact path="/" component={Home} />
                <Route exact path="/Empresa" component={FichaEmpresa} />
                <Route exact path="/LstEmpleado" component={ListarEmpleados}/>
                <Route exact path="/AgregarEmpleado" component={CrearEmpleado}/>
                <Route exact path="/AgregarEmpleado/Prevision" component={PrevisionEmpleado}/>
        </Switch>
        {/* <Content/> */}

        <ContentSidebar/>
        <Footer/>
    </BrowserRouter>
    );
}

export default Router;
