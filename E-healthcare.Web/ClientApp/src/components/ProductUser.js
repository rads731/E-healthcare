import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { AddProduct } from '../components/AddProduct';
import { DeleteProduct } from '../components/DeleteProduct';
import { UpdateReport } from '../components/UpdateReport';
import { GenerateReport } from '../components/GenerateReport';

export class ProductUser extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { showLogin: true, showRegister: true };
    }

    
    render() {
        return (
            <div className="ProductUser">
                <Route exact path='/add-product' component={AddProduct} />
                <Route path='/delete-product' component={DeleteProduct} />
                <Route path='/update-product' component={UpdateReport} />
                <Route path='/generate-report' component={GenerateReport} />


            </div>
        )
    }
}