import { useEffect, useState } from "react";
import { cancelAppointment, getAppointments } from "../data/appointmentData";
import { Table } from "reactstrap";
import { useNavigate } from "react-router-dom";

export default function AppointmentsView() {
  const [appointments, setAppointments] = useState([]);

  const navigate = useNavigate();

  useEffect(() => {
    getAppointments().then(setAppointments);
  }, []);

  const handleCancelAppointment = (event, id) => {
    event.preventDefault();
    cancelAppointment(id)
      .then(() => getAppointments())
      .then(setAppointments)
      .catch(console.error);
  };

  const handleEditAppointment = (id) => {
    return console.log(id);
  };

  return (
    <div className="container">
      <Table bordered>
        <thead>
          <tr>
            <th>Customer</th>
            <th>Stylist</th>
            <th>Date</th>
            <th>Time</th>
            <th>Status</th>
            <th>Notes</th>
            <th>{"Service(s)"}</th>
            <th></th>
            <th>
              <button
                className="btn btn-primary"
                onClick={() => navigate("/appointments/book")}
              >
                Book Appointment
              </button>
            </th>
          </tr>
        </thead>
        <tbody>
          {appointments?.map((a) => (
            <tr key={a.id}>
              <td>{a.customer.name}</td>
              <td>{a.stylist.name}</td>
              <td>{a.date}</td>
              <td>{a.time}</td>
              <td
                style={{
                  color: a.status ? "#155724" : "#721c24",
                  fontWeight: "bold",
                }}
              >
                {a.status ? "Good" : "Canceled"}
              </td>
              <td>{a.notes}</td>
              <td>
                {a.appointmentServices.map((apse) => (
                  <div key={apse.id}>{apse.service.name}</div>
                ))}
              </td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => handleEditAppointment(a.id)}
                >
                  Edit Appointment
                </button>
              </td>
              {a.status ? (
                <td>
                  <button
                    className="btn btn-secondary"
                    onClick={(event) => handleCancelAppointment(event, a.id)}
                  >
                    Cancel Appointment
                  </button>
                </td>
              ) : (
                <td
                  style={{
                    color: "#721c24",
                    fontWeight: "bold",
                  }}
                >
                  Canceled
                </td>
              )}
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
}
