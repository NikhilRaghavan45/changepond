import React, { Component } from 'react'
import { Link } from 'react-router-dom'

class Home2Comp extends Component {
    render() {
        return (
            <div>
                <Link to="/Home3Comp" className='btn btn-primary ms-3'>Get</Link>

            </div>
        )
    }
}

export default Home2Comp
