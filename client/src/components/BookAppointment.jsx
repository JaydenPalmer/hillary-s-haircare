import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCustomers } from "../data/cutsomerData";
import { getStylists } from "../data/stylistData";
import { getAppointments, submitAppointment } from "../data/appointmentData";
import { Form, FormGroup, Input, Label } from "reactstrap";
import { getServices } from "../data/serviceData";

export default function BookAppointment() {
  const navigate = useNavigate();

  const [customers, setCustomers] = useState([]);
  const [stylists, setStylists] = useState([]);
  const [services, setServices] = useState([]);
  const [appointments, setAppointments] = useState([]);
  const [dates, setDates] = useState([]);
  const [availableTimes, setAvailableTimes] = useState([]);
  const [selectedServices, setSelectedServices] = useState([]);
  const [selectedCustomer, setSelectedCustomer] = useState("");
  const [selectedStylist, setSelectedStylist] = useState("");
  const [selectedDate, setSelectedDate] = useState([]);
  const [selectedTime, setSelectedTime] = useState([]);

  useEffect(() => {
    getCustomers().then(setCustomers);
    getStylists().then(setStylists);
    getAppointments().then(setAppointments);
    getServices().then(setServices);
  }, []);

  useEffect(() => {
    // This function generates the dates for the next month
    const getNextMonthDates = () => {
      const currentDate = new Date();
      const nextMonth = currentDate.getMonth() + 1;
      const year = currentDate.getFullYear();
      const startOfNextMonth = new Date(year, nextMonth, 1);
      const endOfNextMonth = new Date(year, nextMonth + 1, 0);

      const dates = [];
      let currentDay = startOfNextMonth;
      while (currentDay <= endOfNextMonth) {
        dates.push(new Date(currentDay));
        currentDay.setDate(currentDay.getDate() + 1);
      }

      return dates;
    };

    setDates(getNextMonthDates()); // Set the dates once the component is mounted
  }, []);

  const generateTimeSlots = () => {
    const slots = [];

    for (let hour = 8; hour <= 20; hour++) {
      //converting 8 or whatever hour is to 8:00
      const time24hr = `${hour.toString().padStart(2, "0")}:00:00`;

      let time12hr;
      if (hour > 12) {
        time12hr = `${hour - 12}:00 PM`;
      } else if (hour === 12) {
        time12hr = "12:00 PM";
      } else {
        time12hr = `${hour}:00 AM`;
      }

      slots.push({ value: time12hr, label: time24hr });
    }
    return slots;
  };

  useEffect(() => {
    if (selectedStylist && selectedDate) {
      const allTimeSlots = generateTimeSlots();

      const bookedTimes = appointments
        .filter(
          (apt) =>
            apt.stylistId === selectedStylist && apt.date === selectedDate
        )
        .map((apt) => apt.time);

      const available = allTimeSlots.filter(
        (slot) => !bookedTimes.includes(slot.value)
      );

      setAvailableTimes(available);
    }
  }, [selectedDate, selectedStylist]);

  //date formatter
  const formatDate = (date) => date.toISOString().split("T")[0];

  const handleSubmit = (event) => {
    event.preventDefault();
    if (
      selectedCustomer &&
      selectedDate &&
      selectedServices &&
      selectedStylist &&
      selectedTime
    ) {
      const appointment = {
        customerId: selectedCustomer,
        stylistId: selectedStylist,
        date: selectedDate,
        time: selectedTime,
        notes: null,
        serviceIds: selectedServices,
      };

      submitAppointment(appointment).then(() => navigate("/appointments"));
    } else {
      window.alert("please select all feilds before booking appointment");
    }
    return console.log("haha");
  };

  const handleServicesChecked = (e) => {
    const { value, checked } = e.target;

    if (checked) {
      setSelectedServices([...selectedServices, parseInt(value)]);
    } else {
      setSelectedServices(
        selectedServices.filter((s) => s !== parseInt(value))
      );
    }
  };

  return (
    <div className="container">
      <h4 className="p-3">Book Appointment</h4>
      <Form>
        <FormGroup>
          <Label>Customer</Label>
          <Input
            type="select"
            value={selectedCustomer}
            onChange={(e) => setSelectedCustomer(parseInt(e.target.value))}
          >
            <option value="">Select a customer</option>
            {customers.map((customer) => (
              <option key={customer.id} value={customer.id}>
                {customer.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Stylist</Label>
          <Input
            type="select"
            value={selectedStylist}
            onChange={(e) => setSelectedStylist(parseInt(e.target.value))}
          >
            <option value="">Select a customer</option>
            {stylists.map((s) => (
              <option key={s.id} value={s.id}>
                {s.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="appointmentDate">Select Appointment Date</Label>
          <Input
            type="select"
            name="appointmentDate"
            id="appointmentDate"
            onChange={(e) => setSelectedDate(e.target.value)}
          >
            <option value="">Select a date</option>
            {dates.map((date, index) => (
              <option key={index} value={formatDate(date)}>
                {date.toLocaleDateString()}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Stylist</Label>
          <Input
            type="select"
            value={selectedTime}
            onChange={(e) => setSelectedTime(e.target.value)}
          >
            <option value="">Select a time</option>
            {availableTimes.map((t) => (
              <option key={t.label} value={t.label}>
                {t.value}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          {services.map((service) => (
            <FormGroup check key={service.id}>
              <Label check>
                <Input
                  type="checkbox"
                  name="services"
                  value={service.id}
                  onChange={handleServicesChecked}
                />
                {service.name}
              </Label>
            </FormGroup>
          ))}
        </FormGroup>
        <button
          className="btn btn-primary"
          onClick={(event) => handleSubmit(event)}
        >
          Submit Appointment
        </button>
      </Form>
    </div>
  );
}

//we need to display services so they are available for selection
//when one is chosen then it is no longer available to be selected
//wait to do the delete functionality but still need to display a cart
//all stored as an array and reference the endpoint for how it should all be sent
