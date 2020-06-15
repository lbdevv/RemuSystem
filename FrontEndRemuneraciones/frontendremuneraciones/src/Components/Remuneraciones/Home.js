import React from 'react';

const Home = () => {
    let Nav = "Página de Inicio"
    return (
        <div className="content-wrapper">

            <div className="content-header">
                <div className="container-fluid">
                    <div className="row mb-2">
                        <div className="col-md-6"> </div>
                        <div className="col-sm-6">
                            <ol className="breadcrumb float-sm-right">
                                <li className="breadcrumb-item">{Nav}</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div className="content">
                <h2>Bienvenido a tu software de Remuneraciones</h2>
            </div>

        </div>

    );
}

export default Home;