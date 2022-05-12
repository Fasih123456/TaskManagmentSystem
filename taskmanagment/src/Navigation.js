import React,{Component} from 'react';
import { NavLink } from 'react-bootstrap';
import { Navbar,Nav } from 'react-bootstrap';

export class Navigation extends Component{
    render(){
        return (
            <Navbar  bg="dark">
                <Navbar.Toggle aria-controls='basic-navbar-nav'/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav>
                        <NavLink className='d-inline p-2 bg-dark text-white' href="/">
                            Home
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-dark text-white' href="/Courses">
                            Courses
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-dark text-white' href="/Task">
                            Task
                        </NavLink>
                        <NavLink className='d-inline p-2 bg-dark text-white' href="/TimeTracker">
                            TimeTracker
                        </NavLink>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>

        )
    }
}