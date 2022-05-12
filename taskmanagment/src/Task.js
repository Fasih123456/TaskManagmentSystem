import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button,ButtonToolbar} from 'react-bootstrap';
import { AddTaskModal } from './AddTaskModal';
import { EdittaskModal } from './EdittaskModel';

export class Task extends Component{
    constructor(props){
        super(props);
        this.state={tsk:[], addModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'TaskClass').then(response=>response.json()).then(data=>{
            this.setState({tsk:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deletetask(taskid){
        if(window.confirm('Are you sure')){
            fetch(process.env.REACT_APP_API+'TaskClass/'+taskid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-type' : 'application/json'}
            })
        }
    }

    render(){
        
        const {tsk, taskid, taskname,taskdate,day,course,timerequired,timenotspent,taskstatus} = this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return (

            <div>
                <Table className='mt-4' striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>TaskId</th>
                            <th>TaskDate</th>
                            <th>Day</th>
                            <th>Course</th>
                            <th>Task Name</th>
                            <th>Time Required</th>
                            <th>Time Not Spent</th>
                            <th>Task Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tsk.map(task=>
                        <tr key={tsk.TaskId}>
                            <td>{task.TaskId}</td>
                            <td>{task.TaskDate}</td>
                            <td>{task.Day}</td>
                            <td>{task.Course}</td>
                            <td>{task.TaskName}</td>
                            <td>{task.TimeRequired}</td>
                            <td>{task.TimeNotSpent}</td>
                            <td>{task.TaskStatus}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button className="mr-2" variant='info' onClick={()=>this.setState({editModalShow:true,taskid:task.TaskId,
                                        taskdate:task.TaskDate,day:task.Day,course:task.Course,taskname:task.TaskName,timerequired:task.TimeRequired,
                                        timenotspent:task.TimeNotSpent,taskstatus:task.TaskStatus
                                        })}>
                                    Edit
                                    </Button>

                                    <Button className="mr-2" variant='danger' onClick={()=>this.deletetask(task.taskid)}>
                                    Delete
                                    </Button>
                                    
                                    <EdittaskModal show={this.state.editModalShow}
                                    onHide={editModalClose}
                                    taskid={taskid}
                                    taskname={taskname}
                                    taskdate ={taskdate}
                                    day = {day}
                                    course = {course}
                                    timerequired = {timerequired}
                                    timenotspent = {timenotspent}
                                    status={taskstatus}
                                    />
                                </ButtonToolbar>
                            </td>
                        </tr> 
                            )}
                    </tbody>
                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        Add taskartment
                    </Button>

                    <AddTaskModal show={this.state.addModalShow} onHide={addModalClose}></AddTaskModal>
                </ButtonToolbar> 
            </div>
        )
    }

}