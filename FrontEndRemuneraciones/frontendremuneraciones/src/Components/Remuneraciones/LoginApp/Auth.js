import React from 'react'
import { Route, Redirect } from 'react-router-dom'

const isAuth = () => {
    if(localStorage.getItem('token') !== null){
        return true
    }
    return false
}

const PrivateRoute = ({component: Component, ...options}) => {
    
    return(
        <Route 
        {...options}
        render={props =>
            isAuth() ? (
                <Component {...options} />

            ):(
                <Redirect 
                    to={{
                        pathname:'/Login',
                        state:{ message:'user not authorized' }
                    }}
                />
            )

        }
        />
    )
}

export default PrivateRoute