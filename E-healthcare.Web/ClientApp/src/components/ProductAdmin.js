import React, { Component } from 'react';
import { AddProduct } from '../components/AddProduct';
import { DeleteProduct } from '../components/DeleteProduct';
import { UpdateReport } from '../components/UpdateReport';
import { GenerateReport } from '../components/GenerateReport';
export class ProductAdmin extends Component {
    static displayName = ProductAdmin.name;

    constructor(props) {
        super(props);
        this.state = { };
    }

    
    render() {
        return (
            <div className="Admin">
                <Route exact path='/add-product' component={AddProduct} />
                <Route path='/delete-product' component={DeleteProduct} />
                <Route path='/update-product' component={UpdateReport} />
                <Route path='/generate-report' component={GenerateReport} />
                
            </div>
        );
    }
}
