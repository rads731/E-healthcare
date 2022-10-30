import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { showLogin: true, showRegister:true };
    }

    renderLoginMode(val) {
        console.log(val)
        if (val === "User") {
            this.state.showLogin = false;
            this.state.showRegister = true;

        }
        console.log(this.state)
    }
  render () {
    return (
        <div className="Home">
            <h1> E-healthcare Portal</h1>
            <p>Welcome to E-healthcare Portal</p>
            <p>Please login by clicking on any one</p>
            {/*<ul type="none">*/}
            {/*    <li><button onClick={()=>this.renderLoginMode("Admin")}>Admin</button></li>*/}
            {/*    <li><button onClick={()=>this.renderLoginMode("User")}>User</button></li>*/}
            {/*</ul>*/}

                <div style={{ display: (this.state.showLogin? 'block':'none') }} className="" id="show-login">
                        <form>

                            <div className="form-outline mb-4">
                                <input type="email" id="form2Example1" className="form-control" />
                                <label className="form-label" for="form2Example1">Email address</label>
                            </div>


                            <div className="form-outline mb-4">
                                <input type="password" id="form2Example2" className="form-control" />
                                <label className="form-label" for="form2Example2">Password</label>
                            </div>

                            <div>
                            <input type="radio" id="admin" name="Admin" value="Admin" />
                            <label for="admin">Admin</label>
                            <input type ="radio" id="user" name="User" value="User"/>
                            <label for="user">User</label>
                            </div>

                            <button type="button" className="btn btn-primary btn-block mb-4">Sign in</button>


                        </form>
                    </div> 
       
            <button  onClick={() => this.renderLoginMode("User")}>Dont have account, register</button>
           
         
            <div style={{ display: (this.state.showRegister ? 'block' : 'hide') }} className="" id="show-register">

                      
                        <div className="tab-content">
                           
                            <div className="tab-pane fade" id="pills-register" role="tabpanel" aria-labelledby="tab-register">
                                <form>
                                  
                                   

                                    <div className="form-outline mb-4">
                                        <input type="text" id="registerFirstName" className="form-control" />
                                        <label className="form-label" for="registerFirstName">First Name</label>
                                    </div>

                                    <div className="form-outline mb-4">
                                        <input type="text" id="registerLastName" className="form-control" />
                                        <label className="form-label" for="registerLastName">Last name</label>
                                    </div>


                                    <div className="form-outline mb-4">
                                        <input type="email" id="registerEmail" className="form-control" />
                                        <label className="form-label" for="registerEmail">Email</label>
                                    </div>

                                    <div className="form-outline mb-4">
                                        <input type="password" id="registerPassword" className="form-control" />
                                        <label className="form-label" for="registerPassword">Password</label>
                                    </div>


                                    <div className="form-outline mb-4">
                                        <input type="password" id="registerRepeatPassword" className="form-control" />
                                        <label className="form-label" for="registerRepeatPassword">Repeat password</label>
                                    </div>


                                    <div className="form-check d-flex justify-content-center mb-4">
                                        <input className="form-check-input me-2" type="checkbox" value="" id="registerCheck" checked
                                            aria-describedby="registerCheckHelpText" />
                                        <label className="form-check-label" for="registerCheck">
                                            I have read and agree to the terms
                                        </label>
                                    </div>

                                    <button type="submit" className="btn btn-primary btn-block mb-3">Sign in</button>
                                </form>
                            </div>
                        </div>

                    </div> 
          
        </div>
    );
  }
}
