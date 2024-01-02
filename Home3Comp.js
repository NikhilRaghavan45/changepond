import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

function Home3Comp() {
    const [values, setValues] = useState({
        name: '',
        price: 0,
    });
    const [reservations, setReservations] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        // Fetch reservations when the component mounts
        axios.get('https://localhost:7094/api/reservations')
            .then(res => {
                console.log(res.data);
                setReservations(res.data);
            })
            .catch(err => console.log(err));
    }, []); // Empty dependency array means this effect runs once after the initial render

    const handleSubmit = (event) => {
        event.preventDefault();
        // Your existing form submission logic
    }

    return (
        <div className='d-flex w-100 vh-100 justify-content-center align-items-center bg-light'>
            <div className='w-75 border bg-white shadow px-5 pt-3 pb-5 rounded'>
                <h2 className='mb-4'>Reservation List</h2>
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Start Location</th>
                            <th>End Location</th>
                        </tr>
                    </thead>
                    <tbody>
                        {reservations.map((reservation) => (
                            <tr key={reservation.id}>
                                <td>{reservation.id}</td>
                                <td>{reservation.name}</td>
                                <td>{reservation.startLocation}</td>
                                <td>{reservation.endLocation}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                <Link to="/Home2Comp" className='btn btn-primary ms-3'>Back</Link>
            </div>
        </div>
    );
}

export default Home3Comp;

