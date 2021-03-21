import React from 'react';

const Registrar = () => {
    return (
        <div className="container">
            <div className="card col-md-6">
                <div className="card-header">
                    <h2>Registro </h2>
                </div>
                <div className="card-body ">
                    <form method="post">
                        <div className="form-group">
                            <label>RUT</label>
                            <input type="text" className="form-control"/>
                        </div>
                        <div className="form-group">
                            <label>Email</label>
                            <input type="text" name="user" className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Contraseña</label>
                            <input type="text" name="password1" className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Confirma contraseña</label>
                            <input type="text" name="password2" className="form-control" />
                        </div>
                        <div className="form-group">
                            <button type="submit" className="btn btn-primary">Registrar</button>
                        </div>
                    </form>
                </div>
                <div className="card-footer">
                    &copy; GeoRemu
            </div>
            </div>
        </div>
    )
}

export default Registrar;