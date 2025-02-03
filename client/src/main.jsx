import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AppointmentsView from "./components/AppointmentView.jsx";
import BookAppointment from "./components/BookAppointment.jsx";
import StylistList from "./components/StylistList.jsx";

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route index element={<AppointmentsView />} />
        <Route path="appointments">
          <Route index element={<AppointmentsView />} />
          <Route path="book" element={<BookAppointment />} />
        </Route>
        <Route path="stylists">
          <Route index element={<StylistList />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
