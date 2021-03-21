import React from 'react';
import { NavLink } from 'react-router-dom';


const Sidebar = () => {
  return (
    <aside className="main-sidebar sidebar-dark-primary elevation-4">
      <a href="index3.html" className="brand-link">

        <span className="brand-text font-weight-light">Remuneraciones</span>
      </a>
      <div className="sidebar">
        <div className="user-panel mt-3 pb-3 mb-3 d-flex">
          <div className="image">

          </div>
          <div className="info">
            <a href="#" className="d-block">Usuario Aleatorio</a>
          </div>
        </div>
        <nav className="mt-2">
          <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
            {/* Add icons to the links using the .nav-icon class
                         with font-awesome or any other icon font library */}
            <li className="nav-item">
              <NavLink to="/home" className="nav-link">
                  <i className="nav-icon fa fa-home"></i>
                  <p>Inicio</p>
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink to="/Configuracion" className="nav-link">
              <i className="nav-icon fas fa-cog" ></i>
              <p>Configuración</p>
              </NavLink>
            </li>
     
            <li className="nav-item">
              <NavLink to="/Empresa" className="nav-link">
                <i className="nav-icon fas fa-building" ></i>
                <p>Empresa</p>
              </NavLink>
              </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/LstEmpleado">
                <i className="nav-icon fas fa-users"></i>
                <p>Empleados</p>
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/Reportes" >
                    <i className="nav-icon fas fa-file"></i>
                    <p>Reportes</p>
              </NavLink>
            </li>

            </ul>
          </nav>
        </div>
      </aside >
    );
}

export default Sidebar;