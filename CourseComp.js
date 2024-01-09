import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './External.css';
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
    console.log('Selected Course:', selectedCourse);
    console.log('Selected Module:', selectedModule);
    console.log('Selected Date:', selectedDate);

    const moduleId = selectedModule;

    const formattedDate = selectedDate ? selectedDate.toISOString().split('T')[0] : null;
    const apiUrl = `https://localhost:7069/api/Course/GetStudents/${moduleId}/${formattedDate}`;
    console.log('API URL:', apiUrl);

    if (selectedCourse && selectedModule && selectedDate) {
      axios.get(apiUrl)
        .then(response => {
          console.log('Fetched students:', response.data);
          const studentsData = response.data.map(student => ({
            studentId: student.regid,
            studentName: student.sName,
            courseId: student.cId,
            courseName: student.cName,
            POption: student.pOption,
            ICount: student.iCount,
            APay: student.aPay,
            PAmount: student.pAmount,
            PType: student.pType,
          }));
          console.log('Fetched students:', studentsData);
          setStudents(studentsData);
          setAttendance(studentsData.map(student => ({
            SId: student.studentId,
            SName: student.studentName,
            Date: formattedDate,
            Attendance: '', 
          })));
        })
        .catch(error => console.error('Error fetching students:', error));
    }
  };

  const handleSaveAttendance = () => {
    if (attendance.length === 0) {
      console.log('No attendance data to save.');
      return;
    }

    axios.post('https://localhost:7069/api/Course/SaveAttendance', attendance)
      .then(response => {
        console.log('Attendance saved successfully:', response.data);
      
      })
      .catch(error => console.error('Error saving attendance:', error));
  };

  const handleAttendanceChange = (studentId, status) => {
    const updatedAttendance = [...attendance];
    const studentIndex = updatedAttendance.findIndex(student => student.SId === studentId);

    if (studentIndex !== -1) {
      updatedAttendance[studentIndex].Attendance = status;
      setAttendance(updatedAttendance);
    }
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
          disabled={!selectedCourse} 
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
          disabled={!selectedModule}
        />
      </div>
      <div>
        <button onClick={handleFetchDetails} disabled={!selectedCourse || !selectedModule || !selectedDate}>
          Fetch
        </button>
      </div>
      {students.length > 0 && (
        <div>
          <h2>Student Details:</h2>
          <table className='attendance-table'>
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
                  <td>{selectedDate ? selectedDate.toLocaleDateString('en-US') : 'No Date Selected'}</td>
                  <td>
                    <label>
                      Present
                      <input
                        type="radio"
                        name={`attendance_${student.studentId}`}
                        value="P"
                        onChange={() => handleAttendanceChange(student.studentId, 'P')}
                        checked={attendance.some(a => a.SId === student.studentId && a.Attendance === 'P')}
                      />
                    </label>
                    <label>
                      Absent
                      <input
                        type="radio"
                        name={`attendance_${student.studentId}`}
                        value="A"
                        onChange={() => handleAttendanceChange(student.studentId, 'A')}
                        checked={attendance.some(a => a.SId === student.studentId && a.Attendance === 'A')}
                      />
                    </label>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div>
            <button onClick={handleSaveAttendance} disabled={attendance.length === 0}>
              Save Attendance
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default CourseComp;
