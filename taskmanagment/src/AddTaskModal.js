import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class AddTaskModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'TaskClass',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                TaskDate:event.target.TaskDate.value,
                Day:event.target.Day.value,
                Course:event.target.Course.value,
                TaskName: event.target.TaskName.value,
                TimeRequired: event.target.TimeRequired.value,
                TimeNotSpent: event.target.TimeNotSpent.value,
                TaskStatus: event.target.TaskStatus.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
           alert(result);
        },
        (error)=>{
            alert('Failed');
        });
    }

    render(){
        return(
            <div className="container">
                <Modal {...this.props} size="lg" aria-labelledby="container-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Add Task
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId='DepartmentName'>
                                        <Form.Label>DepartmentName</Form.Label>
                                        <Form.Control type="text" name="DepartmentName" required placeholder='DepartmentName'></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='Date'>
                                        <Form.Label>Date</Form.Label>
                                        <Form.Control type="Date" name="Date" required></Form.Control>
                                    </Form.Group>

                                    
                                    <Form.Group controlId='Day'>
                                        <Form.Label>Day</Form.Label>
                                        <Form.Control type="text" name="Day" required ></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='Course'>
                                        <Form.Label>Course</Form.Label>
                                        <Form.Control type="text" name="Course" required></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='taskname'>
                                        <Form.Label>taskname</Form.Label>
                                        <Form.Control type="text" name="taskname" required></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='TimeRequired'>
                                        <Form.Label>TimeRequired</Form.Label>
                                        <Form.Control type="text" name="TimeRequired" required></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='TimeNotSpent'>
                                        <Form.Label>TimeNotSpent</Form.Label>
                                        <Form.Control type="text" name="TimeNotSpent" required></Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId='TaskStatus'>
                                        <Form.Label>TaskStatus</Form.Label>
                                        <Form.Control type="text" name="TaskStatus" required></Form.Control>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Add Department
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant='danger' onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        );
    }
}