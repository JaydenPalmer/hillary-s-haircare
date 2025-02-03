const apiURL = "/api/appointments";

export const getAppointments = () => {
  return fetch(apiURL).then((res) => res.json());
};

export const cancelAppointment = (id) => {
  return fetch(`${apiURL}/${id}/cancel`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
  });
};

export const submitAppointment = (appointment) => {
  return fetch(apiURL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(appointment),
  }).then((res) => res.json());
};
