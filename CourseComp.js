import React, { useState, useEffect } from 'react';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';

const CourseComp = () => {
  const [courses, setCourses] = useState([]);
  const [selectedCourse, setSelectedCourse] = useState('');
  const [modules, setModules] = useState([]);
  const [selectedModule, setSelectedModule] = useState('');
  const [selectedDate, setSelectedDate] = useState(null);
  const [students, setStudents] = useState([]);
  const [attendance, setAttendance] = useState([]);

  useEffect(() => {
    // Fetch courses from the API when the component mounts
    axios.get('https://localhost:7069/api/Course/GetNotes')
      .then(response => {
        console.log('Fetched courses:', response.data);
        setCourses(response.data);
      })
      .catch(error => console.error('Error fetching courses:', error));
  }, []);

  useEffect(() => {
    // Fetch modules based on the selected course
    if (selectedCourse !== '') {
      axios.get(`https://localhost:7069/api/Course/GetModules/${selectedCourse}`)
        .then(response => {
          console.log('Fetched modules:', response.data);
          setModules(response.data);
        })
        .catch(error => console.error('Error fetching modules:', error));
    }
  }, [selectedCourse]);

  const handleFetchDetails = () => {
    // Log selectedModule, selectedDate, and constructed URL
    console.log('Selected Module:', selectedModule);
    console.log('Selected Date:', selectedDate);

    const formattedDate = selectedDate ? selectedDate.toISOString().split('T')[0] : null;
    const apiUrl = `https://localhost:7069/api/Course/GetStudents/${selectedModule}/${formattedDate}`;
    console.log('API URL:', apiUrl);

    // Fetch student details based on the selected module and date
    if (selectedModule && selectedDate) {
      axios.get(apiUrl)
        .then(response => {
          console.log('Fetched students:', response.data);

          // Assuming the response.data is an array of FeesStructure
          // If the structure is different, adjust this part accordingly
          const studentsData = response.data.map(student => ({
            studentId: student.Regid,
            studentName: student.SName,
            attendanceStatus: '', // You can set the default value for attendance status here
          }));

          setStudents(studentsData);
        })
        .catch(error => console.error('Error fetching students:', error));
    }
  };

  const handleSaveAttendance = () => {
    // Implement logic to save attendance
    console.log('Attendance saved:', attendance);
  };

  const handleAttendanceChange = (studentId, status) => {
    // Update the attendance state based on radio button selection
    const updatedAttendance = [...attendance];
    const studentIndex = updatedAttendance.findIndex(student => student.studentId === studentId);

    if (studentIndex !== -1) {
      updatedAttendance[studentIndex].attendanceStatus = status;
    } else {
      updatedAttendance.push({ studentId, attendanceStatus: status });
    }

    setAttendance(updatedAttendance);
  };

  return (
    <div>
      <div>
        <label htmlFor="courseDropdown">Select Course:</label>
        <select
          id="courseDropdown"
          value={selectedCourse}
          onChange={(e) => setSelectedCourse(e.target.value)}
        >
          {courses.length === 0 ? (
            <option value="" disabled>No courses available</option>
          ) : (
            <>
              <option value="">Select Course</option>
              {courses.map(course => (
                <option key={course.cId} value={course.cId}>
                  {course.cName}
                </option>
              ))}
            </>
          )}
        </select>
      </div>
      <div>
        <label htmlFor="moduleDropdown">Select Module:</label>
        <select
          id="moduleDropdown"
          value={selectedModule}
          onChange={(e) => setSelectedModule(e.target.value)}
          disabled={!selectedCourse} // Disable if no course selected
        >
          {modules.length === 0 ? (
            <option value="" disabled>No modules available</option>
          ) : (
            <>
              <option value="">Select Module</option>
              {modules.map(module => (
                <option key={module.mId} value={module.mId}>
                  {module.mName}
                </option>
              ))}
            </>
          )}
        </select>
      </div>
      <div>
        <label htmlFor="datepicker">Select Date:</label>
        <DatePicker
          id="datepicker"
          selected={selectedDate}
          onChange={(date) => setSelectedDate(date)}
          dateFormat="MM/dd/yyyy"
          disabled={!selectedModule} // Disable if no module selected
        />
      </div>
      <div>
        <button onClick={handleFetchDetails}>Fetch Details</button>
        {students.length > 0 && (
          <div>
            <h2>Student Details:</h2>
            <table>
              <thead>
                <tr>
                  <th>Student ID</th>
                  <th>Student Name</th>
                  <th>Date</th>
                  <th>Attendance</th>
                </tr>
              </thead>
              <tbody>
                {students.map(student => (
                  <tr key={student.studentId}>
                    <td>{student.studentId}</td>
                    <td>{student.studentName}</td>
                    <td>
                      <label>
                        Present
                        <input
                          type="radio"
                          name={`attendance_${student.studentId}`}
                          value="Present"
                          onChange={() => handleAttendanceChange(student.studentId, 'Present')}
                        />
                      </label>
                      <label>
                        Absent
                        <input
                          type="radio"
                          name={`attendance_${student.studentId}`}
                          value="Absent"
                          onChange={() => handleAttendanceChange(student.studentId, 'Absent')}
                        />
                      </label>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            <div>
              <button onClick={handleSaveAttendance}>Save Attendance</button>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default CourseComp;
